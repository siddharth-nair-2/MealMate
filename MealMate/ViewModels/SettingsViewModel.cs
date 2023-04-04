using MealMate.Views;
using MealMate.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MealMate.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command LogoutCommand { get; set; }
        public Command AddCategories { get; set; }
        public Command AddItems { get; set; }
        public Command ViewAllOrders { get; set; }
        public Command DeleteCategories { get; set; }
        public Command DeleteItems { get; set; }

        public SettingsViewModel()
        {
            LogoutCommand = new Command(async () => await LogoutAsync());
            AddCategories = new Command(async () => await AddCategoriesAsync());
            AddItems = new Command(async () => await AddItemsAsync());
            DeleteCategories = new Command(async () => await DeleteCategoriesAsync());
            DeleteItems= new Command(async () => await DeleteItemAsync());
            ViewAllOrders = new Command(async () => await ViewAllOrdersAsync());
        }

        private async Task DeleteCategoriesAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new DeleteCategoryView());
        }

        private async Task DeleteItemAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new DeleteItemView());
        }

        private async Task ViewAllOrdersAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ViewAllOrdersView());
        }

        private async Task AddItemsAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AddItemsView());
        }

        private async Task AddCategoriesAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AddCategoryView());
        }

        private async Task LogoutAsync()
        {
            Preferences.Remove("Username");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
        }
    }
}
