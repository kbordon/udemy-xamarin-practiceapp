using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //        {
            //conn.CreateTable<Post>();
            //var posts = conn.Table<Post>().ToList();
            //    postListView.ItemsSource = posts;
            //}

            var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();
            postListView.ItemsSource = posts;
        }
    }
}
