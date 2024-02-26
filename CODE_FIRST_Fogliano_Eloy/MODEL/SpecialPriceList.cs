using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class SpecialPriceList
    {
        public int CustomerId { get; set; }
        public string ProductCode { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customers { get; set; }
        [ForeignKey("ProductCode")]
        public virtual Product Products { get; set; }
    }


}
