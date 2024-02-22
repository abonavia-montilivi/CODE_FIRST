using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.DAO
{
    public interface IDAOManager
    {
        public void AddCustomers(string file);
		public void AddPayments(string file);
		public void AddCOrders(string file);
		public void AddOrderDetails(string file);



	}
}