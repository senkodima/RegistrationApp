using System.Collections.Generic;
using RegistrationApp.Models;

namespace RegistrationApp.ViewModels
{
    public class TaskListViewModel : BaseViewModel
    {
        private List<string> _taskList;
        public List<string> TaskList
        {
            get { return _taskList; }
            set { SetField(ref _taskList, value); }
        }

        User user;

        public TaskListViewModel()
        {
            user = new User()
            {
                TaskList = new List<string> { "value 1", "value 2", "value 3", "value 4", "value 5" }
            };
            TaskList = user.TaskList;
        }
    }
}
