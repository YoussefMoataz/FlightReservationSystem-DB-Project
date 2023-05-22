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
    /// Interaction logic for CustomerRegistrationForm.xaml
    /// </summary>
    public partial class CustomerRegistrationForm : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6BNM9LM\MSSQLSERVER1;Initial Catalog=FlightReservation;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True");
        public CustomerRegistrationForm()
        {
            InitializeComponent();
            this.Title = "Customer Registration";
        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtFName.Text == "" || txtLName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtAge.Text == "" || txtZipCode.Text==""|| txtState.Text == "" || txtStreet.Text=="" || txtCity.Text == "" || txtDateOfBirth.Text == "" || txtGender.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into CUSTOMER(SSN,FIRSTNAME,LASTNAME,GENDER,EMAIL,PASSWORD,DATEOFBIRTH,AGE,CITY,STATE,STREET,ZIPCODE)values(@SSN,@FN,@LN,@G,@E,@P,@D,@AG,@CI,@SE,@ST,@ZC)", con);
                    cmd.Parameters.AddWithValue("@SSN", txtSSN.Text);
                    cmd.Parameters.AddWithValue("@FN", txtFName.Text);
                    cmd.Parameters.AddWithValue("@LN", txtLName.Text);
                    cmd.Parameters.AddWithValue("@G", txtGender.Text);
                    cmd.Parameters.AddWithValue("@E", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@P", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@D", txtDateOfBirth.Text);
                    cmd.Parameters.AddWithValue("@Ag", txtAge.Text);
                    cmd.Parameters.AddWithValue("@CI", txtCity.Text);
                    cmd.Parameters.AddWithValue("@SE", txtState.Text);
                    cmd.Parameters.AddWithValue("@ST", txtStreet.Text);
                    cmd.Parameters.AddWithValue("@ZC", txtZipCode.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added");


                    con.Close();

                    this.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void txtGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
