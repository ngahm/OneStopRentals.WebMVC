using OneStopRentals.WebMVC.Models;
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
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }
        [Required]
        public int Bedroom { get; set; }
        [Required]
        public int Bath { get; set; }
        [Required]
        public double ListedPrice { get; set; }
        [Required]
        public int SquareFeet { get; set; }
        [Required]
        public bool AvailableNow { get; set; }


        public virtual ICollection<Maintenance> MyTickets { get; set; }
        public virtual ICollection<POS> MyReceipts { get; set; }


        //[ForeignKey(nameof(Requests))]
        //public int MaintenanceID { get; set; }                     /*Could also make FK by Name*/
        //public virtual Maintenance Maintenance { get; set; }

        //[ForeignKey(nameof(Sales))]
        //public int POSID { get; set; }                              /*Could also make FK by Name*/
        //public virtual POS POS { get; set; }

        
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

       



    }
}
