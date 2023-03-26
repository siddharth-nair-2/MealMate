using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealMate.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrdersView : ContentPage
	{
		public OrdersView (string id)
		{
			InitializeComponent ();
            var username = Preferences.Get("Username", "Guest");
            var finalUsername = char.ToUpper(username[0]) + username.Substring(1).ToLower();
            LabelName.Text = "Welcome, " + finalUsername + "!";
            LabelOrderID.Text = id;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductsView());
        }
    }
}