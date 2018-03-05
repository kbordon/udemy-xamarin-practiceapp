using System;
using System.Linq;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class TravelRecordAppPage : ContentPage
    {
        public TravelRecordAppPage()
        {
            InitializeComponent();

            var assembly = typeof(TravelRecordAppPage);

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {

            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {
                // what goes here?
            }
            else
            {
				var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();    
               
                if(user != null)
                {
                    App.user = user;
                    if(user.Password == passwordEntry.Text)
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Email or password is incorrect.", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "This email has not been registered.", "Ok");
                }
            }
        }

        private void registerUserButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
