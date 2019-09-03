using System.Windows.Input;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        public ICommand ForgotPasswordCommand { get; }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetField(ref _email, value); }
        }

        public ForgotPasswordViewModel()
        {
            ForgotPasswordCommand = new Command(OnForgotPasswordCommand);
        }

        private void OnForgotPasswordCommand()
        {
            System.Diagnostics.Debug.WriteLine("Forgot password");
        }
    }
}
