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

            client = new FirebaseClient(Constants.URL);
            FoodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    ProductID = 1,
                    ImageUrl= "Poutine.jpg",
                    Name = "Poutine",
                    Description = "Meal of dreams!",
                    Rating = " 4.6",
                    RatingDetail = " (121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 6.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 2,
                    ImageUrl= "Bannock.jpg",
                    Name = "Bannock",
                    Description = "Delicious and versatile!",
                    Rating = " 4.2",
                    RatingDetail = " (75 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 8.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 3,
                    ImageUrl= "ButterTart.jpg",
                    Name = "Butter Tart",
                    Description = "Oh so good!",
                    Rating = " 4.9",
                    RatingDetail = " (288 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 1.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 4,
                    ImageUrl= "Lobster.jpg",
                    Name = "Lobster Rolls",
                    Description = "A Canadian favourite!",
                    Rating = " 4.7",
                    RatingDetail = " (124 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 18.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 5,
                    ImageUrl= "Bagels.jpg",
                    Name = "Bagels",
                    Description = "Montreal’s bagels!",
                    Rating = " 4.3",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 2.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 6,
                    ImageUrl= "Pie.jpg",
                    Name = "Berry Pie",
                    Description = "Life-changing!",
                    Rating = " 4.9",
                    RatingDetail = " (224 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 8.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 7,
                    ImageUrl= "SmokedMeat.jpg",
                    Name = "Smoked Meat",
                    Description = "Exquisite Beef!",
                    Rating = " 4.5",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 28.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 8,
                    ImageUrl= "Bacon.jpg",
                    Name = "Peameal Bacon",
                    Description = "Brilliant Bacon!",
                    Rating = " 4.6",
                    RatingDetail = " (39 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 14.99M,
                    CategoryID = 1
                },
                new FoodItem()
                {
                    ProductID = 9,
                    ImageUrl= "Burger.jpg",
                    Name = "Burger",
                    Description = "Meal of dreams!",
                    Rating = " 4.6",
                    RatingDetail = " (121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 6.99M,
                    CategoryID = 2
                },
                new FoodItem()
                {
                    ProductID = 10,
                    ImageUrl= "ApplePie.jpg",
                    Name = "Apple Pie",
                    Description = "Delicious and versatile!",
                    Rating = " 4.2",
                    RatingDetail = " (75 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 8.99M,
                    CategoryID = 2
                },
                new FoodItem()
                {
                    ProductID = 11,
                    ImageUrl= "Cheese.jpg",
                    Name = "Grilled Cheese",
                    Description = "Oh so good!",
                    Rating = " 4.9",
                    RatingDetail = " (288 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 4.99M,
                    CategoryID = 2
                },
                new FoodItem()
                {
                    ProductID = 12,
                    ImageUrl= "Chicken.jpg",
                    Name = "Fried Chicken",
                    Description = "A Worldwide favourite!",
                    Rating = " 4.7",
                    RatingDetail = " (124 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 18.99M,
                    CategoryID = 2
                },
                new FoodItem()
                {
                    ProductID = 13,
                    ImageUrl= "Chip.jpg",
                    Name = "Chocolate Chip",
                    Description = "You'll love it!",
                    Rating = " 4.3",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 2.99M,
                    CategoryID = 2
                },
                new FoodItem()
                {
                    ProductID = 14,
                    ImageUrl= "Donut.jpg",
                    Name = "Donuts",
                    Description = "Life-changing!",
                    Rating = " 4.9",
                    RatingDetail = " (224 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 1.99M,
                    CategoryID =2
                },
                new FoodItem()
                {
                    ProductID = 15,
                    ImageUrl= "HotDog.jpg",
                    Name = "Hotdog",
                    Description = "Exquisite!",
                    Rating = " 4.5",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 8.99M,
                    CategoryID = 2
                },
                new FoodItem()
                {
                    ProductID = 16,
                    ImageUrl= "IceCream.jpg",
                    Name = "Ice Cream",
                    Description = "Brilliant Sweetness!",
                    Rating = " 4.6",
                    RatingDetail = " (39 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 3.99M,
                    CategoryID = 2
                },
                new FoodItem()
                {
                    ProductID = 17,
                    ImageUrl= "Biryani.jpg",
                    Name = "Biryani",
                    Description = "Meal of dreams!",
                    Rating = " 4.6",
                    RatingDetail = " (121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 16.99M,
                    CategoryID = 3
                },
                new FoodItem()
                {
                    ProductID = 18,
                    ImageUrl= "ButterChicken.jpg",
                    Name = "Butter Chicken",
                    Description = "Delicious and versatile!",
                    Rating = " 4.9",
                    RatingDetail = " (475 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 12.99M,
                    CategoryID = 3
                },
                new FoodItem()
                {
                    ProductID = 19,
                    ImageUrl= "Chaat.jpg",
                    Name = "Chaat",
                    Description = "Oh so good!",
                    Rating = " 4.4",
                    RatingDetail = " (152 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 4.99M,
                    CategoryID = 3
                },
                new FoodItem()
                {
                    ProductID = 20,
                    ImageUrl= "Dosa.jpg",
                    Name = "Dosa",
                    Description = "A Worldwide favourite!",
                    Rating = " 4.7",
                    RatingDetail = " (124 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 11.99M,
                    CategoryID = 3
                },
                new FoodItem()
                {
                    ProductID = 21,
                    ImageUrl= "GulabJamun.jpg",
                    Name = "Gulab Jamun",
                    Description = "You'll love it!",
                    Rating = " 4.3",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 2.99M,
                    CategoryID = 3
                },
                new FoodItem()
                {
                    ProductID = 22,
                    ImageUrl= "Korma.jpg",
                    Name = "Chicken Korma",
                    Description = "Life-changing!",
                    Rating = " 4.9",
                    RatingDetail = " (136 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 11.99M,
                    CategoryID =3
                },
                new FoodItem()
                {
                    ProductID = 23,
                    ImageUrl= "Naan.jpg",
                    Name = "Naan",
                    Description = "Exquisite!",
                    Rating = " 4.5",
                    RatingDetail = " (624 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 1.99M,
                    CategoryID = 3
                },
                new FoodItem()
                {
                    ProductID = 24,
                    ImageUrl= "Samosa.jpg",
                    Name = "Samosas",
                    Description = "Brilliantly Indian!",
                    Rating = " 4.6",
                    RatingDetail = " (39 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 3.99M,
                    CategoryID = 3
                },
                new FoodItem()
                {
                    ProductID = 25,
                    ImageUrl= "Shawarma.jpg",
                    Name = "Shawarma",
                    Description = "Meal of dreams!",
                    Rating = " 4.6",
                    RatingDetail = " (121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 16.99M,
                    CategoryID = 4
                },
                new FoodItem()
                {
                    ProductID = 26,
                    ImageUrl= "Falafel.jpg",
                    Name = "Falafel",
                    Description = "Delicious and versatile!",
                    Rating = " 4.9",
                    RatingDetail = " (475 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 12.99M,
                    CategoryID = 4
                },
                new FoodItem()
                {
                    ProductID = 27,
                    ImageUrl= "GrilledHaloumi.jpg",
                    Name = "Grilled Haloumi",
                    Description = "Oh so good!",
                    Rating = " 4.4",
                    RatingDetail = " (152 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 4.99M,
                    CategoryID = 4
                },
                new FoodItem()
                {
                    ProductID = 28,
                    ImageUrl= "Hummus.jpg",
                    Name = "Hummus",
                    Description = "A Worldwide favourite!",
                    Rating = " 4.7",
                    RatingDetail = " (124 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 11.99M,
                    CategoryID = 4
                },
                new FoodItem()
                {
                    ProductID = 29,
                    ImageUrl= "Manakeesh.jpg",
                    Name = "Manakeesh",
                    Description = "You'll love it!",
                    Rating = " 4.3",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 2.99M,
                    CategoryID = 4
                },
                new FoodItem()
                {
                    ProductID = 30,
                    ImageUrl= "Medames.jpg",
                    Name = "Medames",
                    Description = "Life-changing!",
                    Rating = " 4.9",
                    RatingDetail = " (136 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 11.99M,
                    CategoryID =4
                },
                new FoodItem()
                {
                    ProductID = 31,
                    ImageUrl= "Tabouleh.jpg",
                    Name = "Tabouleh",
                    Description = "Exquisite!",
                    Rating = " 4.5",
                    RatingDetail = " (624 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 1.99M,
                    CategoryID = 4
                },
                new FoodItem()
                {
                    ProductID = 32,
                    ImageUrl= "Kofta.jpg",
                    Name = "Kofta",
                    Description = "Brilliantly Arab!",
                    Rating = " 4.6",
                    RatingDetail = " (39 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 3.99M,
                    CategoryID = 4
                },
                new FoodItem()
                {
                    ProductID = 33,
                    ImageUrl= "ChowMein.jpg",
                    Name = "Chow Mein",
                    Description = "Meal of dreams!",
                    Rating = " 4.6",
                    RatingDetail = " (121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 16.99M,
                    CategoryID = 5
                },
                new FoodItem()
                {
                    ProductID = 34,
                    ImageUrl= "CharSiu.jpg",
                    Name = "Char Siu",
                    Description = "Delicious and versatile!",
                    Rating = " 4.9",
                    RatingDetail = " (475 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 12.99M,
                    CategoryID = 5
                },
                new FoodItem()
                {
                    ProductID = 35,
                    ImageUrl= "Tofu.jpg",
                    Name = "Ma Po Tofu",
                    Description = "Oh so good!",
                    Rating = " 4.4",
                    RatingDetail = " (152 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 4.99M,
                    CategoryID = 5
                },
                new FoodItem()
                {
                    ProductID = 36,
                    ImageUrl= "Dumpling.jpg",
                    Name = "Dumplings",
                    Description = "A Worldwide favourite!",
                    Rating = " 4.7",
                    RatingDetail = " (124 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 11.99M,
                    CategoryID =5
                },
                new FoodItem()
                {
                    ProductID = 37,
                    ImageUrl= "DimSum.jpg",
                    Name = "Dim Sum",
                    Description = "You'll love it!",
                    Rating = " 4.3",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 2.99M,
                    CategoryID = 5
                },
                new FoodItem()
                {
                    ProductID = 38,
                    ImageUrl= "Duck.jpg",
                    Name = "Roasted Duck",
                    Description = "Life-changing!",
                    Rating = " 4.9",
                    RatingDetail = " (136 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 11.99M,
                    CategoryID =5
                },
                new FoodItem()
                {
                    ProductID = 39,
                    ImageUrl= "SSPork.jpg",
                    Name = "Sweet-Sour Pork",
                    Description = "Exquisite!",
                    Rating = " 4.5",
                    RatingDetail = " (624 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 1.99M,
                    CategoryID = 5
                },
                new FoodItem()
                {
                    ProductID = 40,
                    ImageUrl= "KungPao.jpg",
                    Name = "Kung Pao Chicken",
                    Description = "Brilliantly Chinese!",
                    Rating = " 4.6",
                    RatingDetail = " (39 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 3.99M,
                    CategoryID = 5
                },
                new FoodItem()
                {
                    ProductID = 41,
                    ImageUrl= "Pasta.jpg",
                    Name = "Pasta",
                    Description = "Meal of dreams!",
                    Rating = " 4.6",
                    RatingDetail = " (121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 16.99M,
                    CategoryID = 6
                },
                new FoodItem()
                {
                    ProductID = 42,
                    ImageUrl= "Gnocchi.jpg",
                    Name = "Gnocchi",
                    Description = "Delicious and versatile!",
                    Rating = " 4.9",
                    RatingDetail = " (475 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 12.99M,
                    CategoryID = 6
                },
                new FoodItem()
                {
                    ProductID = 43,
                    ImageUrl= "Lasagne.jpg",
                    Name = "Lasagne",
                    Description = "Oh so good!",
                    Rating = " 4.4",
                    RatingDetail = " (152 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 4.99M,
                    CategoryID = 6
                },
                new FoodItem()
                {
                    ProductID = 44,
                    ImageUrl= "Pizza.jpg",
                    Name = "Pizza",
                    Description = "A Worldwide favourite!",
                    Rating = " 4.7",
                    RatingDetail = " (124 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 11.99M,
                    CategoryID =6
                },
                new FoodItem()
                {
                    ProductID = 45,
                    ImageUrl= "Gelato.jpg",
                    Name = "Gelato",
                    Description = "You'll love it!",
                    Rating = " 4.3",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 2.99M,
                    CategoryID =6
                },
                new FoodItem()
                {
                    ProductID = 46,
                    ImageUrl= "Polenta.jpg",
                    Name = "Polenta",
                    Description = "Life-changing!",
                    Rating = " 4.9",
                    RatingDetail = " (136 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 11.99M,
                    CategoryID =6
                },
                new FoodItem()
                {
                    ProductID = 47,
                    ImageUrl= "Ravioli.jpg",
                    Name = "Ravioli",
                    Description = "Exquisite!",
                    Rating = " 4.5",
                    RatingDetail = " (624 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 1.99M,
                    CategoryID = 6
                },
                new FoodItem()
                {
                    ProductID = 48,
                    ImageUrl= "Focaccia.jpg",
                    Name = "Focaccia",
                    Description = "Brilliantly Italian!",
                    Rating = " 4.6",
                    RatingDetail = " (39 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 3.99M,
                    CategoryID = 6
                },
                new FoodItem()
                {
                    ProductID = 49,
                    ImageUrl= "Chilaquiles.jpg",
                    Name = "Chilaquiles",
                    Description = "Meal of dreams!",
                    Rating = " 4.6",
                    RatingDetail = " (121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 16.99M,
                    CategoryID = 7
                },
                new FoodItem()
                {
                    ProductID = 50,
                    ImageUrl= "Pozole.jpg",
                    Name = "Pozole",
                    Description = "Delicious and versatile!",
                    Rating = " 4.9",
                    RatingDetail = " (475 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 12.99M,
                    CategoryID = 7
                },
                new FoodItem()
                {
                    ProductID = 51,
                    ImageUrl= "Tacos.jpg",
                    Name = "Tacos",
                    Description = "Oh so good!",
                    Rating = " 4.4",
                    RatingDetail = " (152 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 4.99M,
                    CategoryID = 7
                },
                new FoodItem()
                {
                    ProductID = 52,
                    ImageUrl= "Tostadas.jpg",
                    Name = "Tostadas",
                    Description = "A Worldwide favourite!",
                    Rating = " 4.7",
                    RatingDetail = " (124 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 11.99M,
                    CategoryID =7
                },
                new FoodItem()
                {
                    ProductID = 53,
                    ImageUrl= "Elote.jpg",
                    Name = "Elote",
                    Description = "You'll love it!",
                    Rating = " 4.3",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 2.99M,
                    CategoryID =7
                },
                new FoodItem()
                {
                    ProductID = 54,
                    ImageUrl= "Enchiladas.jpg",
                    Name = "Enchiladas",
                    Description = "Life-changing!",
                    Rating = " 4.9",
                    RatingDetail = " (136 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 11.99M,
                    CategoryID =7
                },
                new FoodItem()
                {
                    ProductID = 55,
                    ImageUrl= "Guacamole.jpg",
                    Name = "Guacamole",
                    Description = "Exquisite!",
                    Rating = " 4.5",
                    RatingDetail = " (624 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 1.99M,
                    CategoryID = 7
                },
                new FoodItem()
                {
                    ProductID = 56,
                    ImageUrl= "Tamales.jpg",
                    Name = "Tamales",
                    Description = "Brilliantly Mexican!",
                    Rating = " 4.6",
                    RatingDetail = " (39 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 3.99M,
                    CategoryID = 7
                },
                new FoodItem()
                {
                    ProductID = 57,
                    ImageUrl= "Boeuf.jpg",
                    Name = "Boeuf Bourguignon",
                    Description = "Meal of dreams!",
                    Rating = " 4.6",
                    RatingDetail = " (121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 16.99M,
                    CategoryID = 8
                },
                new FoodItem()
                {
                    ProductID = 58,
                    ImageUrl= "Macarons.jpg",
                    Name = "Macarons",
                    Description = "Delicious and versatile!",
                    Rating = " 4.9",
                    RatingDetail = " (475 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 12.99M,
                    CategoryID = 8
                },
                new FoodItem()
                {
                    ProductID = 59,
                    ImageUrl= "FoieGras.jpg",
                    Name = "Foie Gras",
                    Description = "Oh so good!",
                    Rating = " 4.4",
                    RatingDetail = " (152 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 4.99M,
                    CategoryID = 8
                },
                new FoodItem()
                {
                    ProductID = 60,
                    ImageUrl= "Croissant.jpg",
                    Name = "Croissant",
                    Description = "A Worldwide favourite!",
                    Rating = " 4.7",
                    RatingDetail = " (124 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 11.99M,
                    CategoryID =8
                },
                new FoodItem()
                {
                    ProductID = 61,
                    ImageUrl= "Crepes.jpg",
                    Name = "Crepes",
                    Description = "You'll love it!",
                    Rating = " 4.3",
                    RatingDetail = " (24 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 2.99M,
                    CategoryID =8
                },
                new FoodItem()
                {
                    ProductID = 62,
                    ImageUrl= "Cassoulet.jpg",
                    Name = "Cassoulet",
                    Description = "Life-changing!",
                    Rating = " 4.9",
                    RatingDetail = " (136 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 11.99M,
                    CategoryID =8
                },
                new FoodItem()
                {
                    ProductID = 63,
                    ImageUrl= "Baguette.jpg",
                    Name = "Baguette",
                    Description = "Exquisite!",
                    Rating = " 4.5",
                    RatingDetail = " (624 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 1.99M,
                    CategoryID = 8
                },
                new FoodItem()
                {
                    ProductID = 64,
                    ImageUrl= "Eclair.jpg",
                    Name = "Eclair",
                    Description = "Brilliantly French!",
                    Rating = " 4.6",
                    RatingDetail = " (39 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 3.99M,
                    CategoryID = 8
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
