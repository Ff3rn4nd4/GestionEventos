using GestionEventos.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionEventos.DTOs
{
    public class AsistenciaDto
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        //Validaciones Personalizadas
        [Required]
        //Relacion uno a muchos 
        public int EventoId { get; set; }
        [JsonIgnore]
        public Evento Evento { get; set; }
    }
}
