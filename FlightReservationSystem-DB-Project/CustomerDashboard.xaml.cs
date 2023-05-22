using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FlightReservationSystem_DB_Project
{
    /// <summary>
    /// Interaction logic for CustomerDashboard.xaml
    /// </summary>
    public partial class CustomerDashboard : Window
    {
        public Customer Customer { get; set; }
        public CustomerDashboard(Customer customer)
        {
            InitializeComponent();
            this.Customer = customer;

        }

        private void Reserve_Button_Click(object sender, RoutedEventArgs e)
        {
            AvailableFlightsForm availableFlightsForm = new AvailableFlightsForm(Customer.SSN);
            availableFlightsForm.Show();
            //update.Hide();
        }

        private void Reservations_Button_Click(object sender, RoutedEventArgs e)
        {
            ManagingCustomerFlights manager = new ManagingCustomerFlights(Customer.SSN);
            manager.Show();
            //update.Hide();
        }

        private void UpdateProfile_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateCustomerProfile update = new UpdateCustomerProfile(Customer);
            update.Show();
            //update.Hide();
        }
    }
}
