using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.DAO
{
    internal class DAOManagerFactory
    {
        public IDAOManager CreateDAO(MODEL.ClassicModelsDBContext context)
        {
            return new DAOManagerImpl(context);
        }
    }
}
