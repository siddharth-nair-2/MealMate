using MealMate.Model;
using MealMate.Services;
using MealMate.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealMate.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableCollection<UserCartItem> CartItems { get; set; }

		private decimal _TotalCost;
		public decimal TotalCost
		{
			get 
			{ 
				return _TotalCost; 
			}
			set 
			{ 
				_TotalCost = value; 
				OnPropertyChanged();
			}
		}

		public Command PlaceOrdersCommand { get; set; }

		public CartViewModel()
		{
			CartItems = new ObservableCollection<UserCartItem>();
			LoadItems();
			PlaceOrdersCommand = new Command(async () => await PlaceOrdersAsync());
		}

        private async Task PlaceOrdersAsync()
        {
			if(CartItems.Count < 1 || CartItems == null)
			{
				await Application.Current.MainPage.DisplayAlert("Empty Cart!", "Please add items to the cart to order!", "OK");
				return;
			}
			var id = await new OrderService().PlaceOrderAsync() as string;
			RemoveItemsFromCart();
			await Application.Current.MainPage.Navigation.PushModalAsync(new OrdersView(id));
        }

        private void RemoveItemsFromCart()
        {
			var cis = new CartItemService();
			cis.RemoveCartItems();
        }

        private void LoadItems()
        {
			var cn = DependencyService.Get<ISQLite>().GetConnection();
			var items = cn.Table<CartItem>().ToList();
			CartItems.Clear();
			foreach (var item in items) 
			{
				CartItems.Add(new UserCartItem()
				{
					CartItemId = item.CartItemId,
					ProductId= item.ProductId,
					ProductName= item.ProductName,
					Price= item.Price,
					Quantity= item.Quantity,
					Cost = item.Price * item.Quantity
				});

				TotalCost += (item.Price * item.Quantity);
			}
        }
    }
}
