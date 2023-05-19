using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for AvailableFlightsForm.xaml
    /// </summary>
    public partial class AvailableFlightsForm : Window
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True");

        public AvailableFlightsForm()
        {
            InitializeComponent();
            ShowFlightsData();

            FlightsTable.MouseDoubleClick += RowChanged;

        }

        private void RowChanged(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show(FlightsTable.SelectedIndex.ToString());
            try
            {
                if (FlightsTable.SelectedItem != null)
                {
                    //FLIGHT flight = FlightsTable.SelectedItem as FLIGHT;
                    //MessageBox.Show(flight.AIRCRAFTID.ToString());

                    DataRowView row = (DataRowView)FlightsTable.SelectedItem;
                    if (row != null)
                    {
                        MessageBox.Show("Destinations: " + row["DESTINATION"].ToString());
                    }

                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void ShowFlightsData()
        {

            sqlConnection.Open();

            string query = "Select * from Flight";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

            DataTable dt = new DataTable("Flight");

            sqlDataAdapter.Fill(dt);

            FlightsTable.ItemsSource = dt.DefaultView;

            sqlConnection.Close();

        }

    }
}
