using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GestionEventos.Entidades;

namespace GestionEventos.ValidacionesPersonalizadas
{
    public class LimiteCapacidad : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var evento = validationContext.ObjectInstance as Evento;
            if (evento == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            if (evento.Asistencias.Count > evento.Capacidad)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
