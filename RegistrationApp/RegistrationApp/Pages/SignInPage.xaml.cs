using RegistrationApp.ViewModels;
using Xamarin.Forms;

namespace RegistrationApp
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();

            BindingContext = new SignInViewModel();
        }
    }
}
