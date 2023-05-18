using GestionEventos.ValidacionesPersonalizadas;
using System.ComponentModel.DataAnnotations;

namespace GestionEventos.Entidades
{
    public class Asistencia
    {
        public int Id { get; set; }
        public string Fecha { get; set; }

        //Relacion uno a muchos 
        [Required]
        [LimiteCapacidad(ErrorMessage = "La cantidad de asistentes excede la capacidad del evento")]
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

    }
}
