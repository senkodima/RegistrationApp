using System;
using System.Collections.Generic;
using RegistrationApp.Models;

using Xamarin.Forms;

namespace RegistrationApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {

        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}

