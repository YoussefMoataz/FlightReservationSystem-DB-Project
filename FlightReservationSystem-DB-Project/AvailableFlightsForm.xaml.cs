﻿using System;
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
            ShowAllFlightsData();

            FlightsTable.MouseDoubleClick += RowChanged;

            SourceSearchBox.TextChanged += SearchTextChanged;
            DestinationSearchBox.TextChanged += SearchTextChanged;
            DepartureDateSearchBox.TextChanged += SearchTextChanged;
            ArrivalDateSearchBox.TextChanged += SearchTextChanged;
            AvailableSeatsSearchBox.TextChanged += SearchTextChanged;

        }

        private void RowChanged(object sender, MouseButtonEventArgs e)
        {

            try
            {
                if (FlightsTable.SelectedItem != null)
                {

                    DataRowView row = (DataRowView)FlightsTable.SelectedItem;
                    if (row != null)
                    {
                        MessageBox.Show("Flight ID: " + row["FLIGHTID"].ToString());
                    }

                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void ShowAllFlightsData()
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

        private void ShowFlightsDataWithSource(string source, string destination, string departureDate, string arrivalDate, int availableSeats)
        {

            sqlConnection.Open();

            string query = "Select * from Flight" +
                " where source like '%" + source + "%'" +
                " and destination like '%" + destination + "%'" +
                " and departuredate like '%" + departureDate + "%'" +
                " and arrivaldate like '%" + arrivalDate + "%'" +
                " and availableseats >= " + availableSeats ;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

            DataTable dt = new DataTable("Flight");

            sqlDataAdapter.Fill(dt);

            FlightsTable.ItemsSource = dt.DefaultView;

            sqlConnection.Close();

        }

        private void SearchTextChanged(object sender, EventArgs e)
        {

            //MessageBox.Show(SourceSearchBox.Text);

            string sourceValue = SourceSearchBox.Text;
            string destinationValue = DestinationSearchBox.Text;
            string departureDateValue = DepartureDateSearchBox.Text;
            string arrivalDateValue = ArrivalDateSearchBox.Text;
            int availableSeatsValue = 1;

            if (AvailableSeatsSearchBox.Text.Length > 0)
            {
                availableSeatsValue = int.Parse(AvailableSeatsSearchBox.Text);
            }

            ShowFlightsDataWithSource(sourceValue, destinationValue, departureDateValue, arrivalDateValue, availableSeatsValue);

        }

    }
}
