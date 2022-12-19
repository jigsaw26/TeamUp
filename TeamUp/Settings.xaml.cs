using System; 
using System.ComponentModel; 
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Input;  
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Xml;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Collections.Generic; 
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Linq;
using System.Runtime;
using System.Globalization;
using System.Threading;

namespace TeamUp
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        IFirebaseConfig Config = new FirebaseConfig { AuthSecret = "OwoqQp9UnoO3kygLu7OJL7mFXOdNL1oPHIbHyFLz", BasePath = "https://teamup-c8aff-default-rtdb.europe-west1.firebasedatabase.app" };
        IFirebaseClient Client;

        //Это флаг по сокрытию текста подсказки в поле поиска
        int x = 0;

        public Settings()
        {
            InitializeComponent();

            Combo_Load();

            Client = new FireSharp.FirebaseClient(Config);
            //Tbox_Search.Text = "Search Settings";

            CheckLocaliz();


        }

        void CheckLocaliz()
        {
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
            L_Languages.Content = Localization.Languages1;
            L_SelectLanguage.Content = Localization.Languages2;
            B_En.Content = Localization.Languages3;
            B_Ger.Content = Localization.Languages4;
            B_Rus.Content = Localization.Languages5;

            B_Account.Content = Localization.Setting1;
            B_Security.Content = Localization.Setting2;
            B_Notifications.Content = Localization.Setting3;
            B_Languages.Content = Localization.Setting4;
            B_LogOff.Content = Localization.Setting5;
            Exit_Settings.Content = Localization.Setting6;

            L_Settings.Content = Localization.MainMenu6; 
            B_Save.Content = Localization.Security5;

            L_Notifications.Content = Localization.Notifications1;
            L_EnableNotif.Content = Localization.Notifications2;
            L_Preferences.Content = Localization.Notifications3;
            CB_Likes.Content = Localization.Notifications4;
            CB_Firends.Content = Localization.Notifications5;
            CB_Messages.Content = Localization.Notifications6;
            CB_Posts.Content = Localization.Notifications7; 
        }

        private void B_Account_Click(object sender, RoutedEventArgs e)
        {
            btn1.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Hidden;
            btn3.Visibility = Visibility.Hidden;
            btn4.Visibility = Visibility.Hidden;
            this.IsEnabled = true;

            string em = С_Email.GetEmail(); 
            string email = em.Substring(0, em.IndexOf('@')); 
            FirebaseResponse res = Client.Get(@"users/" + email); // Открываю нужную ветку в БД
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(res.Body.ToString()); // Добавляю всё содержмое ветки в словарь 
            var Info = new UserInfo
            {
                userName = data.ElementAt(3).Value,
                userSurname = data.ElementAt(5).Value,
                userDateOfBirth = data.ElementAt(1).Value,
                userCountry = data.ElementAt(0).Value,
                userEmail = data.ElementAt(2).Value,
                userPassword = data.ElementAt(4).Value
            };

            my_TextBox.Text = Info.userName;
            my_TextBox2.Text = Info.userSurname;
            my_TextBox3.Text = Info.userDateOfBirth;
            Text_Country.Text = Info.userCountry;
            my_TextBox5.Text = Info.userEmail; 
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


        private void B_Save_Click(object sender, RoutedEventArgs e)
        {
            string em = С_Email.GetEmail();
            string email = em.Substring(0, em.IndexOf('@'));
            var Info = new UserInfo
            {
                userName = my_TextBox.Text,
                userSurname = my_TextBox2.Text,
                userDateOfBirth = my_TextBox3.Text,
                userCountry = Text_Country.Text,
                userEmail = my_TextBox5.Text
            };
            FirebaseResponse respone = Client.Set("users/" + email, Info);
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

        //private void Tbox_Search_MouseEnter(object sender, MouseEventArgs e)
        //{ 
        //    if (x == 0) Tbox_Search.Text = null; 
        //    x++; 
        //}
        

        //private void Tbox_Search_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (Tbox_Search.Text.Length >= 3)
        //    {
        //        if (Tbox_Search.Text == B_Languages.Content.ToString()) B_Languages_Click(sender, e);
        //        if (Tbox_Search.Text == B_Account.Content.ToString()) B_Account_Click(sender, e);
        //        if (Tbox_Search.Text == "Password") B_Account_Click(sender, e); 
        //        if (Tbox_Search.Text == B_Notifications.Content.ToString()) B_Notifications_Click(sender, e);
        //        if (Tbox_Search.Text == "Pass") B_Account_Click(sender, e);
        //        if (Tbox_Search.Text == "Name") B_Account_Click(sender, e);
        //        if (Tbox_Search.Text == "Surname") B_Account_Click(sender, e);
        //        if (Tbox_Search.Text == "Country") B_Account_Click(sender, e);
        //        if (Tbox_Search.Text == "Email") B_Account_Click(sender, e);
        //        if (Tbox_Search.Text == "Likes") B_Notifications_Click(sender, e);
        //        if (Tbox_Search.Text == "Fiends") B_Notifications_Click(sender, e);
        //        if (Tbox_Search.Text == "Messages") B_Notifications_Click(sender, e);
        //        if (Tbox_Search.Text == "Posts") B_Notifications_Click(sender, e);
        //        if (Tbox_Search.Text == "English") B_Languages_Click(sender, e);
        //        if (Tbox_Search.Text == "Russian") B_Languages_Click(sender, e);
        //        if (Tbox_Search.Text == "Ukrainian") B_Languages_Click(sender, e);
        //        if (Tbox_Search.Text == B_Security.Content.ToString())
        //        {
        //            B_Security_Click(sender, e);
        //            B_Security.Background = Brushes.Blue;
        //        }
                  
        //    }
        //}

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

        private void B_pass_Click(object sender, RoutedEventArgs e)
        {
            if (Pass_Old.Password == "" || Pass_New1.Password == "" || Pass_New2.Password == "")
                MessageBox.Show("Заполните все поля");


            else
            {
                if (Pass_New1.Password != Pass_New2.Password) MessageBox.Show("Новый пароль не совпадает");
                
                if (CheckPassword(Pass_New2.Password) != 3)
                {
                    MessageBox.Show("Пароль не соответствует требованиям");
                }
                if (IsEmail(Email.Text) == 0)
                {
                    MessageBox.Show("Вы ввели не правильный адресс электронной почты");
                }
                else
                {
                    int Check = CheckPass();
                    if (Check != 2) MessageBox.Show("Старый пароль или логин не верный");
                }
            }
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



        public int CheckPass()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Users.xml");
            XmlElement xRoot = xDoc.DocumentElement;


            int y = 0;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("email");
                    if (attr != null) if (attr.Value == Email.Text) y++;
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (y == 1)
                        {
                            if (xnode.Attributes.Count > 0)
                            {
                                XmlNode attr1 = childnode.Attributes.GetNamedItem("pas");
                                if (attr1 != null)
                                {
                                    if (attr1.Value == Pass_Old.Password)
                                    {
                                        MessageBox.Show(attr1.Value);
                                        attr1.Value = Pass_New1.Password;
                                        y++;
                                        MessageBox.Show(attr1.Value); 
                                        MessageBox.Show(Pass_Old.Password);
                                        MessageBox.Show(Pass_New1.Password); 
                                    }
                                }
                            }
                        }
                        if (y == 2) break;
                    }
                }
            }
            xDoc.Save("Users.xml");

            return y; 
        }

        private void Exit_Settings_Click(object sender, RoutedEventArgs e)
        {
            С_Settigs.SetWindow(0);
            Close();
        }

        public void B_Rus_Click(object sender, RoutedEventArgs e)
        {
            C_Localization.SetLanguageRu();
            CheckLocaliz();
        }

        public void B_Ger_Click(object sender, RoutedEventArgs e)
        {
            C_Localization.SetLanguageNem();
            CheckLocaliz();
        }

        public void B_En_Click(object sender, RoutedEventArgs e)
        {
            C_Localization.SetLanguageEn(); 
            CheckLocaliz();
        }
    } 
}

