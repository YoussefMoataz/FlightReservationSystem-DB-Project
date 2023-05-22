using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for CustomerLogin.xaml
    /// </summary>
    public partial class CustomerLogin : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6BNM9LM\MSSQLSERVER1;Initial Catalog=FlightReservation;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True");
        public CustomerLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtSSN.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Enter both Email and password");

            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from CUSTOMER Where SSN='" + txtSSN.Text + "' and PASSWORD='" + txtPassword.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    // Get the Customer's information from the database
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMER WHERE SSN='" + txtSSN.Text + "'", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int ssn = reader.GetInt32(reader.GetOrdinal("SSN"));
                        string fname = reader.GetString(reader.GetOrdinal("FIRSTNAME"));
                        string lname = reader.GetString(reader.GetOrdinal("LASTNAME"));
                        string gender = reader.GetString(reader.GetOrdinal("GENDER"));
                        string date = reader.GetString(reader.GetOrdinal("DATEOFBIRTH"));
                        string email = reader.GetString(reader.GetOrdinal("EMAIL"));
                        string pass = reader.GetString(reader.GetOrdinal("PASSWORD"));
                        int age = reader.GetInt32(reader.GetOrdinal("AGE"));
                        string city = reader.GetString(reader.GetOrdinal("CITY"));
                        string state = reader.GetString(reader.GetOrdinal("STATE"));
                        string street = reader.GetString(reader.GetOrdinal("STREET"));
                        string zipcode = reader.GetString(reader.GetOrdinal("ZIPCODE"));



                        // Create a User object with the Customer's information
                        Customer customer = new Customer
                        {
                            FirstName = fname,
                            LastName = lname,
                            SSN = ssn,
                            Gender = gender,
                            DateOfBirth = date,
                            Email = email,
                            Password = pass,
                            Age = age,
                            City = city,
                            State = state,  
                            Street = street,
                            ZipCode = zipcode
                            

                        };



                        // Open the UpdateAdmin form and pass the User object to its constructor
                        //UpdateCustomerProfile updateCustomer = new UpdateCustomerProfile(customer);
                        CustomerDashboard dashboard = new CustomerDashboard(customer);
                        dashboard.Show();
                        this.Hide(); // Hide the login form
                    }
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Wrong SSN or Password");
                }
                con.Close();

            }
        }
    }
}
