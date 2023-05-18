
namespace GestionEventos.Services
{
    //El servicio IHostedService, sirve para tareas en segundo plano
    //En nuestro caso cuando se esta ejecutando nuestra api
    public class EscribirEnArchivo: IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string nomArchivo = "Michu.txt";
        private Timer timer;

        public EscribirEnArchivo(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(Dowork, null, TimeSpan.Zero, TimeSpan.FromMinutes(3));
            Escribir("Proceso Iniciado");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            Escribir("Proceso Finalizado");
            return Task.CompletedTask;
        }
        private void Dowork(object state)
        {
            //El formato que quiere que aparezca
            Escribir("Proceso en ejecucion:" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }

        private void Escribir(string msg)
        {
            var ruta = Path.Combine(env.WebRootPath, nomArchivo);

            using (StreamWriter writer = new StreamWriter(ruta, append: true))
            {
                writer.WriteLine(msg);
            }
        }
    }
}
