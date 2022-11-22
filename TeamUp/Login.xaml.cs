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
using System.Xml;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace TeamUp
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        IFirebaseConfig Config = new FirebaseConfig { AuthSecret = "OwoqQp9UnoO3kygLu7OJL7mFXOdNL1oPHIbHyFLz", BasePath = "https://teamup-c8aff-default-rtdb.europe-west1.firebasedatabase.app" };
        IFirebaseClient Client;
        public Login()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
            Client = new FireSharp.FirebaseClient(Config);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            Close();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Text_Email.Text == "" || Text_Password.Password == "")

                MessageBox.Show("Заполните все поля");


            // Проверка почты. Нужна для того что бы узнать зарегистрирована ли почта
            FirebaseResponse chkMail = await Client.GetAsync(@"allEmail/");
            Dictionary<string, string> dataMail = JsonConvert.DeserializeObject<Dictionary<string, string>>(chkMail.Body.ToString());
 
            
            int check = 0;
            for (int i = 0; i < dataMail.Count; i++)
            {
                if (Text_Email.Text == dataMail.ElementAt(i).Value)
                {
                    check++;
                }
            }
            if (check >= 1)
            {
                LiveCall(); // Если всё ок, пускаем дальше
            }
            else
            {
                MessageBox.Show("Не верный логин или пароль");
            }

        }

        void LiveCall()
        {
            int x = 0;

            string email = Text_Email.Text.Substring(0, Text_Email.Text.IndexOf('@'));
            while (true)
            {

                FirebaseResponse res = Client.Get(@"users/" + email); // Открываю нужную ветку в БД
                Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(res.Body.ToString()); // Добавляю всё содержмое ветки в словарь
                С_Email.SetEmail(data.ElementAt(2).Value);
                x = Autorization(data);
                if (x == 1)
                {
                    Profile profile = new Profile();
                    profile.Show();
                    Close();
                    break;
                } 
            }
        }

        int Autorization(Dictionary<string, string> record)
        {
            if (Text_Email.Text == record.ElementAt(2).Value && Text_Password.Password.ToString() == record.ElementAt(4).Value) // Сравниваю емеил и пароль с БД
            {
                return 1;
            }
            else
            {
                MessageBox.Show("Не верный логин или пароль");
                return 0;
            }
        }
    }
}
