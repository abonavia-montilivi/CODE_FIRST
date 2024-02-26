using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class Employee
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int EmployeeNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Extension { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(10)")]
        public Office Office { get; set; }
        [Column(TypeName = "int(11)")]
        public Employee ReportsTo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string JobTitle { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Employee> Reports { get; set; }
    }
}
