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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : System.Windows.Controls.Page
    {
        public Auth()
        {
            InitializeComponent();
            Random random = new Random();
            Captch.Content = random.Next(9999999).ToString();
        }
        private void Regis(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page.Reg();
        }

        private void auths(object sender, RoutedEventArgs e)
        {
            if ((string)Captch.Content == CaptchaT.Text)
            {
                Users u =  bd.Users.Find(Login.Text);
                if ((u != null)&&(u.Password ==Password.Text))
                {
                    if (u.Role == 0) { user = u; MainFrame.Content = new Page.TakeRoom(); } else { user = u; MainFrame.Content = new Page.AddRoom();}
                }
            }
        }
    }
}
