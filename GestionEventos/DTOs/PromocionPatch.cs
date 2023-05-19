namespace GestionEventos.DTOs
{
    public class PromocionPatch
    {
        //Dto patch
        public int Id { get; set; }
        public string Codigo { get; set; }
        //Usamos el ? para indicarle al programa que este dato puede ser nulo
        public int? Descuento { get; set; }
    }
}
