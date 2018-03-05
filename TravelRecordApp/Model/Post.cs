using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        // Inserts post into table
        public static async void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }

        public static async Task<List<Post>> Read()
        {
            return await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();

        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            //var categories = postTable.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                //var count = (from post in postTable
                //where post.CategoryName == category
                //select post).ToList().Count();


                var count = posts.Where(p => p.CategoryName == category).ToList().Count;

                if (category == null)
                {
                    categoriesCount.Add("Uncategorized", count);
                }
                else
                {
                    categoriesCount.Add(category, count);
                }

            }
			return categoriesCount;
        }
    }
}
