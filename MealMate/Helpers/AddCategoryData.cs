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
            client = new FirebaseClient("https://mealmate-61db7-default-rtdb.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId= 1,
                    CategoryName = "Burger",
                    CategoryPoster = "MainBurger.png",
                    ImageUrl = "Burger.png"
                },
                new Category()
                {
                    CategoryId= 2,
                    CategoryName = "Pizza",
                    CategoryPoster = "MainPizza.jpg",
                    ImageUrl = "Pizza.png"
                },
                new Category()
                {
                    CategoryId= 3,
                    CategoryName = "Desserts",
                    CategoryPoster = "MainDessert.jpeg",
                    ImageUrl = "Dessert.png"
                },
                new Category()
                {
                    CategoryId= 4,
                    CategoryName = "Vegan Burger",
                    CategoryPoster = "MainBurger.jpg",
                    ImageUrl = "Burger.png"
                },
                new Category()
                {
                    CategoryId= 5,
                    CategoryName = "Vegan Pizza",
                    CategoryPoster = "MainPizza.jpg",
                    ImageUrl = "Pizza.png"
                },
                new Category()
                {
                    CategoryId= 6,
                    CategoryName = "Cakes",
                    CategoryPoster = "MainDessert.jpeg",
                    ImageUrl = "Dessert.png"
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
