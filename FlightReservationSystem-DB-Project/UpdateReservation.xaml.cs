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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightReservationSystem_DB_Project
{
    /// <summary>
    /// Interaction logic for UpdateReservation.xaml
    /// </summary>
    public partial class UpdateReservation : Window
    {
        string currentClass="";
        string prevClass = "";
        float price = 0;
        int CurrPnr = 0;
        int CurrSsn = 0;
        int flightid=0;
        public UpdateReservation(int pnr,int ssn)
        {
            
            CurrPnr=pnr;
            CurrSsn=ssn;
            InitializeComponent();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\FlightReservation.mdf;Integrated Security=True;Connect Timeout=30";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlConnection connection = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT * FROM RESERVATION WHERE RESERVATIONID=(select pnr from reserves where ssn=@ssn and pnr=@pnr) ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ssn", ssn);
                command.Parameters.AddWithValue("@pnr", pnr);

                 SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    date_.Text = reader["RESERVATIONDATE"].ToString();
                    cost_.Text = reader["COST"].ToString();
                    seatNumber.Text = reader["SEATNUMBER"].ToString();
                    currentClass = reader["FLIGHTCLASS"].ToString();
                    prevClass = reader["FLIGHTCLASS"].ToString();
                    price = float.Parse(reader["COST"].ToString());


                    flightid = int.Parse(reader["FLIGHTID"].ToString()) ;
                }
                if (currentClass == "economy")
                {
                    economyChoice_.IsChecked = true;
                }
                else
                {
                    buisnessChoice_.IsChecked = true;
                }
            }


        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\FlightReservation.mdf;Integrated Security=True;Connect Timeout=30";
            string updateReservation = "update reservation set flightclass=@flightclass  where reservationid=@reservationid;update reservation set cost=@price  where reservationid=@reservationid ";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlConnection connection = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True"))
            {
                connection.Open();

                if (economyChoice_.IsChecked == true)
                {
                    currentClass = "economy";
                }
                else
                {
                    currentClass = "buisness";
                }
                if (currentClass != prevClass && currentClass=="buisness") {
                    price += 100;
                }
                if (currentClass != prevClass && currentClass == "economy")
                {
                    price -= 100;
                }
                SqlCommand command = new SqlCommand(updateReservation, connection);
                command.Parameters.AddWithValue("@flightclass", currentClass);
                command.Parameters.AddWithValue("@reservationid", CurrPnr);
                command.Parameters.AddWithValue("@price", price);

                command.ExecuteNonQuery();
                connection.Close();
                ManagingCustomerFlights manage = new ManagingCustomerFlights(CurrSsn);
                manage.Show();
                this.Close();

            }

        }
            private void cancel_Click(object sender, RoutedEventArgs e)
        {
            string deleteReserves = "delete reserves where pnr=@pnr and ssn=@ssn";
            string deleteReservation = "delete reservation where RESERVATIONID=@pnr";
            string addSeat = "update flight set availableseats=availableseats+1 where FLIGHTID=@flightid";

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\FlightReservation.mdf;Integrated Security=True;Connect Timeout=30";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlConnection connection = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(deleteReserves, connection);
                command.Parameters.AddWithValue("@pnr", CurrPnr);
                command.Parameters.AddWithValue("@ssn", CurrSsn);

                SqlCommand command1 = new SqlCommand(deleteReservation, connection);
                command1.Parameters.AddWithValue("@pnr", CurrPnr);

                SqlCommand command2 = new SqlCommand(addSeat, connection);
                command2.Parameters.AddWithValue("@flightid", flightid);

                command.ExecuteNonQuery();
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                connection.Close();
                ManagingCustomerFlights manage = new ManagingCustomerFlights(CurrSsn);
                manage.Show();
                this.Close();


            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
