using CocktailApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Data
{
    public class DrinksManager
    {
        IRestService restService;
        public DrinksManager(IRestService service)
        {
            restService = service;
        }
        public Task<List<Drink>> GetDrinksAsync(int mode, string query)
        {
            return restService.GetDrinksAsync(mode, query);
        }
        public Task<List<Category>> GetCategoriesAsync()
        {
            return restService.GetCategoriesAsync();
        }
        public Task<Ingredient> GetIngredientsAsync(string name)
        {
            return restService.GetIngredientAsync(name);
        }
        public Task<List<Drink>> GetFavoriteDrinksAsync()
        {
            return restService.GetFavoriteDrinksAsync();
        }

    }
}
