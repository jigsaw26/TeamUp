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
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace TeamUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "OwoqQp9UnoO3kygLu7OJL7mFXOdNL1oPHIbHyFLz",
            BasePath = "https://teamup-c8aff-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        FirebaseClient client;

        public MainWindow()
        {
            InitializeComponent();

            client = new FirebaseClient(config);



            Login Login = new Login();
            Login.Show();
            Close();

        }

        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await client.SetAsync("test1/data1", TXT.Text);
                MessageBox.Show("done");
            }
            catch { }
        }
    }
}