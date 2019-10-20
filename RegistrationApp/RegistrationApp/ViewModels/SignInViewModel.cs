using System.Linq;
using System.Windows.Input;
using RegistrationApp.Autorization;
using RegistrationApp.Models;
using RegistrationApp.Pages;
using RegistrationApp.Validations;
using RegistrationApp.Validations.Rules;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get { return _email; }
            set { SetField(ref _email, value); }
        }

        private ValidatableObject<string> _password;
        public ValidatableObject<string> Password
        {
            get { return _password; }
            set { SetField(ref _password, value); }
        }

        public SignInViewModel()
        {
            LoginCommand = new Command(OnLoginCommand);
            ForgotPasswordCommand = new Command(OnForgotPasswordCommand);

            Email = new ValidatableObject<string>
            {
                ValidationsRules =
                {
                    new IsNotNullOrEmptyRule(),
                    new EmailRule()
                },
                /*FOR TEST*/ Value = "Test@test.com"
            };

            Password = new ValidatableObject<string>
            {
                ValidationsRules =
                {
                    new IsNotNullOrEmptyRule(),
                    new PasswordRule()
                },
                /*FOR TEST*/ Value = "123qweASD"
            };
        }

        private async void OnLoginCommand()
        {
            System.Diagnostics.Debug.WriteLine("Login");

            if (!Email.Validate() || !Password.Validate())
            {
                var errorMessage = string.Empty;
                if (Email.ErrorsMessages.Any())
                {
                    errorMessage = Email.ErrorsMessages.First();
                }
                else
                {
                    errorMessage = Password.ErrorsMessages.First();
                }
                await Application.Current.MainPage.DisplayAlert("ERROR", errorMessage, "OK");
                return;
            }

            var _newUser = new User(Email.Value, Password.Value);

            AutorizationService.SignInUserAsync(_newUser);
        }

        private async void OnForgotPasswordCommand()
        {
            System.Diagnostics.Debug.WriteLine("Forgot password");

            await Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage());

            var pages = Application.Current.MainPage.Navigation.NavigationStack.ToList();
            foreach (var page in pages)
            {
                if (page != Application.Current.MainPage.Navigation.NavigationStack.First()
                    && page != Application.Current.MainPage.Navigation.NavigationStack.Last())
                    Application.Current.MainPage.Navigation.RemovePage(page);
            }
        }
    }
}