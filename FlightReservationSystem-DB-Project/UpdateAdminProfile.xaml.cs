using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for UpdateAdminProfile.xaml
    /// </summary>
    /// 
    public partial class UpdateAdminProfile : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6BNM9LM\MSSQLSERVER1;Initial Catalog=FlightReservation;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=YOUSSEF-LENOVO5\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True");

        public Admin admin { get; set; }
        public UpdateAdminProfile(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            UpdateTextboxes();
        }

        private void UpdateTextboxes()
        {
            txtSSN.Text = admin.SSN.ToString();
            txtFName.Text = admin.FirstName;
            txtLName.Text = admin.LastName;
            txtDateOfBirth.Text = admin.DateOfBirth;
            txtAge.Text = admin.Age.ToString();
            txtAccessLevel.Text = admin.AccessLevel;
            txtEmail.Text = admin.Email;
            txtPassword.Text = admin.Password;
            txtGender.Text = admin.Gender;

            // set other textboxes as needed
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtFName.Text == "" || txtLName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtAge.Text == "" || txtDateOfBirth.Text == "" || txtGender.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update ADMIN set SSN=@SSN,FIRSTNAME=@FN,LASTNAME=@LN,GENDER=@G,EMAIL=@E,PASSWORD=@P,DATEOFBIRTH=@D,AGE=@AG,ACCESSLEVEL=@AL Where SSN=@Mkey", con);
                    cmd.Parameters.AddWithValue("@SSN", txtSSN.Text);
                    cmd.Parameters.AddWithValue("@FN", txtFName.Text);
                    cmd.Parameters.AddWithValue("@LN", txtLName.Text);
                    cmd.Parameters.AddWithValue("@G", txtGender.Text);
                    cmd.Parameters.AddWithValue("@E", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@AL", txtAccessLevel.Text);
                    cmd.Parameters.AddWithValue("@P", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@D", txtDateOfBirth.Text);
                    cmd.Parameters.AddWithValue("@Ag", txtAge.Text);
                    cmd.Parameters.AddWithValue("@Mkey", admin.SSN);




                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin updated");


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
