using System.Windows.Input;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public ICommand AddPhotoCommand { get; }
        public ICommand CreateAccauntCommand { get; }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetField(ref _email, value); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetField(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetField(ref _lastName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetField(ref _password, value); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { SetField(ref _phone, value); }
        }

        public SignUpViewModel()
        {
            AddPhotoCommand = new Command(OnAddPhoto);
            CreateAccauntCommand = new Command(OnCreateAccauntCommand);
        }

        private void OnAddPhoto()
        {
            System.Diagnostics.Debug.WriteLine("Add photo");
        }

        private void OnCreateAccauntCommand()
        {
            System.Diagnostics.Debug.WriteLine("Create accaunt");
        }
    }
}
