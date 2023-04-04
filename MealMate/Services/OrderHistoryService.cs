using Firebase.Database;
using MealMate.Helpers;
using MealMate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MealMate.Services
{
    public class OrderHistoryService
    {
        FirebaseClient client;
        List<OrdersHistory> UserOrders;

        public OrderHistoryService()
        {
            client = new FirebaseClient(Constants.URL);
            UserOrders = new List<OrdersHistory>();
        }
        public async Task<List<OrdersHistory>> GetOrderAllDetailsAsync()
        {
            var orders = (await client.Child("Orders").OnceAsync<Order>())
                .Select(o => new Order()
                {
                    OrderId = o.Object.OrderId,
                    Username= o.Object.Username,
                    TotalCost = o.Object.TotalCost,
                }).ToList();

            foreach (var order in orders)
            {
                OrdersHistory oh = new OrdersHistory
                {
                    OrderId = order.OrderId,
                    Username = order.Username,
                    TotalCost = order.TotalCost
                };

                var orderDetails = (await client.Child("OrderDetails")
                    .OnceAsync<OrderDetails>())
                    .Where(o => o.Object.OrderId.Equals(order.OrderId))
                    .Select(o => new OrderDetails()
                    {
                        OrderId = o.Object.OrderId,
                        OrderDetailID = o.Object.OrderDetailID,
                        ProductID = o.Object.ProductID,
                        ProductName = o.Object.ProductName,
                        Quantity = o.Object.Quantity,
                        Price = o.Object.Price,
                    }).ToList();

                oh.AddRange(orderDetails);

                UserOrders.Add(oh);
            }

            return UserOrders;
        }

        public async Task<List<OrdersHistory>> GetOrderDetailsAsync()
        {
            var uname = Preferences.Get("Username", "Guest");
            var orders = (await client.Child("Orders").OnceAsync<Order>())
                .Where(o => o.Object.Username.Equals(uname))
                .Select(o => new Order()
                {
                    OrderId = o.Object.OrderId,
                    TotalCost = o.Object.TotalCost,
                }).ToList();

            foreach (var order in orders)
            {
                OrdersHistory oh = new OrdersHistory();
                oh.OrderId = order.OrderId;
                oh.TotalCost = order.TotalCost;

                var orderDetails = (await client.Child("OrderDetails")
                    .OnceAsync<OrderDetails>())
                    .Where(o => o.Object.OrderId.Equals(order.OrderId))
                    .Select(o => new OrderDetails()
                    {
                        OrderId = o.Object.OrderId,
                        OrderDetailID = o.Object.OrderDetailID,
                        ProductID = o.Object.ProductID,
                        ProductName = o.Object.ProductName,
                        Quantity = o.Object.Quantity,
                        Price = o.Object.Price,
                    }).ToList();

                oh.AddRange(orderDetails);

                UserOrders.Add(oh);
            }

            return UserOrders;
        }
    }
}
