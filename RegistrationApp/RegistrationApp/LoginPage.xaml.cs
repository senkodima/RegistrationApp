using RegistrationApp.ViewModels;
using Xamarin.Forms;

namespace RegistrationApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }
    }
}

