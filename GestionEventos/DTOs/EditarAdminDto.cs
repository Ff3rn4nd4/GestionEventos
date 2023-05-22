using System.ComponentModel.DataAnnotations;

namespace GestionEventos.DTOs
{
    public class EditarAdminDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
