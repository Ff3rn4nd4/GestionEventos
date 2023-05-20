using System.ComponentModel.DataAnnotations;
using GestionEventos.Entidades;

namespace GestionEventos.ValidacionesPersonalizadas
{
    public class LimiteCapacidad : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is not Evento evento)
            {
                return new ValidationResult(ErrorMessage);
            }

            if (evento.Asistencias.Count >= evento.Capacidad)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
