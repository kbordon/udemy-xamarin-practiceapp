using Microsoft.WindowsAzure.MobileServices;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
		public static MobileServiceClient MobileService =
			new MobileServiceClient(
				"https://travelrecordkb18.azurewebsites.net"
			);
		public static User user = new User();
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TravelRecordAppPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TravelRecordAppPage());

            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
