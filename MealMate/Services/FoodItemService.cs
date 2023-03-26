using Firebase.Database;
using MealMate.Helpers;
using MealMate.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMate.Services
{
    public class FoodItemService
    {
        FirebaseClient client;
        public FoodItemService()
        {
            client = new FirebaseClient(Constants.URL);
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems")
                .OnceAsync<FoodItem>())
                .Select(item => new FoodItem
                {
                    CategoryID = item.Object.CategoryID,
                    Description = item.Object.Description,
                    ProductID = item.Object.ProductID,
                    HomeSelected = item.Object.HomeSelected,
                    ImageUrl = item.Object.ImageUrl,
                    Name = item.Object.Name,
                    Price = item.Object.Price,
                    Rating = item.Object.Rating,
                    RatingDetail = item.Object.RatingDetail
                }).ToList();

            return products;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsSpecific = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();

            foreach (var item in items)
            {
                foodItemsSpecific.Add(item);
            }

            return foodItemsSpecific;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByQueryAsync(string query)
        {
            var foodItemsByQuery = new ObservableCollection<FoodItem>();

            var items = (await GetFoodItemsAsync()).Where(p => p.Name.Contains(query)).ToList();

            foreach (var item in items)
            {
                foodItemsByQuery.Add(item);
            }

            return foodItemsByQuery;
        }
        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);

            foreach (var item in items)
            {
                latestFoodItems.Add(item);
            }
            return latestFoodItems;
        }
    }
}
