﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class Employee
    {
        public Employee(int employeeNumber, string lastName, string firstName, string extension, string email, string OfficeKey, int? ReportsToKey, string JobTitle) 
        {
            this.EmployeeNumber = employeeNumber;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Extension = extension;
            this.Email = email;
            this.OfficeKey = OfficeKey;
            this.ReportsToKey = ReportsToKey;            
            this.JobTitle = JobTitle;
        }
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

        [ForeignKey("Office")]
        public string OfficeKey { get; set; }
        public Office Office { get; set; }

        [ForeignKey("Employee")]
        public int? ReportsToKey { get; set; }
        public Employee? ReportsTo { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string JobTitle { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Employee> Reports { get; set; }
    }
}
