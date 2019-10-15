using System;
using System.IO;
using RegistrationApp.Data;
using Xamarin.Forms;

namespace RegistrationApp
{
    public partial class App : Application
    {
        private static UserDatabase _userDatabase;

        public static UserDatabase UserDatabase
        {
            get
            {
                if (_userDatabase == null)
                {
                    _userDatabase = new UserDatabase(Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "User.db3"));
                }
                return _userDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartUpPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
