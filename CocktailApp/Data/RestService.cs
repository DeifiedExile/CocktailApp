using CocktailApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CocktailApp.Data
{
    class RestService : IRestService
    {
        HttpClient _client;
        public List<Drink> Drinks { get; private set; }
        public List<Category> Categories { get; private set; }
        public Ingredient _Ingredient { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", Constants.ApiKey);
        }

        public async Task<List<Drink>> GetDrinksAsync(int mode, string query)
        {
            Drinks = new List<Drink>();
            string url = "";
            switch(mode)
            {
                //search by letter
                case 1:
                    url = Constants.SearchLetterUrl + query.ToCharArray()[0];
                    break;
                //search by name
                case 2:
                    url = Constants.SearchNameUrl + query;
                    break;
                //search Drink Detail
                case 3:
                    url = Constants.SearchDrinkDetailUrl + query;
                    break;
                //search by ingredient
                case 4:
                    url = Constants.SearchByIngredientUrl + query;
                    break;
                //search by category
                case 5:
                    url = Constants.SearchByCategoryUrl + query;
                    break;
                //search random
                default:
                    url = Constants.SearchRandomUrl;
                    break;
            }
            Debug.WriteLine(url);
            var uri = new Uri(string.Format(url, string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);
                Debug.WriteLine(response.StatusCode + "\n" + response.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var drinkresult = JObject.Parse(content).SelectToken("drinks").ToString();
                    Debug.WriteLine(drinkresult);
                    Drinks = JsonConvert.DeserializeObject<List<Drink>>(drinkresult);
              

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"\tERROR {0}", e.Message);
            }
            return Drinks;
            
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            Categories = new List<Category>();

            var uri = new Uri(string.Format(Constants.CategoryUrl, string.Empty));
            try
            {
                
                var response = await _client.GetAsync(uri);
                
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var categoryResult = JObject.Parse(content).SelectToken("drinks").ToString();

                    Categories = JsonConvert.DeserializeObject<List<Category>>(categoryResult);
                }

            }
            catch(Exception e)
            {
                Debug.WriteLine(@"\tERROR {0}", e.Message);
            }
            return Categories;
        }

        public async Task<Ingredient> GetIngredientAsync(string name)
        {
            _Ingredient = new Ingredient();
            var uri = new Uri(Constants.IngredientUrl + name);
            try
            {
                var response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var ingredientResult = JObject.Parse(content).SelectToken("ingredients").ToString();
                    if(ingredientResult == null)
                    {
                        return null;
                    }
                    _Ingredient = JsonConvert.DeserializeObject<List<Ingredient>>(ingredientResult).ToList().FirstOrDefault();
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(@"\tERROR {0}", e.Message);
            }
            return _Ingredient;
        }

        public async Task<List<Drink>> GetFavoriteDrinksAsync()
        {
            List<Drink> favDrinks = new List<Drink>();
            List<Favorite> faves = await App.Database.GetFavoritesAsync();
            foreach(Favorite favorite in faves)
            {
                Drink drink = new Drink();
                drink = (await GetDrinksAsync(3, favorite.ID.ToString())).FirstOrDefault();
                favDrinks.Add(drink);
                //Drinks.Add((await GetDrinksAsync(3, favorite.ID.ToString())).FirstOrDefault());
            }
            return favDrinks;

        }
    }
}
