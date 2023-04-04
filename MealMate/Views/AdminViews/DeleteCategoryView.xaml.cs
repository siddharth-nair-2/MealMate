using MealMate.Model;
using MealMate.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;
using Picker = Xamarin.Forms.Picker;

namespace MealMate.Views.AdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteCategoryView : ContentPage
    {
        public ObservableCollection<Category> Categories { get; set; }
        public DeleteCategoryView()
        {
            InitializeComponent();
            Categories = new ObservableCollection<Category>();
            GetAllCategories();
            CatPicker.ItemsSource = Categories;
            CatPicker.ItemDisplayBinding = new Binding("CategoryName");
        }
        private async void GetAllCategories()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }
        private void CatPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedCategory = picker.SelectedItem as Category;
            var selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                CatIdEntry.Text = "Category ID: " + (selectedCategory.CategoryId).ToString();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var selectedIndex = CatPicker.SelectedIndex;
            if (selectedIndex == -1)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Selection!", "Please select a valid category!", "OK");
                return;
            }

            var selectedCategory = CatPicker.SelectedItem as Category;
            bool answer = await DisplayAlert("Confirm Delete", $"The category '{selectedCategory.CategoryName}' and all its " +
                $"food items will be deleted. This CANNOT be undone. Are you sure you want to delete?", "Yes", "No");

            if (answer)
            {
                var foodItemService = await new CategoryDataService().DeleteCategory(selectedCategory.CategoryId);
                if (foodItemService)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Category and all its food items deleted successfully!", "OK");
                    GetAllCategories();
                    return;
                }
            }
            else return;
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}