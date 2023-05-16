namespace GestionEventos.Entidades
{
    //Clase Padre
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }

        //Relacion uno a muchos
        public List <Comentario> Comentarios { get; set; }
        public ICollection<RegistroAsistencia> RegistroAsistencias { get; set; }
        //Relacion muchos a muchos
        public List<UsuarioHistorialAsistencia> HistorialAsistencia { get; set; }

    }
}
