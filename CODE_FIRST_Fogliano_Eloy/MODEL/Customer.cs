using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class Customer
    {
        [Key]
        [Column(TypeName = "int")]
        public int CustomerNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CustomerName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ContactLastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ContactFirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string AddressLine1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string AddressLine2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string State { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string PostalCode { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "int")]
        public Employee SalesRep { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double CreditLimit { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
