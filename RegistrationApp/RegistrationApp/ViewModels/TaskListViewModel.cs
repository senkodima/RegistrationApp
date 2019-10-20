using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RegistrationApp.Models;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class TaskListViewModel : BaseViewModel
    {
        public ICommand AddNewTaskCommand { get; }

        private ObservableCollection<UserTask> _userTasks;
        public ObservableCollection<UserTask> UserTasks
        {
            get { return _userTasks; }
            set { SetField(ref _userTasks, value); }
        }

        public TaskListViewModel(User user)
        {
            AddNewTaskCommand = new Command(OnAddNewTaskCommand);

            UserTasks = new ObservableCollection<UserTask>();
            UserTasks.Add(new UserTask() { Description = "test task" });
        }

        private async void OnAddNewTaskCommand()
        {
            Random random = new Random();
            UserTasks.Add(new UserTask() { Description = $"test task {random.Next()}" });
        }
    }
}
