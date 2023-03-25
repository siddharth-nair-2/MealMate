﻿using Firebase.Database;
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
            client = new FirebaseClient("https://mealmate-61db7-default-rtdb.firebaseio.com/");
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
    }
}