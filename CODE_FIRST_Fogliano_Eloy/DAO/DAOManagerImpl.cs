﻿using CODE_FIRST_Fogliano_Eloy.MODEL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace CODE_FIRST_Fogliano_Eloy.DAO
{
    internal class DAOManagerImpl : IDAOManager
    {
        private MODEL.ClassicModelsDBContext context = null;
        public DAOManagerImpl(MODEL.ClassicModelsDBContext context)
        {
            this.context = context;

            //using (context)
            //{

            //    // Query customers from France order by credit limit
            //    var customersWithName = context.Customers.Where(c => c.Country == "France").OrderBy(c => c.CreditLimit).ToList();

            //    //filtering and sorting
            //    var filteredProducts = context.Products.Where(p => p.QuantityInStock >= 2000 && p.MSRP < 100).OrderBy(p => p.ProductName).ToList();

            //    //joining entities
            //    var customerPayments = context.Customers
            //        .Join(context.Payments,
            //        customer => customer.CustomerNumber,
            //        payment => payment.CustomerNumber,
            //        (customer, payment) => new
            //        {
            //            CustomerName = customer.CustomerName,
            //            PaymentAmount = payment.Amount

            //        })
            //        .ToList();

            //    //agregation and grouping

            //    var employeesPerOffice = context.Employees
            //      .GroupBy(e => e.Office)
            //      .Select(o => new
            //      {
            //          OfficeCode = o.Key,
            //          EmployeeCount = o.Count()
            //      })
            //     .ToList();


            //}
        }
		#region Eric
		public List<MODEL.Customer> CustomersFromFrance()
        {
            // Query customers from France order by credit limit
            return context.Customers.Where(c => c.Country == "France").OrderBy(c => c.CreditLimit).ToList();
        }
        public List<MODEL.Product> ProductsByQuantityAndMsrp()
        {
            //filtering and sorting
            return context.Products.Where(p => p.QuantityInStock >= 2000 && p.MSRP < 100).OrderBy(p => p.ProductName).ToList();
        }
        public Object PaymentsPerCustomer()
        {
            //joining entities
            return context.Customers
                    .Join(context.Payments,
                    customer => customer.CustomerNumber,
                    payment => payment.CustomerNumber,
                    (customer, payment) => new
                    {
                        CustomerName = customer.CustomerName,
                        PaymentAmount = payment.Amount

                    })
                    .ToList();
        }

        public Object EmployeesPerOffice()
        {
            //agregation and grouping
            return context.Employees
                  .GroupBy(e => e.Office)
                  .Select(o => new
                  {
                      OfficeCode = o.Key,
                      EmployeeCount = o.Count()
                  })
                 .ToList();
        }
		#endregion
		#region adds
		public void AddOrders(string file)
        {
			StreamReader sr = new StreamReader(file);

			string line = sr.ReadLine();
			line = sr.ReadLine();

			while (line != null)
			{
				string[] fields = Regex.Split(line, @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))");

				int orderNumber = int.Parse(fields[0].Trim('"'));
				DateTime orderDate = DateTime.Parse(fields[1].Trim('"'));
				DateTime requiredDate = DateTime.Parse(fields[2].Trim('"'));
                DateTime? shippedDate = null;
                if (fields[3].Trim('"') != "NULL") 
				shippedDate = DateTime.Parse(fields[3].Trim('"'));
				string status = fields[4].Trim('"');
				string comments = fields[5] == "NULL" ? null : fields[5].Trim('"');
				int customerKey = int.Parse(fields[6].Trim('"'));

				Customer customer = context.Customers.Find(customerKey);				

				Order order = new Order(orderNumber, orderDate, requiredDate, shippedDate, status, comments, customerKey);
				order.Customer = customer;

				context.Orders.Add(order);
				context.SaveChanges();

				line = sr.ReadLine();
			}

			sr.Close();
		}

        public void AddCustomers(string file)
        {
			StreamReader sr = new StreamReader(file);

			string line = sr.ReadLine(); 
			line = sr.ReadLine(); 

			while (line != null)
			{
				string[] fields = Regex.Split(line, @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))");

				int customerNumber = int.Parse(fields[0].Trim('"'));
				string customerName = fields[1].Trim('"');
                if (customerNumber == 125)
                    Console.WriteLine(); ;
				string contactLastName = fields[2].Trim('"');
				string contactFirstName = fields[3].Trim('"');
				string phone = fields[4].Trim('"');
				string addressLine1 = fields[5].Trim('"');
				string addressLine2 = fields[6].Trim('"');
                if (addressLine2 == "NULL") addressLine2 = null;
                string city = fields[7].Trim('"');
				string state = fields[8].Trim('"');
                if (state == "NULL") state = null;
				string postalCode = fields[9].Trim('"');
                if (postalCode == "NULL") postalCode = null;
				string country = fields[10].Trim('"');

				int? salesRepKey = fields[11] == "NULL" ? null : int.Parse(fields[11].Trim('"'));
				double creditLimit = double.Parse(fields[12].Trim('"'), CultureInfo.InvariantCulture);

				Employee salesRep = context.Employees.Find(salesRepKey);

				Customer customer = new Customer(customerNumber, customerName, contactLastName, contactFirstName, phone, addressLine1, addressLine2, city, state, postalCode, country, salesRepKey, creditLimit);
				customer.SalesRep = salesRep;

				context.Customers.Add(customer);
				context.SaveChanges();

				line = sr.ReadLine();
			}

			sr.Close();
		}
        public void AddEmployees(string textFile)
        {
            StreamReader sr = new StreamReader(textFile);

            string line = sr.ReadLine();
            line = sr.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                int employeeNumber = int.Parse(fields[0].Trim('"'));
                string lastName = fields[1].Trim('"');
                string firstName = fields[2].Trim('"');
                string extension = fields[3].Trim('"');
                string email = fields[4].Trim('"');
                Office office = context.Offices.Find(fields[5].Trim('"'));
                Employee reportsTo = null;
                int report= 0;
                if (fields[6].Trim('"') == "NULL")
                {
                    //Employee reports = new Employee(0, "", "","","","",1,"");
                    //context.Employees.Add(reports);
                    //context.SaveChanges();
                    report = 0;
                }
                else
                {
					reportsTo = context.Employees.Find(int.Parse(fields[6].Trim('"')));
					report = reportsTo.EmployeeNumber;
				}
                string jobTittle = fields[7].Trim('"');

                Employee employee = new Employee(employeeNumber, lastName, firstName, extension, email, office.OfficeCode, report, jobTittle);
                employee.ReportsTo = reportsTo;

                context.Employees.Add(employee);
                context.SaveChanges();

                line = sr.ReadLine();
            }
			sr.Close();
		}

		public void AddOffices(string textFile)
        {
            StreamReader sr = new StreamReader(textFile);

            string line = sr.ReadLine();
            line = sr.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                string officeCode = fields[0].Trim('"');
                string city = fields[1].Trim('"');
                string phone = fields[2].Trim('"');
                string addressLine1 = fields[3].Trim('"');
                string addressLine2 = fields[4].Trim('"');
                string state = fields[5].Trim('"');
                string country = fields[6].Trim('"');
                string postalCode = fields[7].Trim('"');
                string territory = fields[8].Trim('"');

                Office office = new Office(officeCode, city, phone, addressLine1, addressLine2, state, country, postalCode, territory);

                context.Offices.Add(office);
                context.SaveChanges();

                line = sr.ReadLine();
            }
			sr.Close();
		}

		public void AddOrderDetails(string file)
        {
            StreamReader sr = new StreamReader(file);

            string line = sr.ReadLine();
            line = sr.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                int orderNumber = Convert.ToInt32(fields[0].Trim('"'));
                string productCode = fields[1].Trim('"');
                int quantityOrdered = Convert.ToInt32(fields[2].Trim('"'));
                double priceEach = Convert.ToDouble(fields[3].Trim('"'));
                int orderLineNumber = Convert.ToInt32(fields[4].Trim('"'));

                OrderDetail orderDetail = new OrderDetail(orderNumber, productCode, quantityOrdered, priceEach, orderLineNumber);

                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();

                line = sr.ReadLine();
            }
			sr.Close();
		}
		public void AddPayments(string file)
        {
            StreamReader sr = new StreamReader(file);

            string line = sr.ReadLine();
            line = sr.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                int customerNumber = Convert.ToInt32(fields[0].Trim('"'));
                string checkNumber = fields[1].Trim('"');
                DateTime paymentDate = Convert.ToDateTime(fields[2].Trim('"'));
                double amount = Convert.ToDouble(fields[3].Trim('"'));

                Payment payment = new Payment(customerNumber, checkNumber, paymentDate, amount);

                context.Payments.Add(payment);
                context.SaveChanges();

                line = sr.ReadLine();
            }
			sr.Close();
		}
		public void AddProductLines(string textFile)
		{
			StreamReader sr = new StreamReader(textFile);

			string line = sr.ReadLine();
			line = sr.ReadLine();

			while (line != null)
			{
				string[] fields = Regex.Split(line, @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))");

				string productLines = fields[0].Trim('"');
				string textDescription = fields[1].Trim('"');
				string htmlDescription = fields[2].Trim('"');
				string image = fields[3].Trim('"');


				ProductLine productLine = new ProductLine(productLines, textDescription, htmlDescription, image);

				context.ProductLines.Add(productLine);
				context.SaveChanges();

				line = sr.ReadLine();
			}
			sr.Close();
		}

		public void AddProducts(string textFile)
        {
            StreamReader sr = new StreamReader(textFile);

            string line = sr.ReadLine();
            line = sr.ReadLine();

            while (line != null)
            {
                if (line == null)
                {

                }
                else
                {

                    string[] fields = line.Split("\",\"");

                    string productCode = fields[0].Trim('"');
                    string productName = fields[1].Trim('"');
                    string productLineId = fields[2].Trim('"');
				    ProductLine productLine = context.ProductLines.Find(fields[2].Trim('"'));
                    if (productLine == null)
                    {
                        ProductLine tmp = new ProductLine(fields[2], fields[2], fields[2], "null");
                        context.ProductLines.Add(tmp);
                        context.SaveChanges();
                    }
				    //string productLine = fields[6].Trim('"').ToLower().Contains("null") ? null : Convert.ToString(fields[6]);
				    string productScale = fields[3].Trim('"');
                    string productVendor = fields[4].Trim('"');
                    string productDescription = fields[5].Trim('"');
                    int quantityInStock = Convert.ToInt32(fields[6].Trim('"'));
                    double buyPrice = Convert.ToDouble(fields[7].Trim('"'));
                    double msrp = Convert.ToDouble(fields[8].Trim('"'));

                    //Product product = new Product(productCode, productName, productLine.productLine, productScale, productVendor, productDescription, quantityInStock, buyPrice, msrp);
				    Product product = new Product(productCode, productName, productLineId, productScale, productVendor, productDescription, quantityInStock, buyPrice, msrp);
                    //ProductLine pl = new ProductLine("","","","");
                    product.ProductLine = productLine;
				    context.Products.Add(product);
                    context.SaveChanges();
                }

                line = sr.ReadLine();
            }
            sr.Close();
        }
		#endregion
		#region Eloy
		public object ProductsMainInfo()
        {
            throw new NotImplementedException();
        }

        public List<Product> ProductsPerOrder()
        {
            throw new NotImplementedException();
        }

        public List<Order> OrdersBetweenDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Product> Top10MostExpensiveProducts()
        {
            throw new NotImplementedException();
        }
		#endregion
		#region Arnau
		public List<Employee> EmployeesPerBoss()
        {
            throw new NotImplementedException();
        }

        public object ProductsForEachProductLine()
        {
            throw new NotImplementedException();
        }

        public object ProductsYetToBuyFromACustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Employee> BestSellerEmployees()
        {
            throw new NotImplementedException();
        }
		#endregion
	}
} 