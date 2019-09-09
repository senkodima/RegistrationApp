using System;
namespace RegistrationApp.Validations.Rules
{
    public class ConfirmPasswordRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        private Func<string> _confirmMethod;

        public ConfirmPasswordRule(Func<string> getPassword)
        {
            ValidationMessage = "Passwords don't match";
            _confirmMethod = getPassword;
        }

        delegate ValidatableObject<string> ValuePass();

        public bool Check(string value)
        {
            return string.Equals(_confirmMethod?.Invoke(), value);
        }
    }
}
