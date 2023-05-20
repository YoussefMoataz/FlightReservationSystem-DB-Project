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
    /// Interaction logic for AddFlightForm.xaml
    /// </summary>
    public partial class AddFlightForm : Window
    {
        public AddFlightForm()
        {
            InitializeComponent();

            string connectionString = "Your_Connection_String";

            // Assuming you have obtained the flight details from the user
            int flightId = 4;
            string source = "JFK";
            string destination = "LAX";
            string departureDate = "2023-05-20";
            string arrivalDate = "2023-05-20";
            int availableSeats = 99;
            int aircraftId = 1;
            int airlineId = 1;

            // Create or update flight in the database
            using (SqlConnection connection = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True"))
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
                        string addFlightQuery = "INSERT INTO FLIGHT (FLIGHTID, SOURCE, DESTINATION, DEPARTUREDATE, " +
                                                "ARRIVALDATE, AVAILABLESEATS, AIRCRAFTID, AIRLINEID) " +
                                                "VALUES (@FlightId, @Source, @Destination, @DepartureDate, @ArrivalDate, " +
                                                "@AvailableSeats, @AircraftId, @AirlineId)";

                        using (SqlCommand addFlightCommand = new SqlCommand(addFlightQuery, connection))
                        {
                            addFlightCommand.Parameters.AddWithValue("@FlightId", flightId);
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

        }
    }
}
