using CODE_FIRST_Fogliano_Eloy.DAO;
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
        private IDAOManager dAOManager = null;
        public MainWindow()
        {
            InitializeComponent();
            DAOManagerFactory factory = new DAOManagerFactory();
            dAOManager = factory.CreateDAO(modelDBContext);
            dAOManager.AddProductLines("PRODUCTLINES.csv");



        }
    }
}