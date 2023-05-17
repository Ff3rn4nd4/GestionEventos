using System.ComponentModel.DataAnnotations;

namespace GestionEventos.Entidades
{
    //Clase Hija
    public class Promocion
    {
        public string Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Range(100,500, ErrorMessage = "No existe este descuento")]
        public int Descuento { get; set; }

        // relacion de datos uno a muchos
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

    }
}
