using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CocktailApp
{
    public class Constants
    {
        public static string BaseAddress = "https://www.thecocktaildb.com/api/json/v1/1/";
        public static string SearchNameUrl = BaseAddress + "search.php?s=";
        public static string SearchLetterUrl = BaseAddress + "search.php?f=";        
        public static string SearchDrinkDetailUrl = BaseAddress + "lookup.php?i=";
        public static string SearchByIngredientUrl = BaseAddress + "filter.php?i=";
        public static string SearchByCategoryUrl = BaseAddress + "filter.php?c=";
        public static string SearchRandomUrl = BaseAddress + "random.php";
        public static string CategoryUrl = BaseAddress + "list.php?c=list";
        public static string IngredientUrl = BaseAddress + "search.php?i=";
        public static string ApiKey = "1";
        public const string DatabaseFilename = "FavoritesSQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
