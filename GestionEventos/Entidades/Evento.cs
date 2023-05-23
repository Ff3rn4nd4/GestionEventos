using GestionEventos.ValidacionesPersonalizadas;
using System.ComponentModel.DataAnnotations;

namespace GestionEventos.Entidades
{
    public class Evento
    {
        //Aqui guarda la asistencia
        public Evento()
        {
            Asistencias = new List<Asistencia>();
        }
        public int Id { get; set; }
        //Validaciones por modelo
        [Required]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        //public DateTime Fecha { get; set; }
        //Validaciones por modelo
        [Required]
        public string Hora { get; set; }
        //Validaciones por modelo
        [Required]
        public  string Ubicacion { get; set; }
        //Validaciones personalizadas
        [Required]
        [LimiteCapacidad(ErrorMessage = "Se ha alcanzado el límite de capacidad del evento.")]
        public int Capacidad { get; set; }

        //Relaciones Uno a muchos 
        public List<Promocion> Promociones { get; set; }

        public List<Asistencia> Asistencias { get; set; }

        //Relacion Uno a Muchos como Entidad Padre
        public List<Comentario> Comentarios { get; set; }


    }
}
