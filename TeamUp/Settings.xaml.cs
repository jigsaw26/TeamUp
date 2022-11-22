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
            Client = new FireSharp.FirebaseClient(Config);
            //Tbox_Search.Text = "Search Settings";
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
            my_TextBox.Text = data.ElementAt(3).Value;
            my_TextBox2.Text = data.ElementAt(5).Value;
            my_TextBox3.Text = data.ElementAt(0).Value;
            my_TextBox4.Text = data.ElementAt(1).Value;
            my_TextBox5.Text = data.ElementAt(2).Value; 
        }

        private void B_Save_Click(object sender, RoutedEventArgs e)
        {
            string em = С_Email.GetEmail();
            string email = em.Substring(0, em.IndexOf('@'));
            FirebaseResponse res = Client.Get(@"users/" + email); // Открываю нужную ветку в БД
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(res.Body.ToString()); // Добавляю всё содержмое ветки в словарь 
            my_TextBox.Text = data.ElementAt(3).Value;
            my_TextBox2.Text = data.ElementAt(5).Value;
            my_TextBox3.Text = data.ElementAt(0).Value;
            my_TextBox4.Text = data.ElementAt(1).Value;
            my_TextBox5.Text = data.ElementAt(2).Value; 
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
                else
                {
                    int Check = CheckPass();
                    if (Check != 2) MessageBox.Show("Старый пароль или логин не верный");
                } 
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
    } 
}

