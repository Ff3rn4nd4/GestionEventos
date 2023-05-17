using GestionEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Controllers
{
    //validaciones automaticas
    [ApiController]

    //ruta
    [Route("api/usuarios")]

    public class UsuariosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UsuariosController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        [HttpGet("Listado completo")]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            return await dbContext.Usuarios.ToListAsync();
        }

    }
}
