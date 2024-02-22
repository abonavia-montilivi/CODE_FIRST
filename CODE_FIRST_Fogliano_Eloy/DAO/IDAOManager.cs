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
    }
}