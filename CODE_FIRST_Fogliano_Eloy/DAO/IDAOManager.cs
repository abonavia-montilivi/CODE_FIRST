using CODE_FIRST_Fogliano_Eloy.MODEL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.DAO
{
    public interface IDAOManager
    {
        public void AddProductLines(string textFile);
        public void AddProducts(string textFile);
        public void AddOffices(string textFile);
        public void AddEmployees(string textFile);
        public void AddCustomers(string file);
		public void AddPayments(string file);
		public void AddOrders(string file);
		public void AddOrderDetails(string file);

		//Eric Queries
		public List<MODEL.Customer> CustomersFromFrance();
		public List<MODEL.Product> ProductsByQuantityAndMsrp();
		public List<Object> PaymentsPerCustomer();
		public List<Object> EmployeesPerOffice();

		//Eloy Queries
		public List<Order> GetOrders();

        public List<MODEL.Product> PopularProducts();
		public List<MODEL.Product> ProductsPerOrder(Order order);
		public List<MODEL.Order> OrdersBetweenDates(DateTime startDate, DateTime endDate);
		public List<MODEL.Product> Top10MostExpensiveProducts();

		//Arnau Queries
		public List<Object> EmployeesPerBoss();
		public List<Object> ProductsForEachProductLine();
		public List<MODEL.Product> AllProductsBoughtByACustomer(int customerId);
		public List<Object> BestSellerEmployees();


	}
}