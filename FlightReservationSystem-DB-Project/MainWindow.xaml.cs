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

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True");

            // assign event handlers
            registerAdminButton.Click += AdminRegistrationClicked;
            registerCustomerButton.Click += CustomerRegistrationClicked;

            //AvailableFlightsForm availableFlightsForm = new AvailableFlightsForm();
            //availableFlightsForm.Show();
            //this.Close();

        }

        private void AdminRegistrationClicked(object sender, RoutedEventArgs e)
        {

            AdminRegistrationForm adminRegistrationForm = new AdminRegistrationForm();

            adminRegistrationForm.Show();

            // this.Close();

        }

        private void CustomerRegistrationClicked(object sender, RoutedEventArgs e)
        {

            CustomerRegistrationForm customerRegistrationForm = new CustomerRegistrationForm();

            customerRegistrationForm.Show();

            // this.Close();

        }
    }
}
