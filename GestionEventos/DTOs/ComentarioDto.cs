using GestionEventos.Entidades;
using System.Text.Json.Serialization;

namespace GestionEventos.DTOs
{
    public class ComentarioDto
    {
        //Tambien podriamos considerar esta como una DTO de consumo 
        //Ya que guarda la info que el usuario le proporciona

        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Texto { get; set; }
        // Relacion de datos uno a muchos
        public int EventoId { get; set; }
        [JsonIgnore]
        public Evento Evento { get; set; }

    }
}
