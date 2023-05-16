namespace GestionEventos.Entidades
{
    //Clase Hija
    public class RegistroAsistencia
    {
        public string Fecha { get; set; }
        // relacion de datos uno a muchos
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        // relacion de datos uno a muchos
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
