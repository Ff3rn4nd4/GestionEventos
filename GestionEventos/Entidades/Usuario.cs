using GestionEventos.ValidacionesPersonalizadas;

namespace GestionEventos.Entidades
{
    //Clase Padre
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [ValidacionCorreo]
        public string Correo { get; set; }
        public string Contrasenia { get; set; }

        //Relacion uno a muchos
        public List <Comentario> Comentarios { get; set; }
        //public List<RegistroAsistencia> RegistroAsistencias { get; set; }
        //Relacion muchos a muchos
        public List<UsuarioHistorialAsistencia> HistorialAsistencia { get; set; }

    }
}
