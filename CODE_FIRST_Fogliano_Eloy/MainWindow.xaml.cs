using CODE_FIRST_Fogliano_Eloy.DAO;
using CODE_FIRST_Fogliano_Eloy.MODEL;
using CODE_FIRST_Fogliano_Eloy.VIEWMODEL;
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
        
        //Eloy
        public List<Product> PopularProducts;
        public List<Product> ProductsXOrder;
        public List<Order> OrdersBetweenDates;
        public List<Product> Top10MostExpensiveProducts;

        //Arnau
        public List<ViewModelEmployeesPerBoss> ViewModelEmployeesPerBoss;
        public List<ViewModelProductsForEachProductLine> ViewModelProductsForEachProductLine;
        public List<Product> AllProductsBoughtByACustomer;
        public List<ViewModelBestSellerEmployees> ViewModelBestSellerEmployees;

        //Eric
        public List<Customer> CustomersFromFrance;
        public List<Product> ProductsByQuantityAndMsrp;
        public List<ViewModelPaymentPerCustomer> PaymentsPerCustomer;
        public List<ViewModelEmployeesPerOffice> EmployeesPerOffice;

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

            #region Arnau
            ViewModelEmployeesPerBoss = daoManager.EmployeesPerBoss();
            dgEmployeesPerBoss.DataContext = this;
            dgEmployeesPerBoss.ItemsSource = ViewModelEmployeesPerBoss;

            ViewModelProductsForEachProductLine = daoManager.ProductsForEachProductLine();
            dgProductsByProductLines.DataContext = this;
            dgProductsByProductLines.ItemsSource = ViewModelProductsForEachProductLine;

            List<Customer> rawCustomers = daoManager.GetCustomers();
            cmbCustomers.ItemsSource = rawCustomers;
            cmbCustomers.DisplayMemberPath = "CustomerName"; // Que mostri només el Name del customer en el combobox

            ViewModelBestSellerEmployees = daoManager.BestSellerEmployees();
            dgBestSellerEmployees.DataContext = this;
            dgBestSellerEmployees.ItemsSource = ViewModelBestSellerEmployees;
            #endregion

            #region Eric
            CustomersFromFrance = daoManager.CustomersFromFrance();
            dgCustomersFromFrance.DataContext = this;
            dgCustomersFromFrance.ItemsSource = CustomersFromFrance;

            ProductsByQuantityAndMsrp = daoManager.ProductsByQuantityAndMsrp();
            dgProductsByQuantityAndMsrp.DataContext = this;
            dgProductsByQuantityAndMsrp.ItemsSource = ProductsByQuantityAndMsrp;

            PaymentsPerCustomer = daoManager.PaymentsPerCustomer();
            dgPaymentsPerCustomer.DataContext = this;
            dgPaymentsPerCustomer.ItemsSource = PaymentsPerCustomer;

            EmployeesPerOffice = daoManager.EmployeesPerOffice();
            dgEmployeesPerOffice.DataContext = this;
            dgEmployeesPerOffice.ItemsSource = EmployeesPerOffice;
            #endregion
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
            
            OrdersBetweenDates = daoManager.OrdersBetweenDates(date1, date2);
            dgOrdersBetweenDates.DataContext = this;
            dgOrdersBetweenDates.ItemsSource = OrdersBetweenDates;
        }

		private void cmbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            Customer customer = cmbCustomers.SelectedItem as Customer;
            AllProductsBoughtByACustomer = daoManager.AllProductsBoughtByACustomer(customer.CustomerNumber);
            dgAllProductsBoughtByACustomer.DataContext = this;
            dgAllProductsBoughtByACustomer.ItemsSource = AllProductsBoughtByACustomer;
        }
	}
}