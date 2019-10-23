using System.Linq;
using RegistrationApp.Models;
using RegistrationApp.Pages;
using Xamarin.Forms;

namespace RegistrationApp.Autorization
{
    public static class AutorizationService
    {
        private static User _currentUser;

        public static bool CheckEmailUniqueness(string value)
        {
            var users = App.UserDatabase.GetAllUsersAsync().Result;
            return (users.Where(u => u.Email == value)
                        .FirstOrDefault() == null);
        }

        public static async void SignUpUserAsync(User user)
        {
            if (CheckEmailUniqueness(user.Email))
            {
                await App.UserDatabase.SaveUserAsync(user);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("ERROR", "Email already exists", "OK");
            }
        }

        public static bool CheckUserCredentials(User user)
        {
            var users = App.UserDatabase.GetAllUsersAsync().Result;
            _currentUser = users.Where(u => u.Email == user.Email
                                         && u.Password == user.Password)
                                        .FirstOrDefault();
            
            return _currentUser != null;
        }

        public static async void SignInUserAsync(User user)
        {
            if (CheckUserCredentials(user))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new TaskListPage(_currentUser));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("ERROR", "BAD CREDENTIALS", "OK");
            }
        }
    }
}
