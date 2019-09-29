using System.Collections.Generic;
using System.Linq;
using RegistrationApp.Models;
using Xamarin.Forms;

namespace RegistrationApp.Autorisation
{
    public static class AutorisationService
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
                Application.Current.MainPage.DisplayAlert("ERROR", "Email already exists", "OK");
            }
        }

        
    }
}
