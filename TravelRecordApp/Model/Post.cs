﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;
using Newtonsoft.Json;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { 
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set { 
                experience = value;
                OnPropertyChanged("Experience");
            }
        }

        private string venueName;

        public string VenueName
        {
            get { return venueName; }
            set { 
                venueName = value;
                OnPropertyChanged("VenueName");
            }
        }

        private string categoryId;

        public string CategoryId
        {
            get { return categoryId; }
            set { 
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { 
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {

                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { 
                city = value;
                OnPropertyChanged("City");
            }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { 
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set { 
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set { 
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { 
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        private Venue venue;

        [JsonIgnore]
        public Venue Venue
        {
            get { return venue; }
            set
            {
                venue = value;

                if (venue.categories != null)
                {
                    var firstCategory = venue.categories.FirstOrDefault();

                    if (firstCategory != null)
                    {
                        CategoryId = firstCategory.id;
                        CategoryName = firstCategory.name;
                    }
                }

                if (venue.location != null)
                {
                    Address = venue.location.address;
                    Distance = venue.location.distance;
                    Latitude = venue.location.lat;
                    Longitude = venue.location.lng;
                }
                VenueName = venue.name;
                UserId = App.user.Id;

                OnPropertyChanged("Venue");
            }
        }

        //[JsonIgnore]
        //public Venue Venue
        //{
        //    get { return venue; }
        //    set { 
        //        venue = value;
        //        var firstCategory = venue.categories.FirstOrDefault();

        //        //post.Experience = experienceEntry.Text;
        //        CategoryId = firstCategory.id;
        //        CategoryName = firstCategory.name;
        //        City = venue.location.city;
        //        Distance = venue.location.distance;
        //        Latitude = venue.location.lat;
        //        Longitude = venue.location.lng;
        //        VenueName = venue.name;
        //        UserId = App.user.Id;

        //        OnPropertyChanged("Venue");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;


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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
