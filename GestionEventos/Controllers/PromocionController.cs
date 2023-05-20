using AutoMapper;
using GestionEventos.DTOs;
using GestionEventos.Entidades;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Controllers
{
    //validaciones automaticas/por defecto
    [ApiController]

    //ruta
    [Route("api/promociones")]

    public class PromocionController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public PromocionController(ApplicationDbContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;
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

        /*[HttpPost]
        public async Task<ActionResult> Post(Promocion promocion)
        {
            dbContext.Add(promocion);
            await dbContext.SaveChangesAsync();
            return Ok();
        }*/

        [HttpPost("Validar una Promocion")]
        public async Task<ActionResult> Post(PromocionDto promociondto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var promocion = mapper.Map<Promocion>(promociondto);

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

        //Aplicando Patch y JsonPatch
        //Muy parecido a put, sirve para actualizar
        /*[HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Promocion> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }
            var promocion = await dbContext.Promociones.FindAsync(id);

            if (promocion == null)
            {
                return NotFound();
            }

            patchDocument.ApplyTo(promocion);
            await dbContext.SaveChangesAsync();
            return NoContent();

        }*/

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<PromocionPatchDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var promocion = await dbContext.Promociones.FindAsync(id);

            if (promocion == null)
            {
                return NotFound();
            }

            var promocionPatchDto = mapper.Map<PromocionPatchDto>(promocion);
            patchDocument.ApplyTo(promocionPatchDto, ModelState);

            if (!TryValidateModel(promocionPatchDto))
            {
                return BadRequest(ModelState);
            }

            mapper.Map(promocionPatchDto, promocion);
            await dbContext.SaveChangesAsync();

            return NoContent();
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
