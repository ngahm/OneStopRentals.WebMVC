using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopRentals.Models.POS
{
    public class POSEdit
    {
        [Display(Name = "Order #")]
        public int POSID { get; set; }
        [Display(Name = "Card Type")]
        public string CardCarrier { get; set; }

        [Display(Name = "Card Number")]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime CardDate { get; set; }
        [Display(Name = "CV")]
        [StringLength(3)]
        public int CardCV { get; set; }
        [Display(Name = "Auto Pay")]
        public bool AutoPay { get; set; }
        
        
        [Display(Name = "Property #")]
        public int PropertyID { get; set; }         /*FK*/
    }
}
