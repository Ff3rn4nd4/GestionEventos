using System.ComponentModel.DataAnnotations;

namespace GestionEventos.Entidades
{
    public class Promocion
    {
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Range(100, 500, ErrorMessage = "El descuento debe estar entre 100 y 500")]
        public int Descuento { get; set; }

        //Relacion uno a muchos
        public int EventoId { get; set; }
        public Evento Evento { get; set; }



    }
}
