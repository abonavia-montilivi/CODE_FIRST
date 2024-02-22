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