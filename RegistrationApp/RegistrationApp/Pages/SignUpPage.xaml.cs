using RegistrationApp.ViewModels;
using Xamarin.Forms;

namespace RegistrationApp
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();

            BindingContext = new SignUpViewModel();
        }
    }
}