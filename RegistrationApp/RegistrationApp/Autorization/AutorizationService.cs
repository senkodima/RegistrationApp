using System.Collections.Generic;
using System.Linq;
using RegistrationApp.Models;
using RegistrationApp.Pages;
using Xamarin.Forms;

namespace RegistrationApp.Autorization
{
    public static class AutorizationService
    {
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
                Application.Current.MainPage.DisplayAlert("ERROR", "Email already exists", "OK");
            }
        }

        public static bool CheckUserCredentials(User user)
        {
            //var users = App.UserDatabase.GetAllUsersAsync().Result;
            //return (users.Where(u => u.Email == user.Email && u.Password == user.Password)
            //            .FirstOrDefault() != null);
            var _testUser = new User()
            {
                Email = "Test@test.com",
                Password = "123qweASD"
            };

            return (user.Email == _testUser.Email && user.Password == _testUser.Password);
        }

        public static async void SignInUserAsync(User user)
        {
            if (CheckUserCredentials(user))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new TaskListPage(user));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("ERROR", "BAD CREDENTIALS", "OK");
            }
        }
    }
}
