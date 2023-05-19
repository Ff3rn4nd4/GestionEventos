using System.ComponentModel.DataAnnotations;

namespace GestionEventos.DTOs
{
    public class CrearEvento
    {
        //DTO de creacion, ya que son los datos que el cliente le va a enviar al servidor
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public string Fecha { get; set; }
        [Required]
        public string Hora { get; set; }
        [Required]
        public string Ubicacion { get; set; }
        [Required]
        public int Capacidad { get; set; }
    }
}
