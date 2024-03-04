using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.VIEWMODEL
{
   public class ViewModelPaymentPerCustomer
    {
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
