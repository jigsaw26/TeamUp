using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        Boolean WindowOpened = false; 

        public Profile()
        {
            InitializeComponent();

            int resIndx = C_Localization.GetLanguage();
            if (resIndx == 3)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
                Localiz();
            }
            if (resIndx == 2)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");
                Localiz();
            }
            if (resIndx == 1)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("");
                Localiz();
            }

        }

        void Localiz()
        {
            B_Home.Content = Localization.MainMenu1;
            B_Messages.Content = Localization.MainMenu2;
            B_Notification.Content = Localization.MainMenu3;
            B_Events.Content = Localization.MainMenu4;
            B_Work.Content = Localization.MainMenu5;
            B_Settings.Content = Localization.MainMenu6;
            L_country.Content = Localization.MainProfile3;
            L_born.Content = Localization.MainProfile4;
            L_conactinfo.Content = Localization.MainProfile5;
            B_EditProf.Content = Localization.MainProfile6;
            L_Posts.Content = Localization.MainData1;
            L_Media.Content = Localization.MainData2;
            L_Projects.Content = Localization.MainData3;
            L_CV.Content = Localization.MainData4;
        }


        private void B_Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            CWindowState();
            home.Show();
            Close();
        }

        private void B_Settings_Click(object sender, RoutedEventArgs e)
        {
            if (С_Settigs.GetWindow() == 0)
            {
                С_Settigs.SetWindow(1);

                Settings settings = new Settings();
                settings.Owner = this;

                if (settings.ShowDialog() == true) { }
            }
        }

        private void B_Messages_Click(object sender, RoutedEventArgs e)
        {
            Messages messages = new Messages();
            CWindowState();
            messages.Show();
            Close();
        }

        private void B_Notification_Click(object sender, RoutedEventArgs e)
        {
            InDev indev = new InDev();
            CWindowState();
            indev.Show();
            Close();
        }

        private void B_Events_Click(object sender, RoutedEventArgs e)
        {
            Events indev = new Events();
            CWindowState();
            indev.Show();
            Close();
        }

        private void B_Work_Click(object sender, RoutedEventArgs e)
        {
            InDev indev = new InDev();
            CWindowState();
            indev.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        void CWindowState()
        {
            C_WindowState.SetWindowStateHeight(this.Height);
            C_WindowState.SetWindowStateWidth(this.Width);
            C_WindowState.SetWindowStateTop(this.Top);
            C_WindowState.SetWindowStateLeft(this.Left);
        }

        int fl = 0;
        private void FormProfile_MouseMove(object sender, MouseEventArgs e)
        {
            if (fl == 0) LoadWindowState();
            fl++;
        }

        void LoadWindowState()
        { 
            this.Width = C_WindowState.GetWindowStateWidth();
            this.Height = C_WindowState.GetWindowStateHeight();

            this.Top = C_WindowState.GetWindowStateTop();
            this.Left = C_WindowState.GetWindowStateLeft();
        } 
    }
}
