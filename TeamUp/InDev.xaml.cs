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

namespace TeamUp
{
    /// <summary>
    /// Interaction logic for InDev.xaml
    /// </summary>
    public partial class InDev : Window
    {
        public InDev()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        private void B_Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            Close();
        }

        private void B_Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();

        }

        private void B_Messages_Click(object sender, RoutedEventArgs e)
        {
            InDev indev = new InDev();
            indev.Show();
            Close();
        }

        private void B_Notification_Click(object sender, RoutedEventArgs e)
        {
            InDev indev = new InDev();
            indev.Show();
            Close();
        }

        private void B_Events_Click(object sender, RoutedEventArgs e)
        {
            InDev indev = new InDev();
            indev.Show();
            Close();
        }

        private void B_Work_Click(object sender, RoutedEventArgs e)
        {
            InDev indev = new InDev();
            indev.Show();
            Close();
        }
    }
}
