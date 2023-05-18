namespace GestionEventos.Entidades
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public  string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        //Relaciones Uno a muchos 
        public List<Promocion> Promociones { get; set; }
        public List<Asistencia> Asistencias { get; set; }

        //Relacion Uno a Muchos como Entidad Padre
        public List<Comentario> Comentarios { get; set; }

    }
}
