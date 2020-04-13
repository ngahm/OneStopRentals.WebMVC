using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopRentals.Data
{
    public class Maintenance
    {
        [Key]
        public int MaintenanceID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Active { get; set; }
        public bool Permission { get; set; }


        [ForeignKey(nameof(Property))]
        public int PropertyID { get; set; }
        public virtual Property Property { get; set; }              /*FK*/
    }
}
