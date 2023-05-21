namespace GestionEventos.DTOs
{
    public class RespuestaAutenticacionDto
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
