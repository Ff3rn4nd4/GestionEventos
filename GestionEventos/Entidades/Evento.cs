namespace GestionEventos.Entidades
{
    //Clase Padre
    public class Evento
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public  string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        //Relaciones Uno a Muchos
        public ICollection<RegistroAsistencia> RegistroAsistencias { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public List<Promocion> Promociones { get; set; }

        //Relacion muchos a muchos
        public List<UsuarioHistorialAsistencia> UsuarioHistorialAsistencias { get; set; }

    }
}
