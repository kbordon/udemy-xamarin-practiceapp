using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
				//var postTable = conn.Table<Post>().ToList();

				var postTable = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();

                var categories = (from p in postTable
                                  orderby p.CategoryId
                                  select p.CategoryName).Distinct().ToList();

                //var categories = postTable.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();
                
                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                foreach(var category in categories)
                {
                    //var count = (from post in postTable
                                 //where post.CategoryName == category
                                 //select post).ToList().Count();


                    var count = postTable.Where(p => p.CategoryName == category).ToList().Count;
                                          
                    if (category == null){
                        categoriesCount.Add("Uncategorized", count);  
                    }
                    else {
						categoriesCount.Add(category, count);  
                    }
                }

                categoriesListView.ItemsSource = categoriesCount;

                postCountLabel.Text = postTable.Count.ToString();
            //}
        }
    }
}
