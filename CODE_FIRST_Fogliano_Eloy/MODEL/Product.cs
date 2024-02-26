using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class Product
    {
        public Product() 
        {
        
        }

        [Key]
        [Column(TypeName = "varchar(15)")]
        public string ProductCode { get; set; }
        [Column(TypeName = "varchar(70)")]
        public string ProductName { get; set; }
        [ForeignKey("productLine")]
        public ProductLine ProductLine { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string ProductScale { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ProductVendor { get; set; }
        [Column(TypeName = "text")]
        public string ProductDescription { get; set; }
        [Column(TypeName = "smallint")]
        public int QuantityInStock { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double BuyPrice { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double MSRP { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
