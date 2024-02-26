using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class Order
    {
        public Order(int orderNumber, DateTime orderDate, DateTime requieredDate, DateTime shippedDate, string status, string comments, Customer customer) 
        {
            this.OrderNumber = orderNumber;
            this.OrderDate = orderDate;
            this.RequiredDate = requieredDate;
            this.ShippedDate = shippedDate;
            this.Status = status;
            this.Comments = comments;
            this.Customer = customer;
        }
        [Key]
        [Column(TypeName = "int(11)")]
        public int OrderNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime RequiredDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ShippedDate { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Status { get; set; }
        [Column(TypeName = "text")]
        public string Comments { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
