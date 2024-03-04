using CODE_FIRST_Fogliano_Eloy.DAO;
using CODE_FIRST_Fogliano_Eloy.MODEL;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CODE_FIRST_Fogliano_Eloy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MODEL.ClassicModelsDBContext modelDBContext = new MODEL.ClassicModelsDBContext();
        private IDAOManager daoManager = null;
        public MainWindow()
        {
            InitializeComponent();
            DAOManagerFactory factory = new DAOManagerFactory();
            daoManager = factory.CreateDAO(modelDBContext);
            //daoManager.AddProductLines("PRODUCTLINES.csv");
            //daoManager.AddProducts("PRODUCTS.csv");
            //daoManager.AddOffices("OFFICES.csv");
            //daoManager.AddEmployees("EMPLOYEES.csv");
            //daoManager.AddCustomers("CUSTOMERS.csv");
            //daoManager.AddPayments("PAYMENTS.csv");
            //daoManager.AddOrders("ORDERS.csv");
            //daoManager.AddOrderDetails("ORDERDETAILS.csv");
            //var employees = daoManager.EmployeesPerBoss();

            var orders = daoManager.GetOrders();
            Order order = orders.FirstOrDefault();
            var productsXOrder = daoManager.ProductsPerOrder(order);
                    
            var productsPopulars = daoManager.PopularProducts();

            // var employees = daoManager.EmployeesPerBoss();
            var customers = daoManager.CustomersFromFrance();
            var productsByQuantity = daoManager.ProductsByQuantityAndMsrp();
            var paymentsPerCustomer = daoManager.PaymentsPerCustomer();
            var employeesPerOffice = daoManager.EmployeesPerOffice();
            //Console.WriteLine();


        }

		private void cmbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}