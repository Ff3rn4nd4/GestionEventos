namespace GestionEventos.Entidades
{
    public class Favorito
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
