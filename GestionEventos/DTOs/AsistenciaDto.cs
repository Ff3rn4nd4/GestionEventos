namespace GestionEventos.DTOs
{
    public class AsistenciaDto
    {
        //Tambien podriamos considerar esta como una DTO de consumo 
        //Ya que guarda la info que el usuario le proporciona
        public int Id { get; set; }
        public string Fecha { get; set; }
    }
}
