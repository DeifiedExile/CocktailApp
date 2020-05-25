using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CocktailApp.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CocktailApp.Data
{
    public class FavoritesDB
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public FavoritesDB()
        {
            InitializeAsync().SafeFireAndForget(false);

        }
        async Task InitializeAsync()
        {
            if(!initialized)
            {
                if(!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Favorite).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Favorite)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }
        public Task<List<Favorite>> GetFavoritesAsync()
        {
            return Database.Table<Favorite>().ToListAsync();
        }

        public Task<Favorite> GetDrinkAsync(int id)
        {
            return Database.Table<Favorite>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveDrinkAsync(Favorite drink)
        {

            int count = await Database.Table<Favorite>().Where(d => d.ID == drink.ID).CountAsync();
            if(count == 0)
            {
                return await Database.InsertAsync(drink);
            }

            return 0;
        }
        
        public Task<int> DeleteDrinkAsync(int drinkID)
        {
            return Database.Table<Favorite>().Where(d => d.ID == drinkID).DeleteAsync();
        }

        public async Task<bool> IsFavorite(int id)
        {
            if(await Database.Table<Favorite>().Where(d => d.ID == id).CountAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
