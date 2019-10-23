﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RegistrationApp.Models;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class TaskListViewModel : BaseViewModel
    {
        public ICommand AddNewTaskCommand { get; }

        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set { SetField(ref _currentUser, value); }
        }

        private ObservableCollection<UserTask> _userTasks;
        public ObservableCollection<UserTask> UserTasks
        {
            get { return _userTasks; }
            set { SetField(ref _userTasks, value); }
        }

        public TaskListViewModel(User user)
        {
            AddNewTaskCommand = new Command(OnAddNewTaskCommand);

            CurrentUser = user;

            var allTasks = App.UserDatabase.GetAllUserTasksAsync().Result;
            CurrentUser.Tasks = (allTasks.Where(ut => ut.UserID == CurrentUser.ID))
                                            .ToList();

            UserTasks = new ObservableCollection<UserTask>();
            foreach (UserTask ut in CurrentUser.Tasks)
            {
                UserTasks.Add(ut);
            }
        }

        private async void OnAddNewTaskCommand()
        {
            Random random = new Random();
            var _newUserTask = new UserTask()
            {
                Description = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} test task {random.Next()}",
                Date = DateTime.Now
            };

            App.UserDatabase.SaveUserTaskAsync(_newUserTask);

            CurrentUser.Tasks.Add(_newUserTask);
            App.UserDatabase.UpdateUserAsync(CurrentUser);

            UserTasks.Add(_newUserTask);
        }
    }
}
