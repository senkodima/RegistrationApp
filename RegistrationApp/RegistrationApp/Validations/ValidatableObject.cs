using System.Linq;
using System.Collections.Generic;
using RegistrationApp.Validations.Rules;
using RegistrationApp.ViewModels;

namespace RegistrationApp.Validations
{
    public class ValidatableObject<T> : BaseViewModel, IValidity
    {
        private T _value;
        public T Value
        {
            get { return _value; }
            set { SetField(ref _value, value); }
        }

        private List<string> _errorsMessages;
        public List<string> ErrorsMessages
        {
            get { return _errorsMessages; }
            set { SetField(ref _errorsMessages, value); }
        }

        public List<IValidationRule<T>> ValidationsRules { get; }

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set { SetField(ref _isValid, value); }
        }

        public ValidatableObject()
        {
            _isValid = true;
            ErrorsMessages = new List<string>();
            ValidationsRules = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            var errors = ValidationsRules.Where(r => !r.Check(Value)).Select(r => r.ValidationMessage);
            ErrorsMessages = errors.ToList();
            IsValid = !ErrorsMessages.Any();

            return IsValid;
        }
    }
}
