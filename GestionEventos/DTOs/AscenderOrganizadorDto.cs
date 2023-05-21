using System.ComponentModel.DataAnnotations;

namespace GestionEventos.DTOs
{
    public class AscenderOrganizadorDto
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
    }
}
