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
using System.Windows.Shapes;

namespace FlightReservationSystem_DB_Project
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ViewFlight : Window
    {
        public ViewFlight(int flightID)
        {
            InitializeComponent();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\FlightReservation.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM FLIGHT WHERE FLIGHTID = @FLIGHTID;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FLIGHTID", flightID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    source.Text = reader["SOURCE"].ToString();
                    destination.Text = reader["DESTINATION"].ToString();
                    date.Text = reader["DEPARTUREDATE"].ToString();
                    availableSeats.Text = reader["AVAILABLESEATS"].ToString();
                    cost.Text = reader["PRICE"].ToString();
                }
            }


        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            if (economyChoice.IsChecked == true)
            {
                // Option 1 is selected
                MessageBox.Show("economy is selected");
            }
            else if (buisnessChoice.IsChecked == true)
            {
                // Option 2 is selected
                MessageBox.Show("buisness is selected");
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
