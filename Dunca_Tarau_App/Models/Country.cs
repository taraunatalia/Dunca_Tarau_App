using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dunca_Tarau_App.Models
{
    public class Country
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CountryName { get; set; }
        
        [OneToMany]
       public List<TourList> TourLists { get; set; }
    }
}
