namespace RegistrationApp.ViewModels
{
    public class TaskListViewModel : BaseViewModel
    {
        private string[] _taskList;
        public string[] TaskList
        {
            get { return _taskList; }
            set { SetField(ref _taskList, value); }
        }

        public TaskListViewModel()
        {
            TaskList = new string[] { "value 1", "value 2", "value 3", "value 4", "value 5" };
        }
    }
}
