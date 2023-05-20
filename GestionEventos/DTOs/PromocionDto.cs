using GestionEventos.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionEventos.DTOs
{
    public class PromocionDto
    {
        //Tambien podriamos considerar esta como una DTO de consumo 
        //Ya que guarda la info que el usuario le proporciona
        public int Id { get; set; }
        public string Codigo { get; set; }
        [Range(100, 500, ErrorMessage = "El descuento debe estar entre 100 y 500")]
        public int Descuento { get; set; }
        //Relacion uno a muchos
        public int EventoId { get; set; }
        [JsonIgnore]
        public Evento Evento { get; set; }
    }
}
