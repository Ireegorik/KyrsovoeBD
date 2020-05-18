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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        string Modes;
        
        public Auth(string Mode)
        {
            InitializeComponent();
            switch (Mode)
            {
                case "Admin":
                    Select.Visibility = Visibility.Visible;
                    break;
                case "User":
                    Select.Visibility = Visibility.Hidden;
                    Passenger.IsChecked = true;
                    break;
            }

            Random r = new Random((int)DateTime.Now.Ticks);
            Captcha.Content = r.Next();Modes = Mode;
        }
        private void Registrarion_button(object sender, RoutedEventArgs e)
        {
            if (EnterCapcha.Text == Captcha.Content.ToString())
            {
                if (Password.Text == ConfPass.Text)
                {
                    if (airPort.Login_Password.Find(Login.Text, Password.Text) == null)
                    {
                        if (Admin.IsChecked == true)
                        {

                            Login_Password lg = new Login_Password { Login = Login.Text, Password = Password.Text, Role = 2 };
                            Admins a = new Admins
                            {
                                Adress = AdressAdmin.Text,
                                Name = NameAdmin.Text,
                                Surname = SunameAdmin.Text,
                                Middle_Name = MiddleAdmin.Text,
                                Phone_Number = PhoneNumberAdmin.Text,
                                Login_Password = lg
                                
                                
                            };
                            if (airPort.Admins.Count() == 0) a.Admin_Id = 0; else
                            {
                                a.Admin_Id = 0;
                                foreach (Admins a1 in airPort.Admins)
                                {
                                    if (a.Admin_Id < a1.Admin_Id) a.Admin_Id = a1.Admin_Id + 1;
                                    if (a.Admin_Id == a1.Admin_Id) a.Admin_Id += 1;
                                }
                            }
                            switch (Modes)
                            {
                                case "Admin":

                                    break;
                                case "User":
                                    Id = a.Admin_Id;
                                    break;
                            }
                            lg.Id = Id;
                            airPort.Login_Password.Add(lg);
                            airPort.Admins.Add(a);
                            airPort.SaveChanges();
                        }
                        if (Pilot.IsChecked == true)
                        {
                            string Gender;
                            if (M.IsChecked == true)
                            {
                                Gender = "M";
                            }
                            else
                            {
                                Gender = "F";
                            }
                            DateTime dateTimeHire = new DateTime(Convert.ToInt32(Year.Text), Convert.ToInt32(Month.Text), Convert.ToInt32(Day.Text));

                            Login_Password lg = new Login_Password { Login = Login.Text, Password = Password.Text, Role = 1 };
                            Pilots p = new Pilots
                            {
                                
                                Name = Name.Text,
                                Surname = Surname.Text,
                                Middle_Name = MiddleName.Text,
                                Adress = Adress.Text,
                                Phone_Number = PhoneNumber.Text,
                                Gender = Gender,
                                Hire_Date = dateTimeHire,
                                Login_Password = lg
                            };
                            if (airPort.Pilots.Count() == 0) p.Pilot_Num = 0;
                            else
                            {
                                p.Pilot_Num = 0;
                                foreach (Pilots a1 in airPort.Pilots)
                                {
                                    if (p.Pilot_Num < a1.Pilot_Num) p.Pilot_Num = a1.Pilot_Num + 1;
                                    if (p.Pilot_Num == a1.Pilot_Num) p.Pilot_Num += 1;
                                }
                            }
                            lg.Id = Id;
                            airPort.Login_Password.Add(lg);
                            airPort.Pilots.Add(p);
                            airPort.SaveChanges();
                        }
                        if (Passenger.IsChecked == true)
                        {
                            string Gender;
                            if (MPas.IsChecked == true)
                            {
                                Gender = "M";
                            }
                            else
                            {
                                Gender = "F";
                            }
                            Login_Password lg = new Login_Password { Login = Login.Text, Password = Password.Text, Role = 0, Password_Number = Convert.ToInt32(PasNumber.Text),Password_Sires = Convert.ToInt32(PasSires.Text) };
                            Passengers p = new Passengers {
                                Name = NamePas.Text,
                                Surname = SunamePas.Text,
                                Middle_Name = MiddlePas.Text,
                                Citizenship = Citizen.Text,
                                Passport_Series = Convert.ToInt32(PasSires.Text),
                                Passport_Number = Convert.ToInt32(PasNumber.Text),
                                Gender = Gender,
                                Login_Password = lg
                            };
                            if(airPort.Passengers.Find(p.Passport_Number,p.Passport_Series) != null)
                            {
                                MessageBox.Show("Passport data is already registered");
                            }
                            else
                            {
                                switch (Modes)
                                {
                                    case "Admin":

                                        break;
                                    case "User":
                                Sires = Convert.ToInt32(PasSires.Text);
                                Number = Convert.ToInt32(PasNumber.Text);
                                username = Login.Text;
                                password = Login.Text;

                                        break;
                                }
                                airPort.Login_Password.Add(lg);
                                airPort.Passengers.Add(p);
                                airPort.SaveChanges();
                            }
                        }
                        
                        switch(Modes)
                        {
                            case "Admin":
                                MainFrame.Navigate(new MainMenu());
                                break;
                            case "User":
                                username = Login.Text;
                                password = Password.Text;
                                MainFrame.Navigate(new SighIn());
                                break;
                        }
                    }
                    else
                    {
                        Error.Content = "This user already Exists";
                    }
                }
                else
                {
                    Error.Content = "Your password and comfirm password not match";
                }
            }
            else
            {
                Error.Content = "You are entered uncorrect capcha";
            }
        }


        private void Back_butt(object sender, RoutedEventArgs e)
        {
            switch (Modes)
            {
                case "Admin":
                    MainFrame.Navigate(new MainMenu());
                    break;
                case "User":
                    MainFrame.Navigate(new Greetings());
                    break;
            }
        }

        private void Radio_Admin(object sender, RoutedEventArgs e)
        {
            InfosAdmin.Visibility = Visibility.Visible;
            InfosPassenger.Visibility = Visibility.Hidden;
            InfosPilot.Visibility = Visibility.Hidden;
        }

        private void Radio_Pilot(object sender, RoutedEventArgs e)
        {
            InfosAdmin.Visibility = Visibility.Hidden;
            InfosPassenger.Visibility = Visibility.Hidden;
            InfosPilot.Visibility = Visibility.Visible;
        }

        private void Radio_Passenger(object sender, RoutedEventArgs e)
        {
            InfosAdmin.Visibility = Visibility.Hidden;
            InfosPassenger.Visibility = Visibility.Visible;
            InfosPilot.Visibility = Visibility.Hidden;
        }
    }
}
