using CODE_FIRST_Fogliano_Eloy.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public void AddOrders(string file)
        {
            throw new NotImplementedException();
        }

        public void AddCustomers(string file)
        {
            throw new NotImplementedException();
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
                Employee reportsTo = context.Employees.Find(fields[6].Trim('"'));
                string jobTittle = fields[7].Trim('"');

                Employee employee = new Employee(employeeNumber, lastName, firstName, extension, email, office.OfficeCode, reportsTo.EmployeeNumber, jobTittle);

                context.Employees.Add(employee);
                context.SaveChanges();

                line = sr.ReadLine();
            }
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
        }
        public void AddProductLines(string textFile)
        {
            StreamReader sr = new StreamReader(textFile);

            string line = sr.ReadLine();
            line = sr.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                string productLines = fields[0].Trim('"');
                string textDescription = fields[1].Trim('"');
                string htmlDescription = fields[2].Trim('"');
                string image = fields[3].Trim('"');


                ProductLine productLine = new ProductLine(productLines, textDescription, htmlDescription, image);

                context.ProductLines.Add(productLine);
                context.SaveChanges();

                line = sr.ReadLine();
            }
        }

        public void AddProducts(string textFile)
        {
            StreamReader sr = new StreamReader(textFile);

            string line = sr.ReadLine();
            line = sr.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                string productCode = fields[0].Trim('"');
                string productName = fields[1].Trim('"');
                ProductLine productLine = context.ProductLines.Find(fields[2].Trim('"'));
                string productScale = fields[3].Trim('"');
                string productVendor = fields[4].Trim('"');
                string productDescription = fields[5].Trim('"');
                int quantityInStock = Convert.ToInt32(fields[6].Trim('"'));
                double buyPrice = Convert.ToDouble(fields[7].Trim('"'));
                double msrp = Convert.ToDouble(fields[8].Trim('"'));

                Product product = new Product(productCode, productName, productLine.productLine, productScale, productVendor, productDescription, quantityInStock, buyPrice, msrp);

                context.Products.Add(product);
                context.SaveChanges();

                line = sr.ReadLine();
            }
        }

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
    }
} 