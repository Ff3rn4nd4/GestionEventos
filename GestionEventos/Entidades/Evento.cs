using GestionEventos.ValidacionesPersonalizadas;
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
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        [Required]
        public string Hora { get; set; }
        [Required]
        public  string Ubicacion { get; set; }
        [Required]
        public int Capacidad { get; set; }

        //Relaciones Uno a muchos 
        public List<Promocion> Promociones { get; set; }

        public List<Asistencia> Asistencias { get; set; }

        //Relacion Uno a Muchos como Entidad Padre
        public List<Comentario> Comentarios { get; set; }

    }
}
