using CocktailApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CocktailApp.Data
{
    class IngredientResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Ingredient));
        }

        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Ingredient iResult = new Ingredient();
            //JToken token;
            iResult.ID = int.Parse(obj["idIngredient"].ToString());
            iResult.Name = (string)obj["strIngredient"];
            iResult.Description = (string)obj["strDescription"];
            iResult.Type = (string)obj["strType"];
            
            iResult.isAlcoholic =  ((string)obj["strAlcohol"] == null || ((string)obj["strAlcohol"]).Trim().Equals("Yes")) ? true : false;
            //if(obj.Value<string>("strAlcohol") == null)
            //{
            //    Debug.WriteLine("true");
            //}
            //token = obj["strABV"];
            //iResult.ABV = (int)(token.Value ?? 0);
            iResult.ABV = ((string)obj["strABV"]) == null ? 0 : int.Parse(obj["strABV"].ToString());
            return iResult;
        }

        public override void WriteJson(JsonWriter writer,  object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
