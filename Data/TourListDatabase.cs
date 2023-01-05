using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunca_Tarau_App.Models;


namespace Dunca_Tarau_App.Data
{
    public class TourListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public TourListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TourList>().Wait();
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
    }
}
