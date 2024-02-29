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
		public Object PaymentsPerCustomer();
		public Object EmployeesPerOffice();

		//Eloy Queries
		public Object ProductsMainInfo();
		public List<MODEL.Product> ProductsPerOrder();
		public List<MODEL.Order> OrdersBetweenDates(DateTime startDate, DateTime endDate);
		public List<MODEL.Product> Top10MostExpensiveProducts();

		//Arnau Queries
		public List<Object> EmployeesPerBoss();
		public Object ProductsForEachProductLine();
		public Object ProductsYetToBuyFromACustomer(MODEL.Customer customer);
		public List<Employee> BestSellerEmployees();


	}
}