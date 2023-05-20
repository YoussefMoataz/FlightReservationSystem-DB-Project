﻿using System;
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
            int available= 0;
            float price = 0;
            int flightid=0;

        public ViewFlight(int flightID)
        {
            flightid = flightID;
            InitializeComponent();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\FlightReservation.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            //using (SqlConnection connection = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True"))
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
                    price = float.Parse(reader["PRICE"].ToString());
                    available = int.Parse(reader["AVAILABLESEATS"].ToString());
                }
            }


        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {

            string selectedOption = "";
            if (economyChoice.IsChecked == true)
            {
                selectedOption = "economy";
            }
            else if (buisnessChoice.IsChecked == true)
            {
                price += 100;
                selectedOption = "buisness";

            }
            else
            {
                MessageBox.Show("Please select a class");
                return;
            }

            string dateTime= DateTime.Today.ToString("dd/MM/yyyy");

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\FlightReservation.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "INSERT INTO RESERVATION (FLIGHTCLASS,RESERVATIONDATE,FLIGHTID,SEATNUMBER,COST) VALUES (@SelectedOption,@dateTime,@flightid,@available,@price)";
            string query1 = "update FLIGHT set availableseats=availableseats-1 where flightid=@flightid";


            using (SqlConnection connection = new SqlConnection(connectionString))
            //using (SqlConnection connection = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SelectedOption", selectedOption);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@dateTime", dateTime);
                command.Parameters.AddWithValue("@flightid", flightid);
                command.Parameters.AddWithValue("@available", available);

                SqlCommand command1 = new SqlCommand(query1, connection);
                command1.Parameters.AddWithValue("@flightid", flightid);







                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    int rowsAffected2 = command1.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Booked successfully");
                        AvailableFlightsForm availableFlightsForm = new AvailableFlightsForm();
                        availableFlightsForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bookinng failed");


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
