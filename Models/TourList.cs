using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Java.Util.Jar.Attributes;
using SQLite;

namespace Dunca_Tarau_App.Models
{
    public class TourList
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Display(Name = "Tour Name")]
        public string Name { get; set; }
       //[MaxLength(250), Unique]
        public string Location { get; set; }
        public string GroupSize { get; set; }
        public string Time { get; set; }
        // [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartingTourDate { get; set; }
    }
}
