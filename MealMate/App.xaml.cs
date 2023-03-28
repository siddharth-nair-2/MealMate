using MealMate.Model;
using MealMate.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealMate
{
    public partial class App : Application
    {
        public static bool isCartTableCreated = Preferences.Get("isCartItemTableCreated", false);
        public App()
        {
            InitializeComponent();

            //MainPage = new LoginView();
            string username = Preferences.Get("Username", String.Empty);

            //MainPage= new NavigationPage(new SettingsPage());

            if (String.IsNullOrEmpty(username))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new ProductsView();
            }
        }

        protected override void OnStart()
        {
            if(isCartTableCreated == false) 
            {
                var cn = DependencyService.Get<ISQLite>().GetConnection();
                cn.CreateTable<CartItem>();
                cn.Close();
                Preferences.Set("isCartItemTableCreated", true);
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
