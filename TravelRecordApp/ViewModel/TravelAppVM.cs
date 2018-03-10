using System;
using System.ComponentModel;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class TravelAppVM : INotifyPropertyChanged
    {
        private User user;
        public User User
        {
            get { return user; }
            set { 
                user = value;
                OnPropertyChanged("User");
            }
        }
        public LoginCommand LoginCommand { get; set; }
       
        private string email;

        public string Email
        {
            get { return email; }
            set { 
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { 
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }

		public event PropertyChangedEventHandler PropertyChanged;
		
        public TravelAppVM()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
        }

        public async void Login()
        {
            bool canLogin = await User.Login(User.Email, User.Password);

            if (canLogin)
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                await App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
