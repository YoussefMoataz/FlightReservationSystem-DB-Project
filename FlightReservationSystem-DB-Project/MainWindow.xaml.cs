﻿using FlightReservationSystem_DB_Project.FlightReservationDataSetTableAdapters;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightReservationSystem_DB_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const string CONNECTION_STRING_YOUSSEF = "Data Source=YOUSSEF-LENOVO5\\SQLEXPRESS;Initial Catalog=FlightReservation;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
