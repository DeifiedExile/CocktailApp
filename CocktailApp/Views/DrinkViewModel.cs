using CocktailApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CocktailApp.Views
{
    public class DrinkViewModel : INotifyPropertyChanged
    {
        public string FavoriteIcon { get; set; } = "star.png";
        public string GetIcon => FavoriteStatus ? "FilledStar.png" : "Star.png";
        public bool FavoriteStatus { get; set; }
        public Drink Drink { get; set; }
        public int DrinkID { get; set; }
        public List<IngredientEntry> DrinkIngredients => Drink.Ingredients;
        public ICommand ToggleFavoriteCommand { get; set; }
        public string test { get; set; } = "test text";


        public DrinkViewModel(int id)
        {
            Drink = new Drink();
            DrinkID = id;
            getDrinkDetails(id);
            //isFavorite(id);
            ToggleFavoriteCommand = new Command(ToggleFavorite);            
        }
        
        async void ToggleFavorite()
        {
            if(FavoriteStatus)
            {
                await App.Database.DeleteDrinkAsync(Drink.ID);
                FavoriteStatus = false;                
            }
            else
            {
                Favorite favorite = new Favorite
                {
                    ID = Drink.ID,
                    Name = Drink.Name
                };
                await App.Database.SaveDrinkAsync(favorite);
                FavoriteStatus = true;
            }
            
            OnStatusChanged(nameof(GetIcon));
        }

        async void getDrinkDetails(int id)
        {
            Drink = (await App.DrinksManager.GetDrinksAsync(3, DrinkID.ToString())).FirstOrDefault();
            OnStatusChanged(nameof(Drink));
            FavoriteStatus = await isFavorite(id);
            OnStatusChanged(nameof(GetIcon));

        }
        
        //async void setIcon()
        //{
        //    FavoriteIcon = FavoriteStatus ? "FilledStar.png" : "Star.png";
        //    OnStatusChanged(nameof(GetIcon));
        //}

        async Task<bool> isFavorite(int id)
        {

            if(await App.Database.IsFavorite(id))
            {
                //FavoriteIcon = "FilledStar.png";
                return true;
            }
            else
            {
                //FavoriteIcon = "Star.png";
                return false;
            }

            //FavoriteIcon = await App.Database.IsFavorite(id) ? "FilledStar.png" : "Star.png";
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnStatusChanged([CallerMemberName] string propertyName = null)
        {
            //setIcon();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
