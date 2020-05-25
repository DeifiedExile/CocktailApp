using CocktailApp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    [JsonConverter(typeof(IngredientResultConverter))]
    public class Ingredient
    {
        //[JsonProperty(PropertyName = "idIngredient")]
        public int ID { get; set; }
        //[JsonProperty(PropertyName = "strIngredient")]
        public string Name { get; set; }
        //[JsonProperty(PropertyName = "strDescription")]
        public string Description { get; set; }
        //[JsonProperty(PropertyName = "strType")]
        public string Type { get; set; }
        //[JsonProperty(PropertyName = "strAlcohol")]
        public bool isAlcoholic { get; set; }
        //[JsonProperty(PropertyName = "strABV")]
        public int? ABV { get; set; }
        
    }
}
