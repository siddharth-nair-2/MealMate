using Firebase.Database;
using Firebase.Database.Query;
using LiteDB;
using MealMate.Helpers;
using MealMate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMate.Services
{
    public class CategoryDataService
    {
        FirebaseClient client;
        public CategoryDataService()
        {
            client = new FirebaseClient(Constants.URL);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories").OnceAsync<Category>())
                .Select(c => new Category
                {
                    CategoryId = c.Object.CategoryId,
                    CategoryName = c.Object.CategoryName,
                    CategoryPoster = c.Object.CategoryPoster,
                    ImageUrl= c.Object.ImageUrl,
                }).ToList();

            return categories;

        }

        public async Task<bool> DeleteCategory(int id)
        {
            var node = client.Child("Categories");

            var snapshot = await node.OnceAsync<Category>();

            foreach (var itemSnapshot in snapshot)
            {
                var item = itemSnapshot.Object;

                if (item.CategoryId == id)
                {
                    var itemKey = itemSnapshot.Key;
                    await node.Child(itemKey).DeleteAsync();
                }
            }

            await new FoodItemService().DeleteFoodFromCategory(id);

            return false;
        }

        public async Task<int> CategoryMaxID()
        {
            var allItems = await GetCategoriesAsync();
            int max = 0;
            foreach (var item in allItems)
            {
                if (item.CategoryId > max)
                {
                    max = item.CategoryId;
                }
            }

            return max;
        }

        public async Task<List<Category>> GetCategorieIDAsync(string name)
        {
            var categories = (await client.Child("Categories").OnceAsync<Category>())
                .Where(u => u.Object.CategoryName == name)
                .Select(c => new Category
                {
                    CategoryId = c.Object.CategoryId,
                    CategoryName = c.Object.CategoryName,
                    CategoryPoster = c.Object.CategoryPoster,
                    ImageUrl = c.Object.ImageUrl,
                }).ToList();

            return categories;

        }
    }
}
