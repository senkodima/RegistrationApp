using System;
namespace RegistrationApp.Validations.Rules
{
    public class IsNotNullOrEmptyRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        public IsNotNullOrEmptyRule()
        {
            ValidationMessage = "Entry cannot be empty!";
        }

        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
