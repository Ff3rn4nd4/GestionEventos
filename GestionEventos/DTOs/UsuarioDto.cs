using System.ComponentModel.DataAnnotations;

namespace GestionEventos.DTOs
{
    public class UsuarioDto
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Contrasenia { get; set; }
    }
}
