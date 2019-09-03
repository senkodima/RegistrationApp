using System.Linq;
using System.Windows.Input;
using RegistrationApp.Validations;
using RegistrationApp.Validations.Rules;
using Xamarin.Forms;

namespace RegistrationApp.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public ICommand AddPhotoCommand { get; }
        public ICommand CreateAccauntCommand { get; }

        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
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

        private ValidatableObject<string> _password;
        public ValidatableObject<string> Password
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

            Email = new ValidatableObject<string>
            {
                ValidationsRules =
                {
                    new IsNotNullOrEmptyRule(),
                    new EmailRule()
                }
            };

            Password = new ValidatableObject<string>
            {
                ValidationsRules =
                {
                    new IsNotNullOrEmptyRule(),
                    new PasswordRule()
                }
            };
        }

        private async void OnAddPhoto()
        {
            System.Diagnostics.Debug.WriteLine("Add photo");
        }

        private void OnCreateAccauntCommand()
        {
            System.Diagnostics.Debug.WriteLine("Create accaunt");

            if (!Email.Validate() || !Password.Validate())
            {
                var errorMessage = string.Empty;
                if (Email.ErrorsMessages.Any())
                {
                    errorMessage = Email.ErrorsMessages.First();
                }
                else
                {
                    errorMessage = Password.ErrorsMessages.First();
                }
                Application.Current.MainPage.DisplayAlert("ERROR", errorMessage, "OK");
            }
        }

    }
}
