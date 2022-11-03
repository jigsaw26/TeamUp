using System; 
using System.ComponentModel; 
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Input;  
using System.Runtime.InteropServices;
using System.Windows.Media;

namespace TeamUp
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        //Это флаг по сокрытию текста подсказки в поле поиска
        int x = 0;

        public Settings()
        {
            InitializeComponent();

            Tbox_Search.Text = "Search Settings";//подсказка
        }

        private void B_Account_Click(object sender, RoutedEventArgs e)
        {
            btn1.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Hidden;
            btn3.Visibility = Visibility.Hidden;
            btn4.Visibility = Visibility.Hidden;
            this.IsEnabled = true;
            
        }

        private void B_Security_Click(object sender, RoutedEventArgs e)
        {
            btn1.Visibility = Visibility.Hidden;
            btn2.Visibility = Visibility.Visible;
            btn3.Visibility = Visibility.Hidden;
            btn4.Visibility = Visibility.Hidden;
            this.IsEnabled = true;
        }

        private void B_Notifications_Click(object sender, RoutedEventArgs e)
        {
            btn1.Visibility = Visibility.Hidden;
            btn2.Visibility = Visibility.Hidden;
            btn3.Visibility = Visibility.Visible;
            btn4.Visibility = Visibility.Hidden;
            this.IsEnabled = true;
        }

        private void B_Languages_Click(object sender, RoutedEventArgs e)
        {
            btn1.Visibility = Visibility.Hidden;
            btn2.Visibility = Visibility.Hidden;
            btn3.Visibility = Visibility.Hidden;
            btn4.Visibility = Visibility.Visible;
            this.IsEnabled = true;
        }

        private void Tbox_Search_MouseEnter(object sender, MouseEventArgs e)
        { 
            if (x == 0) Tbox_Search.Text = null; 
            x++; 
        }
         

        private void Tbox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tbox_Search.Text.Length >= 3)
            {
                if (Tbox_Search.Text == B_Languages.Content.ToString()) B_Languages_Click(sender, e);
                if (Tbox_Search.Text == B_Account.Content.ToString()) B_Account_Click(sender, e);
                if (Tbox_Search.Text == "Password") B_Account_Click(sender, e); 
                if (Tbox_Search.Text == B_Notifications.Content.ToString()) B_Notifications_Click(sender, e);
                if (Tbox_Search.Text == B_Security.Content.ToString()) B_Security_Click(sender, e); 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfilrmWindow confilrmWindow = new ConfilrmWindow();
            if (confilrmWindow.ShowDialog() == true)
            {
                Login log = new Login();
                log.Show();
                Close();
            }
            
        }
    } 
}
