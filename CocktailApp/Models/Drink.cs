using CocktailApp.Data;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    [JsonConverter(typeof(DrinkResultConverter))]
    public class Drink
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string AltName { get; set; }
        public string NameES { get; set; }
        public string NameDE { get; set; }
        public string NameFR { get; set; }
        public string NameZHHANS { get; set; }
        public string NameZHHANT { get; set; }
        public string[] Tags { get; set; }
        public string Video { get; set; }
        public string Category { get; set; }
        public string IBA { get; set; }
        public string Alcoholic { get; set; }
        public string Glass { get; set; }
        public string Instructions { get; set; }
        public string InstructionsES { get; set; }
        public string InstructionsDE { get; set; }
        public string InstructionsFR { get; set; }
        public string InstructionsZHHANS { get; set; }
        public string InstructionsZHHANT { get; set; }
        public string Thumbnail { get; set; }                
        public List<IngredientEntry> Ingredients { get; set; }
        public string CreativeCommonsConfirmed { get; set; }
        public DateTime DateModified { get; set; }

        

        
        

    }
}
