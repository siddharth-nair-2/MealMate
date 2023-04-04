using MealMate.Model;
using MealMate.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealMate.Views.AdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteItemView : ContentPage
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<FoodItem> FoodItems{ get; set; }
        public DeleteItemView()
        {
            InitializeComponent();
            Categories = new ObservableCollection<Category>();
            FoodItems = new ObservableCollection<FoodItem>();
            GetAllCategories();
            CatPicker.ItemsSource = Categories;
            CatPicker.ItemDisplayBinding = new Binding("CategoryName");
            FoodPicker.ItemsSource = FoodItems;
            FoodPicker.ItemDisplayBinding = new Binding("Name");
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
        private async void GetFoodItemsFromCategory(int catID)
        {
            var data = await new FoodItemService().GetFoodItemsByCategoryAsync(catID);
            FoodItems.Clear();
            foreach (var item in data)
            {
                FoodItems.Add(item);
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
                GetFoodItemsFromCategory(selectedCategory.CategoryId);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var selectedIndexCat = CatPicker.SelectedIndex;
            var selectedIndexfood = FoodPicker.SelectedIndex;
            if (selectedIndexCat == -1 || selectedIndexfood == -1)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Selection!", "Please select a valid category and Food Item!", "OK");
                return;
            }

            var selectedFoodItem = FoodPicker.SelectedItem as FoodItem;
            bool answer = await DisplayAlert("Confirm Delete", $"The food item '{selectedFoodItem.Name}' will be deleted. " +
                $"This CANNOT be undone. Are you sure you want to delete?", "Yes", "No");

            if (answer)
            {
                var foodItemService = await new FoodItemService().DeleteFoodItem(selectedFoodItem.ProductID);
                if (foodItemService)
                {
                    await Application.Current.MainPage.DisplayAlert("Success!", "Food Item deleted successfully!", "OK");
                    GetAllCategories();
                    FoodItems.Clear();
                    return;
                }
            }
            else return;
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void FoodPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedFoodItem = picker.SelectedItem as FoodItem;
            var selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                FoodIdEntry.Text = "Food Item ID: " + (selectedFoodItem.ProductID).ToString();
            }
        }
    }

}