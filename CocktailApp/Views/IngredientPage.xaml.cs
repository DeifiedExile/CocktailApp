using CocktailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientPage : ContentPage
    {
        Ingredient Ingredient;
        
        public IngredientPage(Ingredient ingredient)
        {
            Ingredient = ingredient;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            iDetailStack.BindingContext = Ingredient; //App.DrinksManager.GetIngredientsAsync(IName);
        }

        private void backButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
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
    }
}