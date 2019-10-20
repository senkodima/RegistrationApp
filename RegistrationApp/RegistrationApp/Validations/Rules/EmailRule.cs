using System.Text.RegularExpressions;

namespace RegistrationApp.Validations.Rules
{
    public class EmailRule : IValidationRule<string>
    {
        private readonly Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public string ValidationMessage { get; set; }

        public EmailRule()
        {
            ValidationMessage = "Wrong email";
        }

        public bool Check(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            var match = emailRegex.Match(value);
            return match.Success;
        }
    }
}
