using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Dunca_Tarau_App.Models
{
    public class TourList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250), Unique]
        public string TourDescription { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(typeof(Country))]
        public int CountryID { get; set; }
        [ForeignKey(typeof(TourCategory))]
        public int TourCategoryID { get; set; }
    }
}
