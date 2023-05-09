using GestionEventos.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace GestionEventos.Controllers
{
    //validaciones automaticas
    [ApiController]

    public class EventosController: ControllerBase
    {
        //metodo get con Datos Dummy
         [HttpGet]

        //ruta
        [Route("api/eventos")]

         public ActionResult <List<Evento>> Get() 
         {
             return new List<Evento>()
             {
                 new Evento() { Id= 1, Nombre="Cumpleanios Francisco", Descripcion="Fiesta infantil", Fecha="3 de Octubre", Hora= "8 pm",Ubicacion="Monterrey", 
                 Capacidad=100},
                 new Evento() { Id=2, Nombre="Cumpleanios Dan", Descripcion="Fiesta de cumpleanios", Fecha="2 de Diciembre", Hora= "10 pm",Ubicacion="Monterrey",
                 Capacidad=150 }
             };
         }
    }
}
