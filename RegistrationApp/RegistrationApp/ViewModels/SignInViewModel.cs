using System.Linq;
using System.Windows.Input;
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

        User user;

        public SignInViewModel()
        {
            LoginCommand = new Command(OnLoginCommand);
            ForgotPasswordCommand = new Command(OnForgotPasswordCommand);

            user = new User()
            {
                Email = "test@test.com",
                Password = "123qweASD"
            };

            Email = new ValidatableObject<string>
            {
                Value = user.Email, // FOR TEST
                ValidationsRules =
                {
                    new IsNotNullOrEmptyRule(),
                    new EmailRule()
                }
            };

            Password = new ValidatableObject<string>
            {
                Value = user.Password, // FOR TEST
                ValidationsRules =
                {
                    new IsNotNullOrEmptyRule(),
                    new PasswordRule()
                }
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
                Application.Current.MainPage.DisplayAlert("ERROR", errorMessage, "OK");
                return;
            }

            if (!Email.Value.Equals(user.Email) || !Password.Value.Equals(user.Password))
            {
                Application.Current.MainPage.DisplayAlert("ERROR", "BAD INPUT", "OK");
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new TaskListPage());
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



public class Test
{

    public static bool TestFunc(int x) => x == 0;

    public static bool TestFunc1(int c)
    {
        return c == 0;
    }

}