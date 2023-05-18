using GestionEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Controllers
{
    //validaciones automaticas/por defecto
    [ApiController]

    //ruta
    [Route("api/comentarios")]

    public class ComentariosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ComentariosController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        //CRUD

        [HttpGet("Listado completo")]
        public async Task<ActionResult<List<Comentario>>> GetAll()
        {
            return await dbContext.Comentarios.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Comentario>> GetById(int id)
        {
            return await dbContext.Comentarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Comentario comentario)
        {
            dbContext.Add(comentario);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Comentario comentario, int id)
        {
            var exist = await dbContext.Comentarios.AnyAsync(e => e.Id == id);

            if (!exist)
            {
                return NotFound("Este comentario no existe");
            }

            if (comentario.Id != id)
            {
                return BadRequest("El id de este comentario no existe en la url");
            }

            dbContext.Update(comentario);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Comentarios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado");
            }

            dbContext.Remove(new Comentario { Id = id });

            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
