using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class Product
    {
        [Key]
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public ProductLine ProductLine { get; set; }
        public string ProductScale { get; set; }
        public string ProductVendor { get; set; }
        public string ProductDescription { get; set; }
        public int QuantityInStock { get; set; }
        public double BuyPrice { get; set; }
        public double MSRP { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
