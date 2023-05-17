namespace GestionEventos.Entidades
{
    //Clase Hija
    public class Comentario
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Texto { get; set; }

        // Relacion de datos uno a muchos
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

    }
}
