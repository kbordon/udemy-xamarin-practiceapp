using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        User user;
        RegisterVM viewModel;

        public RegisterPage()
        {
            InitializeComponent();

            viewModel = new RegisterVM();
            BindingContext = viewModel;
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
