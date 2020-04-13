using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopRentals.Models
{
    public class MaintenanceDetail
    {
        [Display(Name = "Ticket Number")]
        public int MaintenanceID { get; set; }
        [Display(Name = "Topic")]
        public string Category { get; set; }

        [Display(Name = "Related Issue")]
        public string Description { get; set; }
        [Display(Name = "Active Request")]
        public bool Active { get; set; }
        [Display(Name = "Permission to Enter")]
        public bool Permission { get; set; }
    }
}
