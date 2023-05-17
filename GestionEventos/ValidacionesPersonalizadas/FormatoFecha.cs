using System.ComponentModel.DataAnnotations;

namespace GestionEventos.ValidacionesPersonalizadas
{
    public class FormatoFecha: ValidationAttribute
    {
        private const string FormatoCorrecto = "dd/MM/yyyy";

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            DateTime fecha;
            if (!DateTime.TryParseExact(value.ToString(), FormatoCorrecto, null, System.Globalization.DateTimeStyles.None, out fecha))
            {
                return false;
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"El campo {name} debe tener formato dd/mm/aaaa";
        }
    }
}
