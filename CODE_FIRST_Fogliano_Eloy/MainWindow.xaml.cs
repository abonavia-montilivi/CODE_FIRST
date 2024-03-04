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
        public List<Product> PopularProducts;
        public List<Product> ProductsXOrder;
        public List<Order> OrdersBetweenDates;
        public List<Product> Top10MostExpensiveProducts;
        
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


            #region Eloy
            PopularProducts = daoManager.PopularProducts();
            dgPopularProducts.DataContext = this;
            dgPopularProducts.ItemsSource = PopularProducts;

            //Possar les ordres al CMB
            List<Order> orders = daoManager.GetOrders();
            cmbOrders.ItemsSource = orders;
            cmbOrders.DisplayMemberPath = "OrderNumber"; // Que mostri només el OrderNumber de la ordre en el combobox

            Top10MostExpensiveProducts = daoManager.Top10MostExpensiveProducts();
            dgTop10MostExpensiveProducts.DataContext = this;
            dgTop10MostExpensiveProducts.ItemsSource = Top10MostExpensiveProducts;
            #endregion

            // var employees = daoManager.EmployeesPerBoss();
            //var customers = daoManager.CustomersFromFrance();
            //var productsByQuantity = daoManager.ProductsByQuantityAndMsrp();
            //var paymentsPerCustomer = daoManager.PaymentsPerCustomer();
            //var employeesPerOffice = daoManager.EmployeesPerOffice();
            //Console.WriteLine();
        }

        private void cmbOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Order order = cmbOrders.SelectedItem as Order;
            ProductsXOrder = daoManager.ProductsPerOrder(order);
            dgProductsPerOrder.DataContext = this;
            dgProductsPerOrder.ItemsSource = ProductsXOrder;
        }

        private void btnOrdersBetween_Click(object sender, RoutedEventArgs e)
        {
            DateTime date1 = DateTime.Parse("2001-01-01"); ;
            DateTime date2 = DateTime.Now;
            if (dpOrderDate1.SelectedDate != null) 
            date1 = dpOrderDate1.SelectedDate.Value;
            if (dpOrderDate2.SelectedDate != null)
            date2 = dpOrderDate2.SelectedDate.Value;
            
            //date1 = DateTime.Parse("2005-05-31");
            //date2 = DateTime.Now;
            
            OrdersBetweenDates = daoManager.OrdersBetweenDates(date1, date2);
            dgOrdersBetweenDates.DataContext = this;
            dgOrdersBetweenDates.ItemsSource = OrdersBetweenDates;
        }

		private void cmbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}