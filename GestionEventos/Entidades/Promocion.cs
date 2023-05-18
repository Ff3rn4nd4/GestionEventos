using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEventos.Entidades
{
    public class Promocion
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Descuento { get; set; }

        //Relacion uno a muchos
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

    }
}
