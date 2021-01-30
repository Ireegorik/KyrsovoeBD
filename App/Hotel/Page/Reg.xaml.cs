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
using static Hotel.Holder;
namespace Hotel.Page
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : System.Windows.Controls.Page
    {
        public Reg()
        {
            InitializeComponent();
            Random random = new Random();
            Captch.Content = random.Next(9999999).ToString();
        }

        private void auths(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page.Auth();
        }

        private void regis(object sender, RoutedEventArgs e)
        {
            if ((string)Captch.Content == CaptchaT.Text)
            {
                if (bd.Users.Find(Login.Text) == null)
                {
                    user = new Users { Login = Login.Text, Password = Password.Text, Role = 0 };
                    bd.Users.Add(user);
                    bd.SaveChanges();
                    MainFrame.Content = new Page.TakeRoom();
                }
            }
        }
    }
}
