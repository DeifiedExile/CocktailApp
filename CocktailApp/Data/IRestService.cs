using CocktailApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Data
{
    public interface IRestService
    {
        Task<List<Drink>> GetDrinksAsync(int mode, string query);
        Task<List<Category>> GetCategoriesAsync();
        Task<Ingredient> GetIngredientAsync(string name);
        Task<List<Drink>> GetFavoriteDrinksAsync();
    }
}
