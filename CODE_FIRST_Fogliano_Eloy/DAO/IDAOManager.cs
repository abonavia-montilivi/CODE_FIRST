using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.DAO
{
    internal interface IDAOManager
    {
        public void AddProductLines(string textFile);
        public void AddProducts(string textFile);
        public void AddOffices(string textFile);
        public void AddEmployees(string textFile);
    }
}