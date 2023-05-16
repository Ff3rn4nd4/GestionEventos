namespace GestionEventos.Entidades
{
    public class UsuarioEventoFavorito
    {
        //Relacion Muchos a Muchos
        //Clave foranea de ambas entidades
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
    }
}
