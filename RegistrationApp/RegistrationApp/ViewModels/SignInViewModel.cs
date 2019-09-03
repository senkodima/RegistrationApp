using System.Windows.Input;
using RegistrationApp.Pages;
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

        private async void OnForgotPasswordCommand()
        {
            System.Diagnostics.Debug.WriteLine("Forgot password");
            await Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage());
            /* CLEAR NAVIGATION STACK */
            //var pages = Application.Current.MainPage.Navigation.NavigationStack.ToList();
            //foreach (var page in pages)
            //{
            //    if (page.GetType() != typeof(StartUpPage))
            //        Application.Current.MainPage.Navigation.RemovePage(page);
            //}
        }
    }
}
