using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using MealMate.Helpers;
using MealMate.Model;
using MealMate.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SQLite.SQLite3;
using Application = Xamarin.Forms.Application;
using Picker = Xamarin.Forms.Picker;

namespace MealMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemsView : ContentPage
    {
        public ObservableCollection<Category> Categories { get; set; }
        public AddItemsView()
        {
            InitializeComponent();
            Categories = new ObservableCollection<Category>();
            GetAllCategories();
            CatPicker.ItemsSource = Categories;
            CatPicker.ItemDisplayBinding = new Binding("CategoryName");
        }
        FileResult poster;

        private async void GetAllCategories()
        {

            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }

        private async void PosterButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (photo == null) return;

            poster = photo;
            var stream = await photo.OpenReadAsync();
            var showPoster = ImageSource.FromStream(() => stream);
            posterImage.Source = showPoster;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private void EntryCatName_TextChanged(object sender, TextChangedEventArgs e)
        {
            int restrictCount = 15; //Enter your number of character restriction

            if (EntryFoodName.Text.Length > restrictCount)
            {
                EntryFoodName.Text = EntryFoodName.Text.Substring(0, restrictCount);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            double result;
            bool isValid = Double.TryParse(EntryPrice.Text, out result);
            if (!isValid || result > 100 || result < 1)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Price", "Please enter the price in 12.34 format!", "OK");
                return;
            }
            if (poster == null )
            {
                await Application.Current.MainPage.DisplayAlert("No Image!", "Please upload a poster for the food item!", "OK");
                return;
            }
            if (EntryFoodName.Text == null || EntryFoodDesc.Text == null || EntryFoodName.Text.Length < 1 || EntryFoodDesc.Text.Length < 1)
            {
                await Application.Current.MainPage.DisplayAlert("No Name!", "Please enter a valid name/description for the food item!", "OK");
                return;
            }
            if(CatPicker.SelectedIndex == -1)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Category!", "Please pick a valid category!", "OK");
                return;
            }


            var selectedCategory = CatPicker.SelectedItem as Category;
            var totalItems = await new FoodItemService().GetFoodItemsByCategoryAsync(selectedCategory.CategoryId);

            foreach (FoodItem foodItem in totalItems)
            {
                if (foodItem.Name.Trim() == EntryFoodName.Text.Trim())
                {
                    await Application.Current.MainPage.DisplayAlert("Already Exists!", "Please enter a different name for the food item!", "OK");
                    return;
                }
            }

            FirebaseClient client;
            client = new FirebaseClient(Constants.URL);

            var taskPoster = new FirebaseStorage("mealmate-61db7.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true,
                })
                .Child("Food Items")
                .Child(EntryFoodName.Text)
                .Child("Poster")
                .Child(poster.FileName)
                .PutAsync(await poster.OpenReadAsync());

            var posterLink = await taskPoster;

            Random rnd = new Random();
            var randomRating = rnd.NextDouble() * (5.0 - 3.8) + 3.8;
            var finalRating = randomRating.ToString("F1");
            int ratingCount = rnd.Next(25, 350);

            var foodItemService = await new FoodItemService().FoodItemMaxID();

            await client.Child("FoodItems").PostAsync(new FoodItem()
            {
                ProductID = foodItemService + 1,
                ImageUrl = posterLink,
                Name = EntryFoodName.Text,
                Description = EntryFoodDesc.Text,
                Rating = finalRating,
                RatingDetail = " (" + ratingCount + " ratings)",
                HomeSelected = "EmptyHeart",
                Price = decimal.Parse(decimal.Parse(EntryPrice.Text).ToString("N2")),
                CategoryID = selectedCategory.CategoryId
            });

            await Application.Current.MainPage.DisplayAlert("Created!", "The new food item was created!", "OK");
        }

        private void CatPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedCategory = picker.SelectedItem as Category;
            var selectedIndex = picker.SelectedIndex;
            if(selectedIndex != -1)
            {
                CatIdEntry.Text = "Category ID: " + (selectedCategory.CategoryId).ToString();
            }
        }

        private void EntryCatDesc_TextChanged(object sender, TextChangedEventArgs e)
        {
            int restrictCount = 25; //Enter your number of character restriction

            if (EntryFoodDesc.Text.Length > restrictCount)
            {
                EntryFoodDesc.Text = EntryFoodDesc.Text.Substring(0, restrictCount);
            }
        }
    }
}