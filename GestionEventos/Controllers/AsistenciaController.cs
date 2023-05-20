using AutoMapper;
using GestionEventos.DTOs;
using GestionEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.MemoryMappedFiles;
using zipkin4net.Annotation;

namespace GestionEventos.Controllers
{
    //validaciones automaticas
    [ApiController]

    //ruta
    [Route("api/Asistencia")]

    public class AsistenciaController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        //Mappeo
        private readonly IMapper mapper;

        public AsistenciaController(ApplicationDbContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;
            
        }

        //CRUD
        [HttpGet("Listado completo")]
        public async Task<ActionResult<List<Asistencia>>> GetAsistencias()
        {
            return await dbContext.Asistencias.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Asistencia>> GetById(int id)
        {
            return await dbContext.Asistencias.FirstOrDefaultAsync(x => x.Id == id);
        }

        /*[HttpPost]
        public async Task<ActionResult> Post(Asistencia asistencia)
        {
            dbContext.Add(asistencia);
            await dbContext.SaveChangesAsync();
            return Ok();
        }*/

        [HttpPost("Marcar asistencia")]
        public async Task<ActionResult> Post(AsistenciaDto asistenciadto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistencia = mapper.Map<Asistencia>(asistenciadto);

            dbContext.Add(asistencia);
            await dbContext.SaveChangesAsync();

            /*var evento = await dbContext.Eventos.FirstOrDefaultAsync(e => e.Id == asistencia.EventoId);
            var evento = await dbContext.Eventos.FirstOrDefaultAsync(e => e.Id == asistenciadto.EventoId);
            if (evento != null)

                if (evento != null)
                {
                    evento.ConteoCapacidad = evento.Asistencias.Count;
                    await dbContext.SaveChangesAsync();
                }*/
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Asistencia asistencia, int id)
        {
            var exist = await dbContext.Asistencias.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("Ya te has registrado a este evento");
            }

            if (asistencia.Id != id)
            {
                return BadRequest("No te has registrado a este evento");
            }

            dbContext.Update(asistencia);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Asistencias.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado");
            }

            dbContext.Remove(new Asistencia { Id = id });

            await dbContext.SaveChangesAsync();
            return Ok();
        }


    }
}
