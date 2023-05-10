﻿using GestionEventos.Entidades;
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

        [HttpGet]
        public async Task<ActionResult<List<Evento>>> Get()
        {
            return await dbContext.Eventos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento evento)
        {
            dbContext.Add(evento);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        
    }
}