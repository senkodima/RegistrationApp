using System.Windows.Input;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetField(ref _email, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetField(ref _password, value); }
        }

        public SignInViewModel()
        {
            LoginCommand = new Command(OnLoginCommand);
            ForgotPasswordCommand = new Command(OnForgotPasswordCommand);
        }

        private void OnLoginCommand()
        {
            System.Diagnostics.Debug.WriteLine("Login");
        }

        private void OnForgotPasswordCommand()
        {
            System.Diagnostics.Debug.WriteLine("Forgot password");
        }
    }
}
