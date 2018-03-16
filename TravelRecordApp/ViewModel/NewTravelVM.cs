using System;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class NewTravelVM
    {
        public PostCommand PostCommand { get; set; }
        public Venue Venue { get; set; }

        public NewTravelVM()
        {
            PostCommand = new PostCommand(this);
            Venue = new Venue();
        }

        public async void PublishPost(Post post)
        {
        
            try
            {
                Post.Insert(post);
                await App.Current.MainPage.DisplayAlert("Success", "Experience successfully inserted.", "Ok");
            }
            catch (NullReferenceException nre)
            {
                await App.Current.MainPage.DisplayAlert("oops", "something went wrong", "ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Experience was not inserted", "Ok");
            }

        }
    }
}
