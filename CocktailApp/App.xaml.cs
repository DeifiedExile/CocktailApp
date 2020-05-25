using CocktailApp.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailApp
{
    public partial class App : Application
    {
        public static DrinksManager DrinksManager { get; private set; }
        static FavoritesDB database;
        public App()
        {
            InitializeComponent();
            DrinksManager = new DrinksManager(new RestService());
            var nav = new NavigationPage(new MainPage());
            MainPage = nav;
        }
        public static FavoritesDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new FavoritesDB();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
