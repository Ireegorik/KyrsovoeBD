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
using static Airs.Interface;

namespace Airs.Pages
{
    /// <summary>
    /// Логика взаимодействия для SighIn.xaml
    /// </summary>
    public partial class SighIn : Page
    {
        public SighIn()
        {
            InitializeComponent();
            Random r = new Random((int)DateTime.Now.Ticks);
            Captcha.Content = r.Next();
        }
        private void Registrarion_button(object sender, RoutedEventArgs e)
        {
            if (EnterCapcha.Text == Captcha.Content.ToString())
            {
                
                    if (airPort.Login_Password.Find(Login.Text, Password.Text) != null)
                    {
                        Login_Password lg = airPort.Login_Password.Find(Login.Text, Password.Text);
                        Role = lg.Role;
                        username = lg.Login;
                        password = lg.Password;
                    switch (Role)
                    {
                        case 0:
                            Sires = (int)lg.Password_Sires;
                            Number = (int)lg.Password_Number;
                            break;
                        case 1:
                            
                            foreach(Login_Password LP  in airPort.Login_Password)
                            {
                                if(LP.Login == username)
                                {
                                    Id = LP.Id;
                                }
                            }
                            break;
                        case 2:
                            foreach (Login_Password LP in airPort.Login_Password)
                            {
                                if (LP.Login == username)
                                {
                                    Id = LP.Id;
                                }
                            }
                            break;
                    }
                        MainFrame.Content = new MainMenu();
                    }
                    else
                    {
                        Error.Content = "This user not Exists";
                    }
            }
            else
            {
                Error.Content = "You are entered uncorrect capcha";
            }
        }
        private void Back_butt(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Greetings());
        }

    }
}
