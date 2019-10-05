using RegistrationApp.Models;
using RegistrationApp.ViewModels;
using Xamarin.Forms;

namespace RegistrationApp.Pages
{
    public partial class TaskListPage : ContentPage
    {
        public TaskListPage(User user)
        {
            InitializeComponent();

            BindingContext = new TaskListViewModel(user);
        }
    }
}
