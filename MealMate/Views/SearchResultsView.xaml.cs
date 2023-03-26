using MealMate.Model;
using MealMate.ViewModels;
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
	public partial class SearchResultsView : ContentPage
	{
		SearchResultsViewModel srvm;
		public SearchResultsView (string searchText)
		{
			InitializeComponent ();
			srvm = new SearchResultsViewModel(searchText);
			this.BindingContext= srvm;
            var username = Preferences.Get("Username", "Guest");
            var finalUsername = char.ToUpper(username[0]) + username.Substring(1).ToLower();
            LabelName.Text = "Welcome, " + finalUsername + "!";
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as FoodItem;
            if (selectedProduct == null) return;

            await Navigation.PushModalAsync(new ProductDetailsView(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}