using CODE_FIRST_Fogliano_Eloy.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.DAO
{
    internal class DAOManagerImpl: IDAOManager
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
            throw new NotImplementedException();
        }

        public void AddOffices(string textFile)
        {
            throw new NotImplementedException();
        }

		public void AddOrderDetails(string file)
		{
			throw new NotImplementedException();
		}

		public void AddPayments(string file)
		{
			throw new NotImplementedException();
		}
        public void AddProductLines(string textFile)
        {
            throw new NotImplementedException();
        }

        public void AddProducts(string textFile)
        {
            throw new NotImplementedException();
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