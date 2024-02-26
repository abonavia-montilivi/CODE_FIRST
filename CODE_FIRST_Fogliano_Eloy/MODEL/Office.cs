using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class Office
    {
        public Office(string officeCode, string city, string phone, string addressLine1, string addressLine2, string state, string country, string postalCode, string territory) 
        {
            this.OfficeCode = officeCode;
            this.City = city;
            this.Phone = phone;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.State = state;
            this.Country = country;
            this.PostalCode = postalCode;
            this.Territory = territory;
        }
        [Key]
        public string OfficeCode { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string AddressLine1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string AddressLine2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string State { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string PostalCode { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Territory { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
