using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunca_Tarau_App.Models;
using SQLite;
using Activity = Dunca_Tarau_App.Models.Activity;

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

            _database.CreateTableAsync<Activity>().Wait();
            _database.CreateTableAsync<ListActivity>().Wait();
        }



        //TourList
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



       

        //Country
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








        //TourCategory

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


        /* protected override async void OnAppearing()
         {
             base.OnAppearing();
             listView.ItemsSource = await App.Database.GetTourCategoriesAsync();
         }*/


        //Activity

        public Task<List<Activity>> GetActivitiesAsync()
        {
            return _database.Table<Activity>().ToListAsync();
        }
        public Task<int> SaveActivityAsync(Activity activity)
        {
            if (activity.ID != 0)
            {
                return _database.UpdateAsync(activity);
            }
            else
            {
                return _database.InsertAsync(activity);
            }
        }
        public Task<int> DeleteActivityAsync(Activity activity)
        {
            return _database.DeleteAsync(activity);
        }
       


        //ListActivity

        public Task<List<ListActivity>> GetListActivitiesAsync()
        {
            return _database.Table<ListActivity>().ToListAsync();
        }
        public Task<List<ListActivity>> GetListActivities()
        {
            return _database.QueryAsync<ListActivity>("select * from ListActivity");
        }

        public Task<int> SaveListActivityAsync(ListActivity lista)
        {
            if (lista.ID != 0)
            {
                return _database.UpdateAsync(lista);
            }
            else
            {
                return _database.InsertAsync(lista);
            }
        }

        public Task<int> DeleteListActivityAsync(ListActivity lactivity)
        {
            return _database.DeleteAsync(lactivity);
        }

        public Task<List<Activity>> GetListActivitiesAsync(int tourlistid)
        {
            return _database.QueryAsync<Activity>(
            "select A.ID, A.Description from Activity A"
            + " inner join ListActivity LA"
            + " on A.ID = LA.ActivityID where LA.TourListID = ?",
            tourlistid);
        }
    }
}


    

