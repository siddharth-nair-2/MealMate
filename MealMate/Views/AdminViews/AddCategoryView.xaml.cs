using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using MealMate.Helpers;
using MealMate.Model;
using MealMate.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategoryView : ContentPage
    {
        public AddCategoryView()
        {
            InitializeComponent();
        }

        FileResult poster;
        FileResult icon;
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

        private async void IconButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (photo == null) return;

            icon = photo;
            var stream = await photo.OpenReadAsync();
            var showIcon = ImageSource.FromStream(() => stream);
            iconImage.Source = showIcon;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(poster == null || icon == null)
            {
                await Application.Current.MainPage.DisplayAlert("No Image!", "Please upload a poster and an icon for the category!", "OK");
                return;
            }
            if(EntryCatName.Text == null || EntryCatName.Text.Length < 1)
            {
                await Application.Current.MainPage.DisplayAlert("No Name!", "Please enter a valid name for the category!", "OK");
                return;
            }


            var totalCategories = await new CategoryDataService().GetCategoriesAsync();

            foreach(Category category in totalCategories)
            {
                if(category.CategoryName.Trim() == EntryCatName.Text.Trim())
                {
                    await Application.Current.MainPage.DisplayAlert("Already Exists!", "Please enter a different name for the category!", "OK");
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
                .Child("Categories")
                .Child(EntryCatName.Text)
                .Child("Poster")
                .Child(poster.FileName)
                .PutAsync(await poster.OpenReadAsync());

            var posterLink = await taskPoster;

            var taskIcon = new FirebaseStorage("mealmate-61db7.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true,
                })
                .Child("Categories")
                .Child(EntryCatName.Text)
                .Child("Icon")
                .Child(icon.FileName)
                .PutAsync(await icon.OpenReadAsync());

            var iconLink = await taskIcon;

            var categoryService = await new CategoryDataService().CategoryMaxID();

            await client.Child("Categories").PostAsync(new Category()
            {
                CategoryId = categoryService + 1,
                CategoryName = EntryCatName.Text,
                CategoryPoster = posterLink,
                ImageUrl = iconLink
            });


            await Application.Current.MainPage.DisplayAlert("Created!", "The new category was created!", "OK");

        }

        private void EntryCatName_TextChanged(object sender, TextChangedEventArgs e)
        {
            int restrictCount = 15; //Enter your number of character restriction
            
            if(EntryCatName.Text.Length > restrictCount)
            {
                EntryCatName.Text = EntryCatName.Text.Substring(0, restrictCount);
            }
        }
    }
}