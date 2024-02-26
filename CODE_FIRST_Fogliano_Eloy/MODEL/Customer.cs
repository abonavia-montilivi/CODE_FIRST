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
        public Customer(int CustomerNumber,string CustomerName,	string ContactLastName, string ContactFirstName, string phone, string AddressLine1, string AddressLine2, string City,	string State, string PostalCode, string Country, int SalesRep,	double CreditLimit) 
        {
            this.CustomerNumber = CustomerNumber;
            this.CustomerName = CustomerName;
            this.ContactLastName = ContactLastName;
            this.ContactFirstName = ContactFirstName;
            this.Phone = phone;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.City = City;
            this.State = State;
            this.PostalCode = PostalCode;
            this.Country = Country;
            this.SalesRepKey = SalesRep;
            this.CreditLimit = CreditLimit;		
	    }
        [Key]
        [Column(TypeName = "int")]
        public int CustomerNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CustomerName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ContactLastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ContactFirstName { get; set; }
        [Column(TypeName="varchar(50)")]
        public string Phone { get; set; }
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
        public int SalesRepKey { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double CreditLimit { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
