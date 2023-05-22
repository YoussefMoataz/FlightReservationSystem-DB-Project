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
using System;
using System.Data;


namespace FlightReservationSystem_DB_Project
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AircraftWindow : Window
    {
        private SqlConnection connection;
        public AircraftWindow()
        {
            InitializeComponent();
            //connection = new SqlConnection(@"Data Source=DESKTOP-QK0IFST\MSSQLSERVER01;Initial Catalog=FlightReservation;Integrated Security=True");
            connection = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True");
            ShowAircrafts();
        }

        private void ShowAircrafts()
        {
            connection.Open();
            string Query = "SELECT * FROM AIRCRAFT";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds, "Aircrafts");
            AllAircrafts.ItemsSource = ds.Tables["Aircrafts"].DefaultView;
            connection.Close();
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        int Key = 0;
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllAircrafts.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)AllAircrafts.SelectedItem;
                AircraftID.Text = selectedRow["AIRCRAFTID"].ToString();
                AircraftModel.Text = selectedRow["MODEL"].ToString();
                AircraftType.Text = selectedRow["TYPE"].ToString();
                AircraftCapacity.Text = selectedRow["CAPACITY"].ToString();
                if (string.IsNullOrEmpty(AircraftID.Text))
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(selectedRow["AIRCRAFTID"]);
                }
            }
        }


        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AircraftID.Text == "" || AircraftModel.Text == "" || AircraftType.Text == "" || AircraftCapacity.Text == "")
            {
                MessageBox.Show("Please complete all information needed");
            }
            else
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT AIRCRAFT ON; INSERT INTO AIRCRAFT (AIRCRAFTID, MODEL, TYPE, CAPACITY) VALUES (@AID, @MDL, @TY, @CAP); SET IDENTITY_INSERT AIRCRAFT OFF;", connection);
                    cmd.Parameters.AddWithValue("@AID", AircraftID.Text);
                    cmd.Parameters.AddWithValue("@MDL", AircraftModel.Text);
                    cmd.Parameters.AddWithValue("@TY", AircraftType.Text);
                    cmd.Parameters.AddWithValue("@CAP", AircraftCapacity.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Aircraft is added successfully!");
                    connection.Close();
                    ShowAircrafts();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Aircraft you want to delete.");
            }
            else
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete From AIRCRAFT where AIRCRAFTID = @MKey", connection);
                    cmd.Parameters.AddWithValue("@MKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Aircraft is deleted successfully!");
                    connection.Close();
                    ShowAircrafts();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Reset()
        {
            AircraftID.Text = "";
            AircraftModel.Text = "";
            AircraftType.Text = "";
            AircraftCapacity.Text = "";
            Key = 0;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AircraftID.Text == "" || AircraftModel.Text == "" || AircraftType.Text == "" || AircraftCapacity.Text == "")
            {
                MessageBox.Show("Select The Aircraft you want to edit.");
            }
            else
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Update AIRCRAFT Set  MODEL=@MDL, TYPE=@TY, CAPACITY=@CAP where AIRCRAFTID=@MKey", connection);
                    cmd.Parameters.AddWithValue("@MDL", AircraftModel.Text);
                    cmd.Parameters.AddWithValue("@TY", AircraftType.Text);
                    cmd.Parameters.AddWithValue("@CAP", AircraftCapacity.Text);
                    cmd.Parameters.AddWithValue("@MKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Aircraft is Updated successfully!");
                    connection.Close();
                    ShowAircrafts();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}