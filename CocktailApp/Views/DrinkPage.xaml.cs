using CocktailApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrinkPage : ContentPage, INotifyPropertyChanged
    {
        //Drink Drink { get; set; }
        int DrinkID { get; set; }
        DrinkViewModel ViewModel { get; set; }
        //public string FavoriteIcon { get; set; }
        //public string getFavIcon => FavoriteIcon;



        public DrinkPage(int drinkID)
        {
            
            //Drink = new Drink();

            DrinkID = drinkID;
            //ViewModel = viewModel;
            ViewModel = new DrinkViewModel(DrinkID);
            this.BindingContext = ViewModel;
            //ingredientsList.BindingContext = ViewModel.Drink.Ingredients;

            InitializeComponent();
        }
        //async void getFavoriteStatus()
        //{
        //    FavoriteIcon = await App.Database.IsFavorite(DrinkID) ? "FilledStar.png" : "Star.png";
        //}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //DrinkDetailPage.BindingContext = new DrinkViewModel(DrinkID);
            //Drink = (await App.DrinksManager.GetDrinksAsync(3, DrinkID.ToString())).FirstOrDefault();
            //getFavoriteStatus();

           

            //drinkDetail.BindingContext = Drink;
            //ingredientsList.ItemsSource = Drink.Ingredients;
        }

        protected override bool OnBackButtonPressed()
        {            
            return base.OnBackButtonPressed();
        }
        

        async void ingredientsList_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            if(e.Item == null)
            {
                return;
            }
            if(sender is ListView lv)
            {
                lv.SelectedItem = null;
            }
            Ingredient ingredient = await App.DrinksManager.GetIngredientsAsync(((IngredientEntry)e.Item).Name);
            if(ingredient == null)
            {
                return;
            }
            var ingredientPage = new IngredientPage(ingredient);
            await Navigation.PushAsync(ingredientPage);

        }

        private async void backbutton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine(Navigation.NavigationStack.Count().ToString());
            await Task.Delay(300);
            await Navigation.PopAsync();
        }

        

        private void HomeButton_Clicked(object sender, EventArgs e)
        {
            (Application.Current).MainPage = new NavigationPage(new MainPage());
        }

        private async void FavoritesButton_Clicked(object sender, EventArgs e)
        {
            var favPage = new FavoritesPage();
            await Navigation.PushAsync(favPage);
        }

        //private async void favoriteTItem_Clicked(object sender, EventArgs e)
        //{
        //    Favorite fav = new Favorite
        //    {
        //        ID = Drink.ID,
        //        Name = Drink.Name
        //    };
        //    await App.Database.SaveDrinkAsync(fav);
        //    getFavoriteStatus();
        //}
    }
}