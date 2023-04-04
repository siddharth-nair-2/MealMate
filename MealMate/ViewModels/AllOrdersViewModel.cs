using MealMate.Model;
using MealMate.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MealMate.ViewModels
{
    public class AllOrdersViewModel : BaseViewModel
    {
        public ObservableCollection<OrdersHistory> OrderDetails { get; set; }

        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        public AllOrdersViewModel()
        {
            OrderDetails = new ObservableCollection<OrdersHistory>();
            LoadAllOrders();
        }

        private async void LoadAllOrders()
        {
            try
            {
                IsBusy = true;
                OrderDetails.Clear();
                var service = new OrderHistoryService();
                var details = await service.GetOrderAllDetailsAsync();
                foreach (var order in details)
                {
                    OrderDetails.Add(order);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
