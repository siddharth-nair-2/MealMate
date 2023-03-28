using Firebase.Database;
using Firebase.Database.Query;
using MealMate.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealMate.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }

        FirebaseClient client;
        public AddCategoryData()
        {
            client = new FirebaseClient(Constants.URL);
            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId= 1,
                    CategoryName = "Canadian",
                    CategoryPoster = "CanadianPoster.jpg",
                    ImageUrl = "CanadianCat.png"
                },
                new Category()
                {
                    CategoryId= 2,
                    CategoryName = "American",
                    CategoryPoster = "AmericanPoster.jpg",
                    ImageUrl = "AmericanCat.png"
                },
                new Category()
                {
                    CategoryId= 3,
                    CategoryName = "Indian",
                    CategoryPoster = "IndianPoster.jpg",
                    ImageUrl = "IndianCat.png"
                },
                new Category()
                {
                    CategoryId= 4,
                    CategoryName = "Arab",
                    CategoryPoster = "ArabPoster.jpeg",
                    ImageUrl = "ArabCat.png"
                },
                new Category()
                {
                    CategoryId= 5,
                    CategoryName = "Chinese",
                    CategoryPoster = "ChinesePoster.jpg",
                    ImageUrl = "ChineseCat.png"
                },
                new Category()
                {
                    CategoryId= 6,
                    CategoryName = "Italian",
                    CategoryPoster = "ItalianPoster.jpeg",
                    ImageUrl = "ItalianCat.png"
                },
                new Category()
                {
                    CategoryId= 7,
                    CategoryName = "Mexican",
                    CategoryPoster = "MexicanPoster.jpg",
                    ImageUrl = "MexicanCat.png"
                },
                new Category()
                {
                    CategoryId= 8,
                    CategoryName = "French",
                    CategoryPoster = "FrenchPoster.jpg",
                    ImageUrl = "FrenchCat.png"
                },
            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
