namespace GestionEventos.Entidades
{
    //Clase Padre
    public class HistorialAsistencia
    {
        public string Id { get; set; }
        public string Fecha { get; set; }

        //Relacion uno a muchos 
        public List<Evento> eventos { get; set; }
    }
}
