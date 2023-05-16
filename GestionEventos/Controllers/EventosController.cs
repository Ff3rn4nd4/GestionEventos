using GestionEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Controllers
{
    //validaciones automaticas
    [ApiController]

    //ruta
    [Route("api/eventos")]

    public class EventosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EventosController(ApplicationDbContext context) 
        {
            this.dbContext = context;
        }
        //metodo get con Datos Dummy

        /* Datos dummy 
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
            return await dbContext.Eventos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Evento>> GetById(int id)
        {
            return await dbContext.Eventos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Evento>>> Get()
        {
            return await dbContext.Eventos.Include(x => x.Comentarios).ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Post(Evento evento)
        {
            var existeEvento = await dbContext.Eventos.AnyAsync(x => x.Id ==  evento.Id);

            if (!existeEvento)
            {
                return BadRequest($"No existe algun evento con esa id: {evento.Id} ");
            }

            dbContext.Add(evento);
            await dbContext.SaveChangesAsync();
            return Ok();
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
