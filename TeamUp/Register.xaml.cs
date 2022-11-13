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
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace TeamUp
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        //IFirebaseConfig Config = new FirebaseConfig { AuthSecret = "OwoqQp9UnoO3kygLu7OJL7mFXOdNL1oPHIbHyFLz", BasePath = "https://teamup-c8aff-default-rtdb.europe-west1.firebasedatabase.app" };
       // IFirebaseClient Client;

        public Register()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
           // Client = new FireSharp.FirebaseClient(Config);
        }

       /* private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateUser();
            
        }

        private async void CreateUser()
        {
            var Info = new UserInfo{
                userNameV = Text_Name.Text,
                emailV = Text_Email.Text,
                passwordV = Text_Counrty 
            };
            FirebaseResponse respone = await Client.SetAsync("users/"+Text_Name.Text, Info);
            MessageBox.Show("Готово");
        }
        */
        private void Button_Click(object sender, RoutedEventArgs e)
        {  
            if (Text_Name.Text == "" || Text_Surname.Text == "" || Text_Counrty.Text == "" || Text_Date.Text == "" || Text_Email.Text == "" || Text_Password.Password == "" || Text_Password2.Password == "")
                MessageBox.Show("Заполните все поля");
            else if (Text_Password.Password != Text_Password2.Password)
                MessageBox.Show("Пароль не совпадает"); 
            else
            {
                int Check = CheckEmail();
                if (Check == 1) MessageBox.Show("Такой пользователь уже существует");
                else
                { 
                    string[] AtribteName = new string[6] { "User", "Name", "Surname", "Country", "Date", "Password" }; 
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load("Users.xml"); 
                    XmlElement xRoot = xDoc.DocumentElement;

                    XmlElement KatalElem = xDoc.CreateElement(AtribteName[0]);
                    xRoot.AppendChild(KatalElem);
                    XmlAttribute nameAttr = xDoc.CreateAttribute("email");
                    nameAttr.Value = Text_Email.Text;
                    KatalElem.Attributes.Append(nameAttr);

                    XmlElement AtrElem;
                    XmlText Text;

                    AtrElem = xDoc.CreateElement(AtribteName[1]);
                    KatalElem.AppendChild(AtrElem);
                    Text = xDoc.CreateTextNode(Text_Name.Text);
                    AtrElem.AppendChild(Text);


                    AtrElem = xDoc.CreateElement(AtribteName[2]);
                    KatalElem.AppendChild(AtrElem);
                    Text = xDoc.CreateTextNode(Text_Surname.Text);
                    AtrElem.AppendChild(Text);


                    AtrElem = xDoc.CreateElement(AtribteName[3]);
                    KatalElem.AppendChild(AtrElem);
                    Text = xDoc.CreateTextNode(Text_Counrty.Text);
                    AtrElem.AppendChild(Text);


                    AtrElem = xDoc.CreateElement(AtribteName[4]);
                    KatalElem.AppendChild(AtrElem);
                    Text = xDoc.CreateTextNode(Text_Date.Text);
                    AtrElem.AppendChild(Text);


                    AtrElem = xDoc.CreateElement(AtribteName[5]);
                    KatalElem.AppendChild(AtrElem);
                    Text = xDoc.CreateTextNode(Text_Password.Password);
                    AtrElem.AppendChild(Text);
                     
                    xDoc.Save("Users.xml");

                    Profile profile = new Profile();
                    profile.Show();
                    Close();
                }
            } 
        }


        
        private void Open_LogIn_page_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
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
                }
                if (y == 1) break;
            }
            return y;
        }
    }
}
