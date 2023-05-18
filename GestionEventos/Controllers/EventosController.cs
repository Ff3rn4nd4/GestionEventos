using GestionEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Controllers
{
    //validaciones automaticas/por defecto
    [ApiController]

    //ruta
    [Route("api/eventos")]

    public class EventosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        //Implementando Log de errores
        private readonly ILogger<EventosController> logger;

        public EventosController(ApplicationDbContext context, ILogger<EventosController> logger) 
        {
            dbContext = context;
            //Ahora se puede aplicar a cualquier metodo del CRUD
            this.logger = logger;
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
        public async Task<ActionResult<Evento>> GetById(int id)
        {
            var evento = await dbContext.Eventos
            .Include(e => e.Comentarios)
            .FirstOrDefaultAsync(e => e.Id == id);

            return await dbContext.Eventos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento evento)
        {
            try
            {
                dbContext.Add(evento);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"Hubo un error al crear un nuevo evento");
                //Aunque tambien podemos enseniarselos al usuario
                return BadRequest("Ocurrio un error inesperado, vuelve a intentarlo xc");

            }
            
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Evento evento, int id)
        {
            var exist = await dbContext.Eventos.AnyAsync( x => x.Id == id);
            
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
