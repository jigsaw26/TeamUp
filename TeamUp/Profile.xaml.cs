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
using System.Windows.Shapes;

namespace TeamUp
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
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
            Close();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
