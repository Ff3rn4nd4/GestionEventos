using GestionEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Controllers
{
    //validaciones automaticas
    [ApiController]

    //ruta
    [Route("api/Asistencia")]

    public class AsistenciaController: ControllerBase
    {
        /*private readonly ApplicationDbContext dbContext;

        public AsistenciaController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        //CRUD
        [HttpGet("Listado completo")]
        public async Task<ActionResult<List<Asistencia>>> GetAsistencias()
        {
            return await dbContext.Asistencias.ToListAsync();
        }*/


    }
}
