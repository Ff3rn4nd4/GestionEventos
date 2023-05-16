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

        //Relacion muchos a muchos
        public List<UsuarioHistorialAsistencia> usuarioHistorialAsistencias { get; set; }

        //Relaciones Uno a Muchos
        public List<RegistroAsistencia> registroAsistencias { get; set; }
        public List<Comentario> comentarios { get; set; }
        public List<Promocion> promociones { get; set; }

    }
}
