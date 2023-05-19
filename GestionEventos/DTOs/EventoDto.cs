namespace GestionEventos.DTOs
{
    public class EventoDto
    {
        //DTO de consumo, ya que solo le vamos a enviar datos al cliente
        //Que son los que recoje a la hora de hacer un nuevo evento

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        //Esta a su vez sera una Dto para cargar relaciones
        //Ya que esta es la entidad principal por ello hay muchas otras que estan relacionadas
        //directamente con ella

        public List<AsistenciaDto> Asistencias { get; set; }
        public List<ComentarioDto> Comentarios { get; set; }
        public List<PromocionDto> Promociones { get; set; }
    }
}
