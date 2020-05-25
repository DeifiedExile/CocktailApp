using CocktailApp.Models;
using CocktailApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CocktailApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        //private bool FetchingData, NoItems;
        //List<Drink> drinks { get; set; }

        ObservableCollection<Drink> Drinks { get; set; }
        ObservableCollection<Category> Categories { get; set; }

        public MainPage()
        {
            //FetchingData = true;
            //drinks = new List<Drink>();
            

            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Drinks = new ObservableCollection<Drink>();
            Categories = new ObservableCollection<Category>();
            //categoryPicker.SelectedIndex = -1;
            //resultList.SelectedItem = null;
            if (Categories.Count < 1)
            {
                Categories = new ObservableCollection<Category>(await App.DrinksManager.GetCategoriesAsync());
            }
            categoryPicker.ItemsSource = Categories;
            
            
        }

        private async void categoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryPicker.SelectedIndex > -1)
            {
                //FetchingData = false;
                Drinks.Clear();
                //string test = categoryPicker.Items[categoryPicker.SelectedIndex];
                Drinks = new ObservableCollection<Drink>(await App.DrinksManager.GetDrinksAsync(5, categoryPicker.Items[categoryPicker.SelectedIndex]));
                if(!Drinks.Any())
                {
                    return;
                }
                //drinks = await App.DrinksManager.GetDrinksAsync(5, e.ToString());
                //if(drinks.Any())
                //{
                //    NoItems = false;
                //}
                //else
                //{
                //    NoItems = true;
                //}
                resultList.ItemsSource = Drinks;
            }
            
        }

        private async void searchBtn_Clicked(object sender, EventArgs e)
        {
            if(searchEntry.Text.Trim().Length > 0)
            {
                //FetchingData = false;
                string searchTerm = searchEntry.Text.Trim();
                Drinks.Clear();
                Drinks = new ObservableCollection<Drink>(await App.DrinksManager.GetDrinksAsync(2, searchTerm));
                //drinks = await App.DrinksManager.GetDrinksAsync(2, searchTerm);
                //if (drinks.Any())
                //{
                //    NoItems = false;
                //}
                //else
                //{
                //    NoItems = true;
                //}
                resultList.ItemsSource = Drinks;
                //resultList.r
            }
        }

        async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            Drink drink = new Drink();
            if(e.Item == null)
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
        private async void FavoritesButton_Clicked(object sender, EventArgs e)
        {
            var favPage = new FavoritesPage();
            await Navigation.PushAsync(favPage);
        }
    }
}
