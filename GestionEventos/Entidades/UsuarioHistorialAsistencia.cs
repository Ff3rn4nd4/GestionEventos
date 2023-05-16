namespace GestionEventos.Entidades
{
    public class UsuarioHistorialAsistencia
    {
        public int HistorialAsistenciaId { get; set; }
        public HistorialAsistencia HistorialAsistencia { get; set; }

        public int UsuarioId { get; set;}
        public Usuario Usuario { get; set;}
    }
}
