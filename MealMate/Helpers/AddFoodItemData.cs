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
    public class AddFoodItemData
    {
        public List<FoodItem> FoodItems { get; set; }
        FirebaseClient client;

        public AddFoodItemData()
        {

            client = new FirebaseClient("https://mealmate-61db7-default-rtdb.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    ProductID = 1,
                    ImageUrl= "MainBurger.jpg",
                    Name = "Burger and Pizza Hub 1",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.6",
                    RatingDetail = " (121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 8.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 2,
                    ImageUrl= "MainBurger.jpg",
                    Name = "Burger and Pizza Hub 2",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.5",
                    RatingDetail = " (84 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 10.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 3,
                    ImageUrl= "MainBurger.jpg",
                    Name = "Burger and Pizza Hub 3",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.3",
                    RatingDetail = " (178 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 11.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 4,
                    ImageUrl= "MainPizza.jpg",
                    Name = "Pizza",
                    Description = "Pizza - Breakfast",
                    Rating = " 4.9",
                    RatingDetail = " (71 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 14.99M,
                    CategoryID = 2
                },
                new FoodItem()
                {
                    ProductID = 5,
                    ImageUrl= "MainPizza.jpg",
                    Name = "Pizza Hub 2",
                    Description = "Pizza - Breakfast",
                    Rating = " 4.1",
                    RatingDetail = " (49 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 16.99M,
                    CategoryID = 2
                },
                new FoodItem()
                {
                    ProductID = 6,
                    ImageUrl= "MainDessert.jpeg",
                    Name = "Ice Creams",
                    Description = "Ice Cream - Breakfast",
                    Rating = " 4.9",
                    RatingDetail = " (246 ratings)",
                    HomeSelected = "CompleteHear",
                    Price = 3.99M,
                    CategoryID = 3
                },
                new FoodItem()
                {
                    ProductID = 6,
                    ImageUrl= "MainDessert.jpeg",
                    Name = "Cakes",
                    Description = "Cakes - Breakfast",
                    Rating = " 4.6",
                    RatingDetail = " (27 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 18.99M,
                    CategoryID = 3
                },
            };
        }

        public async Task AddFoodItemAsync()
        {

            try
            {
                foreach (var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {

                        ProductID = item.ProductID,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Description = item.Description,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail,
                        HomeSelected = item.HomeSelected,
                        Price = item.Price,
                        CategoryID = item.CategoryID
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
