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
    /// Interaction logic for AdminRegistrationForm.xaml
    /// </summary>
    public partial class AdminRegistrationForm : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6BNM9LM\MSSQLSERVER1;Initial Catalog=FlightReservation;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True");
        public AdminRegistrationForm()
        {
            InitializeComponent();
            this.Title = "Admin Registration";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtFName.Text == "" || txtLName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtAge.Text == "" || txtAccessLevel.Text == "" || txtDateOfBirth.Text == "" || txtGender.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into ADMIN(SSN,FIRSTNAME,LASTNAME,GENDER,EMAIL,PASSWORD,DATEOFBIRTH,AGE,ACCESSLEVEL)values(@SSN,@FN,@LN,@G,@E,@P,@D,@AG,@AL)", con);
                    cmd.Parameters.AddWithValue("@SSN", txtSSN.Text);
                    cmd.Parameters.AddWithValue("@FN", txtFName.Text);
                    cmd.Parameters.AddWithValue("@LN", txtLName.Text);
                    cmd.Parameters.AddWithValue("@G", txtGender.Text);
                    cmd.Parameters.AddWithValue("@E", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@P", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@D", txtDateOfBirth.Text);
                    cmd.Parameters.AddWithValue("@Ag", txtAge.Text);
                    cmd.Parameters.AddWithValue("@AL", txtAccessLevel.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin Added");


                    con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
