using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class OrderDetail
    {
        [Key]
        [ForeignKey("Order")]
        public int OrderNumber { get; set; }
        public Order Order { get; set; }

        [Key]
        [ForeignKey("Product")]
        public string ProductCode { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "int(11)")]
        public int QuantityOrdered { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double PriceEach { get; set; }
        [Column(TypeName = "smallint(6)")]
        public int OrderLineNumber { get; set; }
    }
}
