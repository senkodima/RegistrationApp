using System.Windows.Input;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginCommand);
            SignUpCommand = new Command(OnSignUpCommand);
        }

        private void OnLoginCommand()
        {
            System.Diagnostics.Debug.WriteLine("Login");
        }

        private async void OnSignUpCommand()
        {
            System.Diagnostics.Debug.WriteLine("SignUp");
            await Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }
    }
}
