using GestionEventos.ValidacionesPersonalizadas;
using System.ComponentModel.DataAnnotations;

namespace GestionEventos.DTOs
{
    public class EventoDto
    {
        public int Id { get; set; }
        //Validaciones por modelo
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        //Validaciones por modelo
        [Required]
        public string Hora { get; set; }
        //Validaciones por modelo
        [Required]
        public string Ubicacion { get; set; }
        //Validaciones personalizadas
        [Required]
        public int Capacidad { get; set; }
        public List<ComentarioDto> ComentariosDto { get; set; }
        public List<AsistenciaDto> AsistenciasDto { get; set; }
        public List<PromocionDto> PromocionesDto { get; set; }

    }
}
