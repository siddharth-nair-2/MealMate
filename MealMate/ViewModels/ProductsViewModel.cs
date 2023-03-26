using MealMate.Model;
using MealMate.Services;
using MealMate.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MealMate.ViewModels
{
	public class ProductsViewModel : BaseViewModel
	{
		private string _UserName;
		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				_UserName = value;
				OnPropertyChanged();

			}
		}

		private int _UserCartItemsCount;
		public int UserCartItemsCount
		{
			get
			{
				return _UserCartItemsCount;
			}
			set
			{
				_UserCartItemsCount = value;
				OnPropertyChanged();
			}
		}

		private string _SearchText;

		public string SearchText
		{
			get { return _SearchText; }
			set 
			{ 
				_SearchText = value;
				OnPropertyChanged();
			}
		}


		public ObservableCollection<Category> Categories { get; set; }
		public ObservableCollection<FoodItem> LatestItems { get; set; }

		public Command ViewCartCommand { get; set; }
        public Command OrdersHistoryCommand { get; set; }
        public Command LogoutCommand { get; set; }
        public Command SearchViewCommand { get; set; }
        public ProductsViewModel()
		{
			var username = Preferences.Get("Username", String.Empty);
			if (String.IsNullOrEmpty(username))
			{
				UserName = "Guest";
			}
			else
			{
				UserName = username;
			}

			UserCartItemsCount = new CartItemService().GetUserCartCount();

			Categories= new ObservableCollection<Category>();
			LatestItems = new ObservableCollection<FoodItem>();

			ViewCartCommand = new Command(async () => await ViewCartAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());
			OrdersHistoryCommand = new Command(async () => await OrdersHistoyAsync());
			SearchViewCommand = new Command(async () => await SearchViewAsync());

            GetCategories();
			GetLatestItems();
		}

        private async Task SearchViewAsync()
        {
            UserCartItemsCount = new CartItemService().GetUserCartCount();
            await Application.Current.MainPage.Navigation.PushModalAsync(new SearchResultsView(SearchText));
        }

        private async Task OrdersHistoyAsync()
        {
            UserCartItemsCount = new CartItemService().GetUserCartCount();
            await Application.Current.MainPage.Navigation.PushModalAsync(new OrdersHistoryView());
        }

        private async Task LogoutAsync()
        {
            UserCartItemsCount = new CartItemService().GetUserCartCount();
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        private async Task ViewCartAsync()
        {
            UserCartItemsCount = new CartItemService().GetUserCartCount();
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async void GetCategories()
        {
			var data = await new CategoryDataService().GetCategoriesAsync();
			Categories.Clear();
			foreach (var item in data)
			{
				Categories.Add(item);
			}
        }

        private async void GetLatestItems()
        {
            var data = await new FoodItemService().GetLatestFoodItemsAsync();
            LatestItems.Clear();
            foreach (var item in data)
            {
                LatestItems.Add(item);
            }
        }
    }
}
