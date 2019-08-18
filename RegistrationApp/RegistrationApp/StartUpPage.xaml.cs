using RegistrationApp.ViewModels;
using Xamarin.Forms;

namespace RegistrationApp
{
    public partial class StartUpPage : ContentPage
    {
        public StartUpPage()
        {
            InitializeComponent();

            BindingContext = new StartUpViewModel();
        }
    }
}

