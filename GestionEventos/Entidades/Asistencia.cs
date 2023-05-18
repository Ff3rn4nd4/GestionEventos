namespace GestionEventos.Entidades
{
    public class Asistencia
    {
        public int Id { get; set; }
        public string Fecha { get; set; }

        //Relacion uno a muchos 

        public int EventoId { get; set; }
        public Evento Evento { get; set; }

    }
}
