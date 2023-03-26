using MealMate.Services;
using MealMate.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MealMate.ViewModels
{
    public class LogoutViewModal : BaseViewModel
    {
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

        private bool _IsCartExists;

        public bool IsCartExists
        {
            get 
            { 
                return _IsCartExists; 
            }
            set 
            { 
                _IsCartExists = value; 
                OnPropertyChanged();
            }
        }


        public Command LogoutCommand { get; set; }
        public Command GoToCartCommand { get; set; }
        public LogoutViewModal()
        {
            UserCartItemsCount = new CartItemService().GetUserCartCount();

            IsCartExists = (UserCartItemsCount > 0);

            LogoutCommand = new Command(async () => await LogoutUserAsync());
            GoToCartCommand = new Command(async () => await GoToCartAsync());
        }

        private async Task GoToCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async Task LogoutUserAsync()
        {
            var cis = new CartItemService();
            cis.RemoveCartItems();
            Preferences.Remove("Username");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
        }
    }
}
