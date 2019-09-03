using RegistrationApp.ViewModels;
using Xamarin.Forms;

namespace RegistrationApp.Pages
{
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();

            BindingContext = new ForgotPasswordViewModel();
        }
    }
}
