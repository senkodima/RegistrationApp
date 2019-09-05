namespace RegistrationApp.Validations.Rules
{
    public interface IValidationRule<T>
    {
        bool Check(T value);
        string ValidationMessage { get; set; }
    }
}
