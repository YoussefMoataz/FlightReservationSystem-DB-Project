using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for AddFlightForm.xaml
    /// </summary>
    public partial class AddFlightForm : Window
    {
        public AddFlightForm()
        {
            InitializeComponent();
            ShowAllFlightsData();

            string connectionString = "Your_Connection_String";

            AddFlightButton.Click += AddButtonClicked;

        }

        private void AddButtonClicked(object sender, EventArgs e)
        {

            // Assuming you have obtained the flight details from the user
            int flightId = 6;
            string source = SourceInput.Text;
            string destination = DestinationInput.Text;
            string departureDate = DepartureDateInput.Text;
            string arrivalDate = ArrivalDateInput.Text;
            int availableSeats = int.Parse(AvailableSeatsInput.Text);
            int aircraftId = 1;
            int airlineId = 1;

            // Create or update flight in the database
            using (SqlConnection connection = new SqlConnection("Data Source=YOUSSEF-LENOVO5\\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True"))
            {

                try
                {
                    connection.Open();

                    // Check if the flight already exists in the database
                    string checkFlightQuery = "SELECT COUNT(*) FROM FLIGHT WHERE FLIGHTID = @FlightId";
                    using (SqlCommand checkFlightCommand = new SqlCommand(checkFlightQuery, connection))
                    {
                        checkFlightCommand.Parameters.AddWithValue("@FlightId", flightId);
                        int existingFlightsCount = (int)checkFlightCommand.ExecuteScalar();

                        if (existingFlightsCount > 0)
                        {
                            // Flight already exists, update the flight details
                            string updateFlightQuery = "UPDATE FLIGHT SET SOURCE = @Source, DESTINATION = @Destination, " +
                                                       "DEPARTUREDATE = @DepartureDate, ARRIVALDATE = @ArrivalDate, " +
                                                       "AVAILABLESEATS = @AvailableSeats, AIRCRAFTID = @AircraftId, AIRLINEID = @AirlineId " +
                                                       "WHERE FLIGHTID = @FlightId";

                            using (SqlCommand updateFlightCommand = new SqlCommand(updateFlightQuery, connection))
                            {
                                updateFlightCommand.Parameters.AddWithValue("@Source", source);
                                updateFlightCommand.Parameters.AddWithValue("@Destination", destination);
                                updateFlightCommand.Parameters.AddWithValue("@DepartureDate", departureDate);
                                updateFlightCommand.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
                                updateFlightCommand.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                                updateFlightCommand.Parameters.AddWithValue("@AircraftId", aircraftId);
                                updateFlightCommand.Parameters.AddWithValue("@AirlineId", airlineId);
                                updateFlightCommand.Parameters.AddWithValue("@FlightId", flightId);

                                updateFlightCommand.ExecuteNonQuery();
                                Console.WriteLine("Flight updated successfully.");
                            }
                        }
                        else
                        {
                            // Flight doesn't exist, add a new flight
                            string addFlightQuery = "INSERT INTO FLIGHT (SOURCE, DESTINATION, DEPARTUREDATE, " +
                                                    "ARRIVALDATE, AVAILABLESEATS, AIRCRAFTID, AIRLINEID) " +
                                                    "VALUES (@Source, @Destination, @DepartureDate, @ArrivalDate, " +
                                                    "@AvailableSeats, @AircraftId, @AirlineId)";

                            using (SqlCommand addFlightCommand = new SqlCommand(addFlightQuery, connection))
                            {
                                addFlightCommand.Parameters.AddWithValue("@Source", source);
                                addFlightCommand.Parameters.AddWithValue("@Destination", destination);
                                addFlightCommand.Parameters.AddWithValue("@DepartureDate", departureDate);
                                addFlightCommand.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
                                addFlightCommand.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                                addFlightCommand.Parameters.AddWithValue("@AircraftId", aircraftId);
                                addFlightCommand.Parameters.AddWithValue("@AirlineId", airlineId);

                                addFlightCommand.ExecuteNonQuery();
                                Console.WriteLine("Flight added successfully.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }

            ShowAllFlightsData();

        }

        private void ShowAllFlightsData()
        {

            SqlConnection sqlConnection = new SqlConnection("Data Source=YOUSSEF-LENOVO5\\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True");

            sqlConnection.Open();

            string query = "Select * from Flight";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataTable dt = new DataTable("Flight");

            sqlDataAdapter.Fill(dt);

            //foreach (DataRow row in dt.Rows)
            //{
            //    FLIGHT f = new FLIGHT();
            //    f.FLIGHTID = (int)row["FLIGHTID"];
            //    MessageBox.Show(f.FLIGHTID.ToString());
            //}

            FlightsTable.ItemsSource = dt.DefaultView;

            sqlConnection.Close();

        }

    }
}