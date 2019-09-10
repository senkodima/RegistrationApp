using RegistrationApp.ViewModels;
using Xamarin.Forms;

namespace RegistrationApp.Pages
{
    public partial class TaskListPage : ContentPage
    {
        public TaskListPage()
        {
            InitializeComponent();

            BindingContext = new TaskListViewModel();
        }
    }
}
