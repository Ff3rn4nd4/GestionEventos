using AutoMapper;
using GestionEventos.DTOs;
using GestionEventos.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.MemoryMappedFiles;
using System.Security.Claims;
using zipkin4net.Annotation;

namespace GestionEventos.Controllers
{
    //validaciones automaticas
    [ApiController]
    //ruta
    [Route("api/Asistencia")]
    //Para que todos los vean 
    [AllowAnonymous]

    public class AsistenciaController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        //Mappeo
        private readonly IMapper mapper;
        //


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

        /*[HttpPost("Marcar asistencia")]
        public async Task<ActionResult> Post(AsistenciaDto asistenciadto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistencia = mapper.Map<Asistencia>(asistenciadto);

            dbContext.Add(asistencia);
            await dbContext.SaveChangesAsync();
            return Ok();
        }*/

        [HttpPost ("Marcar asistencia")]
        public async Task<ActionResult> Post(AsistenciaDto asistenciadto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

                var eventoDto = await dbContext.Eventos
            .Where(e => e.Id == asistenciadto.EventoId)
            .Select(e => new EventoDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Capacidad = e.Capacidad,
                ConteoAsistencias = e.Asistencias.Count
            })
            .FirstOrDefaultAsync();

            if (eventoDto == null)
            {
                return NotFound("El evento no existe");
            }

            if (eventoDto.ConteoAsistencias >= eventoDto.Capacidad)
            {
                return BadRequest("Lo siento, se excede la capacidad del evento");
            }

            var asistencia = mapper.Map<Asistencia>(asistenciadto);

            dbContext.Add(asistencia);
            await dbContext.SaveChangesAsync();

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
