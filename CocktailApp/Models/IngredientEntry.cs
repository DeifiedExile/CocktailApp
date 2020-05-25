using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    public class IngredientEntry
    {
        public string Name { get; set; }
        public string Measurement { get; set; }
        public IngredientEntry(string name, string measurement)
        {
            this.Name = name;
            this.Measurement = measurement;
        }
    }
}
