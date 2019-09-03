using System.Windows.Input;
using RegistrationApp.Validations;
using RegistrationApp.Validations.Rules;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        public ICommand ForgotPasswordCommand { get; }

        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get { return _email; }
            set { SetField(ref _email, value); }
        }

        public ForgotPasswordViewModel()
        {
            ForgotPasswordCommand = new Command(OnForgotPasswordCommand);

            Email = new ValidatableObject<string>
            {
                ValidationsRules =
                {
                    new IsNotNullOrEmptyRule(),
                    new EmailRule()
                }
            };
        }

        private void OnForgotPasswordCommand()
        {
            System.Diagnostics.Debug.WriteLine("Forgot password");

            if (!Email.Validate())
            {
                Application.Current.MainPage.DisplayAlert("ERROR", Email.ErrorsMessages[0], "OK");
            }
        }
    }
}
