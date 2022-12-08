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
    /// Interaction logic for InDev.xaml
    /// </summary>
    public partial class InDev : Window
    {
        Boolean WindowOpened = false;

        public InDev()
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

            L_construction.Content = Localization.DevPage1;
            L_updates.Content = Localization.DevPage2;
            B_Home1.Content = Localization.DevPage3;
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
                settings.Show();
            }
        }

        private void B_Messages_Click(object sender, RoutedEventArgs e)
        {
            InDev indev = new InDev();
            CWindowState();
            indev.Show();
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
            InDev indev = new InDev();
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
        void CWindowState()
        {
            C_WindowState.SetWindowStateHeight(this.Height);
            C_WindowState.SetWindowStateWidth(this.Width);
            C_WindowState.SetWindowStateTop(this.Top);
            C_WindowState.SetWindowStateLeft(this.Left);
        }

        int fl = 0;
        private void FormInDev_MouseMove(object sender, MouseEventArgs e)
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
