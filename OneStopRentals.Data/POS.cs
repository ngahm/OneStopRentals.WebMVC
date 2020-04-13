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
    public class POS
    {
        [Key]
        public int POSID { get; set; }
        [Required]
        public string CardCarrier { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public DateTime CardDate { get; set; }
        [Required]
        public int CardCV { get; set; }
        public bool AutoPay { get; set; }
        [Required]
        public DateTimeOffset PaymentTime
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }

        [ForeignKey(nameof(Property))]
        public int PropertyID { get; set; }
        public virtual Property Property { get; set; }          /*FK*/
    }
}
