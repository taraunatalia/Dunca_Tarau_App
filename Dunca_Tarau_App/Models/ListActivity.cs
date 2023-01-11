using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Dunca_Tarau_App.Models
{
    public class ListActivity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(TourList))]
        public int TourListID { get; set; }
        public int ActivityID { get; set; }
    }
}
