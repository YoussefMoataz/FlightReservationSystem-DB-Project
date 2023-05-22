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
    /// Interaction logic for UpdateCustomerProfile.xaml
    /// </summary>
    public partial class UpdateCustomerProfile : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6BNM9LM\MSSQLSERVER1;Initial Catalog=FlightReservation;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True");

        public Customer Customer { get; set; }
        public UpdateCustomerProfile(Customer customer)
        {
            InitializeComponent();
            this.Customer = customer;
            UpdateTextboxes();
        }

        private void UpdateTextboxes()
        {
            txtSSN.Text = Customer.SSN.ToString();
            txtFName.Text = Customer.FirstName;
            txtLName.Text = Customer.LastName;
            txtDateOfBirth.Text = Customer.DateOfBirth;
            txtAge.Text = Customer.Age.ToString();
            txtEmail.Text = Customer.Email;
            txtPassword.Text = Customer.Password;
            txtGender.Text = Customer.Gender;
            txtCity.Text = Customer.City;
            txtState.Text = Customer.State;
            txtStreet.Text = Customer.Street;
            txtZipCode.Text = Customer.ZipCode;

            // set other textboxes as needed
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtFName.Text == "" || txtLName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtAge.Text == "" || txtZipCode.Text == "" || txtState.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || txtDateOfBirth.Text == "" || txtGender.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update CUSTOMER set SSN=@SSN,FIRSTNAME=@FN,LASTNAME=@LN,GENDER=@G,EMAIL=@E,PASSWORD=@P,DATEOFBIRTH=@D,AGE=@AG,CITY=@CI,STATE=@SE,STREET=@ST,ZIPCODE=@ZC Where SSN=@Mkey", con);
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
                    cmd.Parameters.AddWithValue("@Mkey", Customer.SSN);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer updated");


                    con.Close();

                    this.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }
    }
}
