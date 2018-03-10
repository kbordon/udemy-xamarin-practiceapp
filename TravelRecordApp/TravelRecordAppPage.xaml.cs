using System;
using System.Linq;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class TravelRecordAppPage : ContentPage
    {

        TravelAppVM viewModel;

        public TravelRecordAppPage()
        {
            InitializeComponent();

            var assembly = typeof(TravelRecordAppPage);

            viewModel = new TravelAppVM();
            BindingContext = viewModel;

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
        }

        // Handled by command
        //private async void LoginButton_Clicked(object sender, EventArgs e)
        //{
        //    bool canLogin = await User.Login(emailEntry.Text, passwordEntry.Text);

        //    if (canLogin)
        //        await Navigation.PushAsync(new HomePage());
        //    else
        //        await DisplayAlert("Error", "Try again", "Ok");
        //}

        private void registerUserButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
