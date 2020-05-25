using CocktailApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {
        ObservableCollection<Drink> Drinks { get; set; }

        public FavoritesPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Drinks = new ObservableCollection<Drink>(await App.DrinksManager.GetFavoriteDrinksAsync());
            
            //foreach(Drink drink in await App.DrinksManager.GetFavoriteDrinksAsync())
            //{
            //    Drinks.Add(drink);
            //}
            resultList.ItemsSource = Drinks;
        }

        async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            Drink drink = new Drink();
            if (e.Item == null)
            {
                return;
            }
            drink = (Drink)e.Item;
            if (sender is ListView lv)
            {
                lv.SelectedItem = null;
            }
            int id = ((Drink)e.Item).ID;
            var drinkpage = new DrinkPage(id);
            await Navigation.PushAsync(drinkpage);
        }
        private void HomeButton_Clicked(object sender, EventArgs e)
        {
            (Application.Current).MainPage = new NavigationPage(new MainPage());
        }
    }
    
}