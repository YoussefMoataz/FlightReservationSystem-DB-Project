﻿using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {

        public Admin admin { get; set; }
        public AdminDashboard(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            
        }

        private void Flight_Button_Click(object sender, RoutedEventArgs e)
        {
            AddFlightForm addFlightForm = new AddFlightForm();
            addFlightForm.Show();
        }

        private void Aircraft_Button_Click(object sender, RoutedEventArgs e)
        {
            AircraftWindow aircraft = new AircraftWindow();
            aircraft.Show();
        }

        private void UpdateProfile_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateAdminProfile update = new UpdateAdminProfile(admin);
            update.Show();
        }
    }
}
