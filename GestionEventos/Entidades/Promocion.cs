namespace GestionEventos.Entidades
{
    //Clase Hija
    public class Promocion
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public int Descuento { get; set; }

        // relacion de datos uno a muchos
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

    }
}
