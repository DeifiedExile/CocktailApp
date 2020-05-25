using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    //This is a stupid way to do this, but I ran out of time
    public class Favorite
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
