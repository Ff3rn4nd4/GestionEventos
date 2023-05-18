using GestionEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Controllers
{
    //validaciones automaticas
    [ApiController]

    //ruta
    [Route("api/promociones")]

    public class PromocionController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PromocionController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        //CRUD

        [HttpGet("Listado completo")]
        public async Task<ActionResult<List<Promocion>>> GetAll()
        {
            return await dbContext.Promociones.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Promocion>> GetById(int id)
        {
            return await dbContext.Promociones.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Promocion promocion)
        {
            dbContext.Add(promocion);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Promocion promocion, int id)
        {
            var exist = await dbContext.Promociones.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("Esta promocion no existe");
            }

            if (promocion.Id != id)
            {
                return BadRequest("El id de la promocion no existe en la url");
            }

            dbContext.Update(promocion);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Promociones.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado");
            }

            dbContext.Remove(new Promocion { Id = id });

            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
