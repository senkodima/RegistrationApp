using System;
using System.Windows.Input;
using RegistrationApp.Models;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class UserTaskViewModel : BaseViewModel
    {
        public ICommand DeleteTaskCommand { get; }

        private UserTask _userTask;
        private TaskListViewModel _parrentViewModel;

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetField(ref _description, value); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { SetField(ref _date, value); }
        }

        public UserTaskViewModel(UserTask userTask, TaskListViewModel taskListViewModel)
        {
            DeleteTaskCommand = new Command(OnDeleteTaskCommand);
            _parrentViewModel = taskListViewModel;

            _userTask = userTask;
            Description = userTask.Description;
            Date = userTask.Date;
        }

        private async void OnDeleteTaskCommand()
        {
            if (await Application.Current.MainPage.DisplayAlert(
                "Do you want to delete?", _userTask.Description, "OK", "Cancel"))
            {
                await App.UserDatabase.DeleteUserTaskAsync(_userTask);

                _parrentViewModel.UserTasks.Remove(this);
            }

        }
    }
}
