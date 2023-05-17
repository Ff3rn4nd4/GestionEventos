using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GestionEventos.ValidacionesPersonalizadas
{
    public class ValidacionCorreo : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var Correo = value.ToString();

            if (string.IsNullOrWhiteSpace(Correo))
                return true;

            try
            {
                var addr = new System.Net.Mail.MailAddress(Correo);
                return addr.Address == Correo && Regex.IsMatch(Correo, @"^[^@]+@[^@]+\.[^@]+\.com$");
            }
            catch
            {
                return false;
            }
        }
    }
}
