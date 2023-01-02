using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunca_Tarau_App.Models;
using SQLite;

namespace Dunca_Tarau_App.Data
{
    public class TourListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public TourListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TourList>().Wait();

            _database.CreateTableAsync<Country>().Wait();
            _database.CreateTableAsync<TourCategory>().Wait();
        }




        public Task<List<TourList>> GetTourListsAsync()
        {
            return _database.Table<TourList>().ToListAsync();
        }
        public Task<TourList> GetTourListAsync(int id)
        {
            return _database.Table<TourList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveTourListAsync(TourList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteTourListAsync(TourList slist)
        {
            return _database.DeleteAsync(slist);
        }






        public Task<List<Country>> GetCountriesAsync()
        {
            return _database.Table<Country>().ToListAsync();
        }
        public Task<int> SaveCountryAsync(Country country)
        {
            if (country.ID != 0)
            {
                return _database.UpdateAsync(country);
            }
            else
            {
                return _database.InsertAsync(country);
            }
        }
        public Task<int> DeleteCountryAsync(Country slist)
        {
            return _database.DeleteAsync(slist);
        }










        public Task<List<TourCategory>> GetTourCategoriesAsync()
        {
            return _database.Table<TourCategory>().ToListAsync();
        }
        public Task<int> SaveTourCategoryAsync(TourCategory tourCategory)
        {
            if (tourCategory.ID != 0)
            {
                return _database.UpdateAsync(tourCategory);
            }
            else
            {
                return _database.InsertAsync(tourCategory);
            }
        }
        public Task<int> DeleteTourCategoryAsync(TourCategory slist)
        {
            return _database.DeleteAsync(slist);
        }


    }
}
