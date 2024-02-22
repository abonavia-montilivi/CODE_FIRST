using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class Payment
    {
        [Key]
        [ForeignKey("Customer")]
        public int CustomerNumber { get; set; }
        public Customer Customer { get; set; }

        [Key]
        public string CheckNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
    }
}
