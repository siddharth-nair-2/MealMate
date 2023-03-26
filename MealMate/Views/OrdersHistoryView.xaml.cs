using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealMate.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrdersHistoryView : ContentPage
	{
		public OrdersHistoryView ()
		{
			InitializeComponent ();
            var username = Preferences.Get("Username", "Guest");
            var finalUsername = char.ToUpper(username[0]) + username.Substring(1).ToLower();
            LabelName.Text = @"Order History Of " + finalUsername + "!";
		}

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}