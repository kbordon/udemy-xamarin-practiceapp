using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        User user;

        public RegisterPage()
        {
            InitializeComponent();

            user = new User();
            containerStackLayout.BindingContext = user;
        }

        //private async void registerButton_Clicked(object sender, EventArgs e)
        //{
        //    if(passwordEntry.Text == confirmPasswordEntry.Text)
        //    {
        //        // register

        //        User.Register(user);
        //    }
        //    else
        //    {
        //        await DisplayAlert("Error", "Passwords don't match!", "OK");
        //    }
        //}
    }
}
