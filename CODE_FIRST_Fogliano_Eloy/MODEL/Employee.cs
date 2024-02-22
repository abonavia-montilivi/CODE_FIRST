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
        public int EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public Office Office { get; set; }
        public Employee ReportsTo { get; set; }
        public string JobTitle { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Employee> Reports { get; set; }
    }
}
