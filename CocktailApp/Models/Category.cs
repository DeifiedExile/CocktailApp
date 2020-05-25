using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    public class Category
    {
        [JsonProperty("strCategory")]
        public string Name { get; set; }
    }
}
