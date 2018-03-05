using System;
using SQLite;

namespace TravelRecordApp.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        //public int Id { get; set;}
        public string Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName
        {
            get;
            set;
        }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
        public string City { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }

        public string UserId { get; set; }

        public static async void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }
    }
}
