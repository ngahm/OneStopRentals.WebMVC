using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopRentals.Models
{
    public class PropertyCreate
    {
        [Display(Name = "Property #")]
        public int PropertyID { get; set; }
        [Display(Name = "Bedroom Count")]
        [Range(1, 5)]
        public int Bedroom { get; set; }
        [Display(Name = "Bath Count")]
        [Range(1, 5)]
        public int Bath { get; set; }

        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        public double ListedPrice { get; set; }
       
        [Display(Name = "Square Feet")]
        [Range(0, int.MaxValue)]
        public int SquareFeet { get; set; }
        [Display(Name = "Available Now")]
        public bool AvailableNow { get; set; }
    }
}
