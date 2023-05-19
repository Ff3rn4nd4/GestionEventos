namespace GestionEventos.DTOs
{
    public class PromocionDto
    {
        //Tambien podriamos considerar esta como una DTO de consumo 
        //Ya que guarda la info que el usuario le proporciona
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Descuento { get; set; }
    }
}
