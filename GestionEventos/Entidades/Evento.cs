using System.ComponentModel.DataAnnotations;

namespace GestionEventos.Entidades
{
    public class Evento
    {
        public Evento()
        {
            Asistencias = new List<Asistencia>();
        }

        public int Id { get; set; }
        //Validaciones por modelo
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        //Validaciones por modelo
        [Required]
        public string Hora { get; set; }
        //Validaciones por modelo
        [Required]
        public  string Ubicacion { get; set; }
        //Validaciones por modelo
        [Required]
        public int Capacidad { get; set; }

        //Relaciones Uno a muchos 
        public List<Promocion> Promociones { get; set; }

        public List<Asistencia> Asistencias { get; set; }

        //Relacion Uno a Muchos como Entidad Padre
        public List<Comentario> Comentarios { get; set; }

    }
}
