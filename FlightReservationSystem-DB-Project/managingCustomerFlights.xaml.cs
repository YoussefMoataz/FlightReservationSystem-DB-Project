using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for managingCustomerFlights.xaml
    /// </summary>
    public partial class managingCustomerFlights : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\FlightReservation.mdf;Integrated Security=True;Connect Timeout=30");

        public managingCustomerFlights()
        {
            InitializeComponent();
            ShowcCustomerFlightsData();
        }
        private void ShowcCustomerFlightsData()
        {

            connection.Open();
            int ssn = 1;
            string query = "SELECT *FROM reservation WHERE RESERVATIONID IN (SELECT pnr   FROM reserves WHERE SSN = @ssn)";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand(query, connection);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ssn", ssn);


            DataTable dt = new DataTable("CustomerFlight");

            sqlDataAdapter.Fill(dt);

            

            FlightsTable.ItemsSource = dt.DefaultView;

            connection.Close();

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
