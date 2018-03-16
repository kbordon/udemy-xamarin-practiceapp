using System;
using System.ComponentModel;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class NewTravelVM : INotifyPropertyChanged
    {
        public PostCommand PostCommand { get; set; }
        //public Venue Venue { get; set; }
        //public Post Post { get; set; }

        private Post post;

        public Post Post
        {
            get { return post; }
            set { 
                post = value;
                OnPropertyChanged("Post");
            }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set { 
                experience = value;
                Post = new Post()
                {
                    Experience = this.Experience,
                    Venue = this.Venue
                };
                OnPropertyChanged("Experience");
            }
        }

        private Venue venue;

        public Venue Venue
        {
            get { return venue; }
            set { 
                venue = value;
                Post = new Post()
                {
                    Experience = this.Experience,
                    Venue = this.Venue
                };
                OnPropertyChanged("Venue");
            }
        }

        public NewTravelVM()
        {
            PostCommand = new PostCommand(this);
            Post = new Post();
            //Venue = new Venue();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            
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
