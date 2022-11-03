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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //registration click
        {

            Register reg = new Register();
            reg.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //profile click
        {
            Profile prof = new Profile();
            prof.Show();
            Close();
        }
    }
}
