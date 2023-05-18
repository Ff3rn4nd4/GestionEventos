using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestionEventos.Filtros

{
    public class FiltroExcepcion: ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroExcepcion> logger;

        public FiltroExcepcion(ILogger<FiltroExcepcion> logger) 
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, "Ocurrió un error en la solicitud.");

            //Mensaje de error por parte del json
            var resultado = new JsonResult(new { error = "Ocurrió un error en la solicitud." })
            {
                //nomas porque no me se otro codigo de error chido
                StatusCode = 404 
            };

            context.Result = resultado;
        }
    }
}
