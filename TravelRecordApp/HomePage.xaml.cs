using System;
using System.Collections.Generic;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HomePage : TabbedPage
    {
        HomeVM viewModel;

        public HomePage()
        {
            InitializeComponent();

            viewModel = new HomeVM();
            BindingContext = viewModel;
        }

        // Don't need this anymore since we have a command
        //private void ToolbarItem_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new NewTravelPage());
        //}
    }
}
