using AutoMapper;
using GestionEventos.DTOs;
using GestionEventos.Entidades;
using GestionEventos.Filtros;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Controllers
{
    //validaciones automaticas/por defecto
    [ApiController]

    //ruta
    [Route("api/eventos")]
    //Para que todos los vean 
    [AllowAnonymous]

    public class EventosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        //Implementando Log de errores
        private readonly ILogger<EventosController> logger;
        //Mappeo
        private readonly IMapper mapper;



        public EventosController(ApplicationDbContext context, ILogger<EventosController> logger, IMapper mapper)
        {
            dbContext = context;
            //Ahora se puede aplicar a cualquier metodo del CRUD
            this.logger = logger;
            //Mappeo
            this.mapper = mapper;
        }

        /*metodo get con Datos Dummy

        [HttpGet]
         public ActionResult <List<Evento>> Get() 
         {
             return new List<Evento>()
             {
                 new Evento() { Id= 1, Nombre="Cumpleanios Francisco", Descripcion="Fiesta infantil", Fecha="3 de Octubre", Hora= "8 pm",Ubicacion="Monterrey", 
                 Capacidad=100},
                 new Evento() { Id=2, Nombre="Cumpleanios Dan", Descripcion="Fiesta de cumpleanios", Fecha="2 de Diciembre", Hora= "10 pm",Ubicacion="Monterrey",
                 Capacidad=150 }
             };
         }*/

        //CRUD

        [HttpGet("Listado completo")]
        public async Task<ActionResult<List<Evento>>> GetAll()
        {
            //Este tipo de log solo lo muestra al programador
            logger.LogInformation("Se obtiene la lista con todos los eventos");
            return await dbContext.Eventos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        [Produces("application/json")]
        //public async Task<ActionResult<Evento>> GetById(int id)
        public async Task<ActionResult<EventoDto>> GetById(int id)
        {
            
            //Para que con Evento aparezcan sus comentarios y promociones
                /*var evento = await dbContext.Eventos
            .Include(e => e.Comentarios)
                .ThenInclude(c => c.Promociones)
            .FirstOrDefaultAsync(e => e.Id == id);*/

            //Para que en evento aparezcan sus comentarios
                var evento = await dbContext.Eventos
                .Include(e => e.Comentarios)
                .Include(e => e.Asistencias)
            .FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            var eventoDto = mapper.Map<EventoDto>(evento);
            eventoDto.ComentariosDto = mapper.Map<List<ComentarioDto>>(evento.Comentarios);
            eventoDto.AsistenciasDto = mapper.Map<List<AsistenciaDto>>(evento.Asistencias);
            return eventoDto;
        }

        [HttpPost("Crear un nuevo evento")]
        [Produces("application/json")]
        //public async Task<ActionResult> Post(Evento evento)
        public async Task<ActionResult> CreateEvento(CrearEventoDto creareventoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evento = mapper.Map<Evento>(creareventoDto);

            dbContext.Eventos.Add(evento);
            await dbContext.SaveChangesAsync();

            var eventoDto = mapper.Map<EventoDto>(evento);

            return CreatedAtAction(nameof(GetById), new { id = eventoDto.Id }, eventoDto);

            /*try
            {
                dbContext.Add(evento);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Hubo un error al crear un nuevo evento");
                //Aunque tambien podemos enseniarselos al usuario
                return BadRequest("Ocurrio un error inesperado, vuelve a intentarlo xc");

            }*/

        }

        [HttpPut("{id:int} Actualizar eventos")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult> Put(Evento evento, int id)
        {
            var exist = await dbContext.Eventos.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("Este evento no existe");
            }

            if (evento.Id != id)
            {
                return BadRequest("El id de este evento no existe en la url");
            }

            dbContext.Update(evento);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Eventos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado");
            }

            dbContext.Remove(new Evento { Id = id });

            /*dbContext.Remove(new Evento()
            {
                Id = id
            });*/

            await dbContext.SaveChangesAsync();
            return Ok();
        }


    }
}

