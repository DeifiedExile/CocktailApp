using CocktailApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Data
{
    class DrinkResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Drink));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Drink drinkResult = new Drink();
            JToken token;
            drinkResult.ID = int.Parse(obj["idDrink"].ToString());
            drinkResult.Name = (string)obj["strDrink"];
            drinkResult.AltName = (string)obj["strDrinkAlternate"];
            drinkResult.NameDE = (string)obj["strDrinkDE"];
            drinkResult.NameES = (string)obj["strDrinkES"];
            drinkResult.NameFR = (string)obj["strDrinkFR"];
            drinkResult.NameZHHANS = (string)obj["strDrinkZH-HANS"];
            drinkResult.NameZHHANT = (string)obj["strDrinkZH-HANT"];
            token = obj["strTags"];
            if(token != null)
            {
                drinkResult.Tags = obj["strTags"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            
            drinkResult.Video = (string)obj["strVideo"];
            drinkResult.Category = (string)obj["strCategory"];
            drinkResult.IBA = (string)obj["strIBA"];
            drinkResult.Alcoholic = (string)obj["strAlcoholic"];
            drinkResult.Glass = (string)obj["strGlass"];
            drinkResult.Instructions = (string)obj["strInstructions"] == null ? "" : (string)obj["strInstructions"];
            drinkResult.InstructionsES = (string)obj["strInstructionsES"];
            drinkResult.InstructionsDE = (string)obj["strInstructionsDE"];
            drinkResult.InstructionsFR = (string)obj["strInstructionsFR"];
            drinkResult.InstructionsZHHANS = (string)obj["strInstructionsZH-HANS"];
            drinkResult.InstructionsZHHANT = (string)obj["strInstructionsZH-HANT"];
            drinkResult.Thumbnail = (string)obj["strDrinkThumb"] == null ? "" : (string)obj["strDrinkThumb"];
            drinkResult.CreativeCommonsConfirmed = (string)obj["strCreativeCommonsConfirmed"];
            token = obj["dateModified"];
            if(token != null)
            {
                drinkResult.DateModified = obj["dateModified"] == null || obj["dateModified"].ToString().Length < 1 ? DateTime.MinValue : DateTime.Parse((string)obj["dateModified"]);
            }
            
            drinkResult.Ingredients = new List<IngredientEntry>();

            for(int i = 1; i < 16; i++)
            {
                string index = i.ToString();
                if (obj["strIngredient" + index] != null && obj["strIngredient" + index].ToString().Length > 0)
                {                    
                    //IngredientEntry entry = new IngredientEntry((string)obj["strIngredient" + index], (string)obj["strMeasure" + index]);
                    //drinkResult.Ingredients.Add(entry);
                    drinkResult.Ingredients.Add(new IngredientEntry((string)obj["strIngredient" + index], (string)obj["strMeasure" + index]));
                }
                else
                {
                    break;
                }
            }            

            return drinkResult;


        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
