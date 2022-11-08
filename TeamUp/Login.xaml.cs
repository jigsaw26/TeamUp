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
            if (Text_Email.Text == "" || Text_Password.Password == "")
                MessageBox.Show("Заполните все поля");
            else
            {
                int Check = CheckEmail();
                if (Check == 0) MessageBox.Show("Не верно введен логин и пароль");
                else if (Check == 1) MessageBox.Show("Не верно введен логин или пароль");
                else 
                { 
                    Profile profile = new Profile();
                    profile.Show();
                    Close();
                } 
            } 
        }

        public int CheckEmail()
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
                    if (attr != null) if (attr.Value == Text_Email.Text) y++;
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (y == 1)
                        {
                            if (xnode.Attributes.Count > 0)
                            {
                                XmlNode attr1 = childnode.Attributes.GetNamedItem("pas");
                                if (attr != null) if (attr.Value == Text_Password.Password) y++;
                            } 
                        }
                        if (y == 2) break;
                    }
                }  
            }
            return y;
        }
    }
}
