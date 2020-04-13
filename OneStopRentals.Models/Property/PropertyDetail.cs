using OneStopRentals.Models.Maintenance;
using OneStopRentals.Models.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopRentals.Models
{
    public class PropertyDetail
    {
        [Display(Name = "Property #")]
        public int PropertyID { get; set; }
        [Display(Name = "Bedroom Count")]
        public int Bedroom { get; set; }
        [Display(Name = "Bath Count")]
        public int Bath { get; set; }

        [Display(Name = "Unit Price")]
        public double ListedPrice { get; set; }

        [Display(Name = "Square Feet")]
        public int SquareFeet { get; set; }
        [Display(Name = "Available Now")]
        public bool AvailableNow { get; set; }


        public List<MaintenanceListItem> Tickets { get; set; }
        public List<POSListItem> Receipts { get; set; }


    }
}
