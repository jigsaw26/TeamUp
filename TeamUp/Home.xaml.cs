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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeamUp
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {  
        //Это флаг по сокрытию текста подсказки в поле поиска
        int x = 0;

        int flagPost = 1;

        Grid[] GridMass = new Grid[10]; 

        public Home()
        {
            InitializeComponent(); 
            Tbox_Post.Text = "What's new?";//подсказка
            GridMass[0] = Post1;

            for (int i = 1; i < 10; i++)
            {
                Grid grid2 = new Grid();
                GridMass[i] = grid2;
            }



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
            TB_Dev.Text = Localization.HomeProfile3;
            B_Follow1.Content = Localization.Follow;
            B_Follow2.Content = Localization.Follow;
            B_Follow3.Content = Localization.Follow;
            B_ShowMore.Content = Localization.ShowMore;
            B_ShowMore2.Content = Localization.ShowMore;
            B_Post.Content = Localization.Notifications7;
            TB_What.Text = Localization.HomeNews1;
            TB_follow.Text = Localization.HomeNews2;
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

        private void Image_MouseDown(object sender, MouseButtonEventArgs e) //profile click -> profile page 
        {
            Profile prof = new Profile();
            CWindowState();
            prof.Show();
            Close();
        }
         

        private void Tbox_Post_MouseEnter(object sender, MouseEventArgs e)
        {
            if (x == 0) Tbox_Post.Text = null;
            x++;
        }

        private void B_Post_Click(object sender, RoutedEventArgs e)
        { 
            #region Создание первой половины поста

            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(250, GridUnitType.Pixel);
            GridMainPosts.RowDefinitions.Add(row);

            #region Цикл для дополнение постов
            for (int i = GridMass.Length - 1; i > -1; i--)
            {
                if (i == 0) break;
                GridMass[i] = GridMass[i - 1];
                if (GridMass[i] != null) Grid.SetRow(GridMass[i], i);
            }
            #endregion
             
            Grid grid = new Grid();
            GridMass[0] = grid;
            Grid.SetRow(GridMass[0], 0);
            grid.Margin = new Thickness(0, 30, 0, 0);

            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(2.0, GridUnitType.Star);
            grid.RowDefinitions.Add(row2);
            grid.RowDefinitions.Add(new RowDefinition());

            Border B1 = new Border();
            Grid.SetRowSpan(B1, 2);
            grid.Children.Add(B1);


            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Images/batsiev-round-photo-1.png", UriKind.Relative);
            bi3.EndInit();
            Image img = new Image();
            img.Source = bi3;
            img.Height = 79;
            img.Width = 77;
            img.HorizontalAlignment = HorizontalAlignment.Left;
            img.VerticalAlignment = VerticalAlignment.Top;
            img.Margin = new Thickness(20, 15, 0, 0);
            grid.Children.Add(img); 

            TextBlock t_Name = new TextBlock();
            t_Name.Foreground = Brushes.Gray;
            t_Name.Margin = new Thickness(110, 25, 0, 0);
            t_Name.HorizontalAlignment = HorizontalAlignment.Left;
            t_Name.VerticalAlignment = VerticalAlignment.Top;
            t_Name.FontSize = 18;
            t_Name.Text = "Andrew Rudenko";
            grid.Children.Add(t_Name);
             
            TextBlock t_Nik = new TextBlock();
            t_Nik.Foreground = Brushes.Gray;
            t_Nik.Margin = new Thickness(110, 45, 0, 0);
            t_Nik.HorizontalAlignment = HorizontalAlignment.Left;
            t_Nik.VerticalAlignment = VerticalAlignment.Top;
            t_Nik.FontSize = 12;
            t_Nik.Text = "@andrew_rudenko";
            grid.Children.Add(t_Nik);
             
            TextBlock t_Text = new TextBlock();
            t_Text.Margin = new Thickness(110, 65, 0, 0);
            t_Text.HorizontalAlignment = HorizontalAlignment.Left;
            t_Text.VerticalAlignment = VerticalAlignment.Top;
            t_Text.FontSize = 16;
            t_Text.Text = Tbox_Post.Text;
            grid.Children.Add(t_Text);

            #endregion


            #region Вторая половина поста

            Grid grid2 = new Grid();
            Grid.SetRow(grid2, 1);
            grid.Children.Add(grid2);

            ColumnDefinition col = new ColumnDefinition();
            col.Width = new GridLength(0.7, GridUnitType.Star);
            grid2.ColumnDefinitions.Add(col);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition());

            //1
            StackPanel SP = new StackPanel();
            SP.Orientation = Orientation.Horizontal;
            Grid.SetColumn(SP, 1);
            grid2.Children.Add(SP);

            BitmapImage bi4 = new BitmapImage();
            bi4.BeginInit();
            bi4.UriSource = new Uri("Images/Like icon.png", UriKind.Relative);
            bi4.EndInit();
            Image img2 = new Image();
            img2.Source = bi4;
            img2.Height = 50;
            img2.Width = 50;
            img2.HorizontalAlignment = HorizontalAlignment.Left;
            img2.VerticalAlignment = VerticalAlignment.Top;
            img2.Margin = new Thickness(0, 15, 0, 0);
            SP.Children.Add(img2);

            TextBlock t_Like = new TextBlock();
            t_Like.Margin = new Thickness(20, 0, 0, 0);
            t_Like.VerticalAlignment = VerticalAlignment.Center;
            t_Like.Height = 30;
            t_Like.FontSize = 25;
            t_Like.Text = "0";
            SP.Children.Add(t_Like);

            //2
            StackPanel SP2 = new StackPanel();
            SP2.Orientation = Orientation.Horizontal;
            Grid.SetColumn(SP2, 2);
            grid2.Children.Add(SP2);

            BitmapImage bi5 = new BitmapImage();
            bi5.BeginInit();
            bi5.UriSource = new Uri("Images/Reply icon.png", UriKind.Relative);
            bi5.EndInit();
            Image img3 = new Image();
            img3.Source = bi5;
            img3.Height = 50;
            img3.Width = 50;
            img3.HorizontalAlignment = HorizontalAlignment.Left;
            img3.VerticalAlignment = VerticalAlignment.Top;
            img3.Margin = new Thickness(0, 15, 0, 0);
            SP2.Children.Add(img3);

            TextBlock t_Like2 = new TextBlock();
            t_Like2.Margin = new Thickness(20, 0, 0, 0);
            t_Like2.VerticalAlignment = VerticalAlignment.Center;
            t_Like2.Height = 30;
            t_Like2.FontSize = 25;
            t_Like2.Text = "0";
            SP2.Children.Add(t_Like2);

            //3
            StackPanel SP3 = new StackPanel();
            SP3.Orientation = Orientation.Horizontal;
            Grid.SetColumn(SP3, 3);
            grid2.Children.Add(SP3);

            BitmapImage bi6 = new BitmapImage();
            bi6.BeginInit();
            bi6.UriSource = new Uri("Images/Repost icon.png", UriKind.Relative);
            bi6.EndInit();
            Image img4 = new Image();
            img4.Source = bi6;
            img4.Height = 50;
            img4.Width = 50;
            img4.HorizontalAlignment = HorizontalAlignment.Left;
            img4.VerticalAlignment = VerticalAlignment.Top;
            img4.Margin = new Thickness(0, 15, 0, 0);
            SP3.Children.Add(img4);

            TextBlock t_Like3 = new TextBlock();
            t_Like3.Margin = new Thickness(20, 0, 0, 0);
            t_Like3.VerticalAlignment = VerticalAlignment.Center;
            t_Like3.Height = 30;
            t_Like3.FontSize = 25;
            t_Like3.Text = "0";
            SP3.Children.Add(t_Like3);

            //4
            StackPanel SP4 = new StackPanel();
            SP4.Orientation = Orientation.Horizontal;
            Grid.SetColumn(SP4, 4);
            grid2.Children.Add(SP4);

            BitmapImage bi7 = new BitmapImage();
            bi7.BeginInit();
            bi7.UriSource = new Uri("Images/Share icon.png", UriKind.Relative);
            bi7.EndInit();
            Image img5 = new Image();
            img5.Source = bi7;
            img5.Height = 50;
            img5.Width = 50;
            img5.HorizontalAlignment = HorizontalAlignment.Left;
            img5.VerticalAlignment = VerticalAlignment.Top;
            img5.Margin = new Thickness(0, 15, 0, 0);
            SP4.Children.Add(img5); 
            #endregion





            //Button btn = new Button();
            //btn.Content = "test";
            //Grid.SetRow(btn, 2);
            //Grid.SetColumn(btn, 0);
            //Grid.SetColumnSpan(btn, 2);
            //grid.Children.Add(btn);


            //и т.д. 
            GridMainPosts.Children.Add(grid);
        }

        void CWindowState()
        {
            C_WindowState.SetWindowStateHeight(this.Height);
            C_WindowState.SetWindowStateWidth(this.Width);
            C_WindowState.SetWindowStateTop(this.Top);
            C_WindowState.SetWindowStateLeft(this.Left);
        }

        int fl = 0;
        private void FormHome_MouseMove(object sender, MouseEventArgs e)
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
