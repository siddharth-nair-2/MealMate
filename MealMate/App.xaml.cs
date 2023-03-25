using MealMate.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealMate
{
    public partial class App : Application
    {
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
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
