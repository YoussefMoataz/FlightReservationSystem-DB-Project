using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightReservationSystem_DB_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Flight Reservation System";

        }

        private void registerAdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminRegistrationForm adminRegistrationForm = new AdminRegistrationForm();

            adminRegistrationForm.Show();

            this.Close();
        }

        private void registerCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerRegistrationForm customerRegistrationForm = new CustomerRegistrationForm();

            customerRegistrationForm.Show();

            this.Close();
        }

        private void loginAdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();

            adminLogin.Show();
            this.Close();   
        }

        private void loginCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerLogin customerLogin = new CustomerLogin();
            customerLogin.Show();
            this.Close();

        }


    }
}
