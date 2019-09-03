using System;
using System.Text.RegularExpressions;

namespace RegistrationApp.Validations.Rules
{
    public class PasswordRule : IValidationRule<string>
    {
        private readonly Regex passwordRegex = new Regex(@"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d).{7,11}$");

        public string ValidationMessage { get; set; }

        public PasswordRule()
        {
            ValidationMessage = "Wrong password";
        }

        public bool Check(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            var match = passwordRegex.Match(value);
            return match.Success;
        }
    }
}
