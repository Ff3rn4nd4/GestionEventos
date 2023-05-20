using AutoMapper;
using GestionEventos.DTOs;
using GestionEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Controllers
{
    //validaciones automaticas/por defecto
    [ApiController]

    //ruta
    [Route("api/favoritos")]
    public class FavoritosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public FavoritosController(ApplicationDbContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;
        }

        //CRUD

        [HttpGet("Listado completo")]
        public async Task<ActionResult<List<Favorito>>> GetAll()
        {
            return await dbContext.Favoritos.ToListAsync();
        }

        /*[HttpPost]
        public async Task<ActionResult> Post(Favorito favorito)
        {
            dbContext.Add(favorito);
            await dbContext.SaveChangesAsync();
            return Ok();
        }*/

        [HttpPost("Marcar como favorito")]
        public async Task<ActionResult> Post(FavoritoDto favoritodto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var favorito = mapper.Map<Favorito>(favoritodto);

            dbContext.Add(favorito);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Favoritos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado");
            }

            dbContext.Remove(new Favorito { Id = id });

            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
