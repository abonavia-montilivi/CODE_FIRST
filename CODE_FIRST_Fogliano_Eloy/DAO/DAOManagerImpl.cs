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

            using (var context = new ShopDbContext())
            {

                // Query customers from France order by credit limit
                var customersWithName = context.Customers.Where(c => c.country == "France").OrderBy(c => c.creditLimit).ToList();

                //filtering and sorting
                var filteredProducts = context.Products.Where(p => p.quantityStock >= 2000 && p.msrp < 100).OrderBy(p => p.productName).ToList();

                //joining entities
                var customerPayments = context.Customers
                    .Join(context.Payments,
                    customer => customer.customerNumber,
                    payment => payment.customerNumber,
                    (customer, payment) => new
                    {
                        CustomerName = customer.customerFirstName,
                        PaymentAmount = payment.amount

                    })
                    .ToList();

                //agregation and grouping

                var employeesPerOffice = context.Employees
                  .GroupBy(e => e.officeCode)
                  .Select(o => new
                  {
                      OfficeCode = o.Key,
                      EmployeeCount = o.Count()
                  })
                 .ToList();


            }
        }

		public void AddCOrders(string file)
		{
			throw new NotImplementedException();
		}

		public void AddCustomers(string file)
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
	}
}