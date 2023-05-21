﻿using GestionEventos.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionEventos.Controllers
{
    [Authorize]
    [Route("Cuentas")]
    public class CuentasController: ControllerBase
    {
        // Es el usuario que vamos a registrar
        private readonly UserManager<IdentityUser> userManager;
        //Para obterner la key.
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public CuentasController(UserManager<IdentityUser> userManager, IConfiguration configuration,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }


        [HttpPost("Registrarse")]
        public async Task<ActionResult<RespuestaAutenticacionDto>> Registrar(UsuarioDto credenciales)
        {
            var user = new IdentityUser { UserName = credenciales.Correo, Email = credenciales.Correo };
            var result = await userManager.CreateAsync(user, credenciales.Contrasenia);

            if (result.Succeeded)
            {
                //Se retorna el Jwt (Json Web Token) especifica el formato del token que hay que devolverle a los clientes
                return await ConstruirToken(credenciales);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<RespuestaAutenticacionDto>> Login(UsuarioDto credencialesUsuario)
        {
            var result = await signInManager.PasswordSignInAsync(credencialesUsuario.Correo,
                credencialesUsuario.Contrasenia, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await ConstruirToken(credencialesUsuario);
            }
            else
            {
                return BadRequest("Login Incorrecto");
            }

        }

        [HttpGet("RenovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<RespuestaAutenticacionDto>> Renovar()
        {
            //Para renovarlo no tiene que haber vencido el token actual.
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;

            var credenciales = new UsuarioDto()
            {
                Correo = email
            };

            return await ConstruirToken(credenciales);

        }

        //Tokkens
        private async Task<RespuestaAutenticacionDto> ConstruirToken(UsuarioDto credencialesUsuario)
        {
            //Informacion del usuario en la cual podemos confiar
            //En los claim se pueden declarar cualquier variable, sin embargo, no debemos de declarar informacion
            //del cliente sensible como pudiera ser una Tarjeta de Credito o contraseña

            var claims = new List<Claim>
            {
                //Podemos agregar los claims que nosotros queramos y no nos va a marcar error.
                //Esta información viene encriptada.
                new Claim("email", credencialesUsuario.Correo),
                new Claim("claimprueba", "Este es un claim de prueba")
            };

            var usuario = await userManager.FindByEmailAsync(credencialesUsuario.Correo);
            var claimsDB = await userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Se agregan cada 30 minutos, si expira se desloguea.
            //Por eso hay un método para renovar el token.
            var expiration = DateTime.UtcNow.AddMinutes(30);

            //se contruye el token que el usuario usara para que funcione el sistema.
            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

            return new RespuestaAutenticacionDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiration
            };
        }

        [HttpPost("HacerOrganizador")]
        public async Task<ActionResult> HacerOrganizador(AscenderOrganizadorDto ascenderOrganizadordto)
        {
            var usuario = await userManager.FindByEmailAsync(ascenderOrganizadordto.Correo);

            //Se agrega un claim al usuario haciendolo organizador, el valor no importa
            await userManager.AddClaimAsync(usuario, new Claim("Organizador", "1"));

            return NoContent();
        }

        [HttpPost("RemoverOrganizador")]
        public async Task<ActionResult> RemoverOrganizador(AscenderOrganizadorDto ascenderOrganizadordto)
        {
            var usuario = await userManager.FindByEmailAsync(ascenderOrganizadordto.Correo);

            //Se remuve el claim de "EsOrganizador", el valor no importa
            await userManager.RemoveClaimAsync(usuario, new Claim("Organizador", "1"));

            return NoContent();
        }

    }
}
