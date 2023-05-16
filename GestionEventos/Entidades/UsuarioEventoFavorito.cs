namespace GestionEventos.Entidades
{
    public class UsuarioEventoFavorito
    {
        public int Id { get; set; }

        //Relacion Muchos a Muchos
        //Clave foranea de ambas entidades
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
    }
}
