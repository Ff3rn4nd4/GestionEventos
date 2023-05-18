namespace GestionEventos.Entidades
{
    public class Asistencia
    {
        public int Id { get; set; }
        public string Fecha { get; set; }

        //Relacion uno a muchos 
        public List<Evento> Eventos { get; set; }
    }
}
