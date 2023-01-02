using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dunca_Tarau_App.Models
{
    public class TourCategory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TourCategoryName { get; set; }

        [OneToMany]
        public List<TourList> TourLists { get; set; }
    }
}
