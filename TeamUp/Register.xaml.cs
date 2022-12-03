using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq; 
using System.Windows; 
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace TeamUp
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        IFirebaseConfig Config = new FirebaseConfig { AuthSecret = "OwoqQp9UnoO3kygLu7OJL7mFXOdNL1oPHIbHyFLz", BasePath = "https://teamup-c8aff-default-rtdb.europe-west1.firebasedatabase.app" };
        IFirebaseClient Client;

        public Register()
        {
            InitializeComponent();
            Combo_Load();
            Client = new FireSharp.FirebaseClient(Config);
             
        }

        public void Combo_Load()

        {
            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
            foreach (CultureInfo cul in cinfo)

            {
                int pos = cul.EnglishName.LastIndexOf('(');
                string temp = cul.EnglishName.Substring(pos + 1);
                string country = temp.Substring(0, temp.IndexOf(')'));
                Text_Country.Items.Add(country);
            }

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (Text_Name.Text == "" || Text_Surname.Text == "" || Text_Country.Text == "" || Text_Date.Text == "" || Text_Email.Text == "" || Text_Password.Password == "" || Text_Password2.Password == "")
                MessageBox.Show("Заполните все поля");
            else if (Text_Password.Password != Text_Password2.Password)
                MessageBox.Show("Пароль не совпадает");
            else
            {           
                if (IsEmail(Text_Email.Text) == 0)
                {
                    MessageBox.Show("Вы ввели не правильный адресс электронной почты");
                }

                if (CheckPassword(Text_Password.Password) != 3)
                {
                    MessageBox.Show("Пароль не соответствует требованиям");
                }
                else
                {
                    LiveCall(); // Получаю список всех почт для проверки 
                }
            }

        }

        public async void Reg()
        {
            string g = Text_Country.Text;
           
            Random rnd = new Random();
            var Info = new UserInfo
            {
                userName = Text_Name.Text,
                userSurname = Text_Surname.Text,
                userDateOfBirth = Text_Date.Text,
                userCountry = g,
                userEmail = Text_Email.Text,
                userPassword = Text_Password.Password.ToString()
            };

            string email = Text_Email.Text.Substring(0, Text_Email.Text.IndexOf('@'));
            try
            {
                await Client.SetAsync("users/" + email, Info); // Создаю новый аккаунт
                await Client.SetAsync("allEmail/" + rnd.Next(9999).ToString(), Text_Email.Text); // Вношу почту в БД

                Login login = new Login();
                login.Show();
                Close();
            }
            catch { }
        }

        async void LiveCall() // Получаю список всех почт для проверки 
        {

            while (true)
            {
                FirebaseResponse res = await Client.GetAsync(@"allEmail/");  
                Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(res.Body.ToString());// Добавляю всё содержмое ветки в словарь  
                CheckEmail(data);
                break;
            }
        }

        void CheckEmail(Dictionary<string, string> record)
        {
            int check = 0;
            for (int i = 0; i < record.Count; i++)
              {
                  if (Text_Email.Text == record.ElementAt(i).Value)
                  {
                      check++;
                  }
              }
            if (check >= 1)
                MessageBox.Show("Эта почта занята");
            else
            {
                Reg();
            }
        }


        private void Open_LogIn_page_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login(); 
            login.Show();
            Close();
        }


         public int CheckPassword(string value)
         {
             int x = 0;
             if (value.Length >= 8) x++;
             var Symbols = new[] { '(', '_', '!', '"', '№', ';', '%', ':', '?', '*', ')', '"' };
             if (value.Any(ch => Symbols.Contains(ch))) x++;

             int temp = 0;
             for (int i = 0; i < value.Length; i++)
                 if (value[i] >= '0' && value[i] <= '9')
                     temp++;


             if (temp >= 1) x++;

             return x;

         }

         public int IsEmail(string value)
         {
             int x = 0;
             try
             {
                 var addr = new System.Net.Mail.MailAddress(value);
                 x++;
                 return x;
             }
             catch
             {
                 return x;
             }
         }
         

        int fl = 0;
        private void FormRegistr_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
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

