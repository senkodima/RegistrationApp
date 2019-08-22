using System.Windows.Input;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class StartUpViewModel : BaseViewModel
    {
        public ICommand SignInCommand { get; }
        public ICommand SignUpCommand { get; }

        public StartUpViewModel()
        {
            SignInCommand = new Command(OnSignInCommand);
            SignUpCommand = new Command(OnSignUpCommand);
        }

        private async void OnSignInCommand()
        {
            System.Diagnostics.Debug.WriteLine("SignIn");
            await Application.Current.MainPage.Navigation.PushAsync(new SignInPage());
        }

        private async void OnSignUpCommand()
        {
            System.Diagnostics.Debug.WriteLine("SignUp");
            await Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }
    }
}