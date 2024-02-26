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
        [Column(TypeName = "varchar(50)")]
        public string CheckNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double Amount { get; set; }
    }
}
