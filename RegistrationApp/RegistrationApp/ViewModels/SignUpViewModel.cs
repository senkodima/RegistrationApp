using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using RegistrationApp.Autorization;
using RegistrationApp.Models;
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

        private ValidatableObject<string> _confirmPassword;
        public ValidatableObject<string> ConfirmPassword
        {
            get { return _confirmPassword; }
            set { SetField(ref _confirmPassword, value); }
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
                    new EmailRule(),
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

            ConfirmPassword = new ValidatableObject<string>
            {
                ValidationsRules =
                {
                    new IsNotNullOrEmptyRule(),
                    new PasswordRule(),
                    new ConfirmPasswordRule(() => Password.Value)
                }
            };
        }

        private async void OnAddPhoto()
        {
            System.Diagnostics.Debug.WriteLine("Add photo");


            #region FOR DEBUG
            List<User> _testAllUsersList = await App.UserDatabase.GetAllUsersAsync();
            List<UserTask> _testAllUserTasksList = await App.UserDatabase.GetAllUserTasksAsync();

            foreach (User user in _testAllUsersList)
            {
                System.Diagnostics.Debug.WriteLine($"------------------------------------");
                System.Diagnostics.Debug.WriteLine($"User info : {user.ToString()}");
                var _testUserTasksList = _testAllUserTasksList.Where(ut => ut.UserID == user.ID);
                foreach (UserTask userTask in _testUserTasksList)
                {
                    System.Diagnostics.Debug.WriteLine($"UserTasks info : {userTask.ToString()}");
                }
                System.Diagnostics.Debug.WriteLine($"------------------------------------");
            }

            //System.Diagnostics.Debug.WriteLine($"-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$");

            //foreach (UserTask userTask in _testAllUserTasksList)
            //{
            //    System.Diagnostics.Debug.WriteLine($"UserTasks info : {userTask.ToString()}");
            //}
            #endregion
        }

        private async void OnCreateAccauntCommand()
        {
            System.Diagnostics.Debug.WriteLine("Create accaunt");

            if (!Email.Validate() || !Password.Validate() || !ConfirmPassword.Validate())
            {
                var errorMessage = string.Empty;
                if (Email.ErrorsMessages.Any())
                {
                    errorMessage = Email.ErrorsMessages.First();
                }
                else if (Password.ErrorsMessages.Any())
                {
                    errorMessage = Password.ErrorsMessages.First();
                }
                else
                {
                    errorMessage = ConfirmPassword.ErrorsMessages.First();
                }
                Application.Current.MainPage.DisplayAlert("ERROR", errorMessage, "OK");
                return;
            }

            var _newUser = new User(Email.Value, FirstName, LastName, Password.Value, Phone);

            AutorizationService.SignUpUserAsync(_newUser);
        }

    }
}
