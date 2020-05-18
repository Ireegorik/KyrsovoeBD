using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;

namespace Airs.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public  Flights F { get; set; }
        SolidColorBrush brush = new SolidColorBrush(Colors.LightGray);
        public MainMenu()
        {
            brush.Opacity = 0.6;
            InitializeComponent();
            StackPanel myStackPanel;
            switch (Role)
            {

                case 1:
                    Pil.Visibility = Visibility.Visible;
                    Passenger.Visibility = Visibility.Hidden;
                    Admin.Visibility = Visibility.Hidden;

                    Pilots p = airPort.Pilots.Find(Id);
                    Name.Text = p.Name;
                    Surname.Text = p.Surname;
                    MiddleName.Text = p.Middle_Name;
                    Adress.Text = p.Adress;
                    PhoneNumber.Text = p.Phone_Number;
                    HireDate.Content = p.Hire_Date;
                    switch (p.Gender)
                    {
                        case "F":
                            Gender.Content = "Female";
                            break;
                        case "M":
                            Gender.Content = "Male";
                            break;
                    }
                    break;
                case 0:
                    Passenger.Visibility = Visibility.Visible;
                    Admin.Visibility = Visibility.Hidden;
                    Pil.Visibility = Visibility.Hidden;
                    Passengers pas = airPort.Passengers.Find(Number,Sires);
                    NamePas.Text = pas.Name;
                    SurnamePas.Text = pas.Surname;
                    MiddleNamePas.Text = pas.Middle_Name;
                    Citizen.Text = pas.Citizenship;
                    PAsS.Content = pas.Passport_Series;
                    PasN.Content = pas.Passport_Number;
                    GenderPas.Content = pas.Gender;
                    ListTicketsBuy.ItemsSource = airPort.Flights.ToList();
                     myStackPanel = new StackPanel();
                    myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    myStackPanel.VerticalAlignment = VerticalAlignment.Top;
                    foreach (AirPort a in airPort.AirPort.ToList())
                    {
                        RadioButton r = new RadioButton();
                        r.GroupName = "AirPortsFROMS";
                        TextBlock text = new TextBlock();
                        text.Background = brush; text.Text = a.Name;
                        r.Content = text;
                        r.Checked += CheckFROMS;
                        myStackPanel.Children.Add(r);

                    }
                    ChoiceAirPortFromS.Content = myStackPanel;
                    myStackPanel = new StackPanel();
                    myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    myStackPanel.VerticalAlignment = VerticalAlignment.Top;
                    foreach (AirPort a in airPort.AirPort.ToList())
                    {
                        RadioButton r = new RadioButton();
                        r.GroupName = "AirPortsTOS";
                        TextBlock text = new TextBlock();
                        text.Background = brush; text.Text = a.Name;
                        r.Content = text;
                        r.Checked += CheckTOS;
                        myStackPanel.Children.Add(r);

                    }
                    ChoiceAirPortToS.Content = myStackPanel;
                    //myStackPanel = new StackPanel();
                    //myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    //myStackPanel.VerticalAlignment = VerticalAlignment.Top;
                    //foreach (Seets_On_The_Plane a in airPort.Seets_On_The_Plane.ToList())
                    //{
                    //    RadioButton r = new RadioButton();
                    //    r.GroupName = "Rows";
                    //    r.Content = a.Row_Num;
                    //    myStackPanel.Children.Add(r);
                    //}
                    //ChoiceRow.Content = myStackPanel;
                    //myStackPanel = new StackPanel();
                    //myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    //myStackPanel.VerticalAlignment = VerticalAlignment.Top;
                    //foreach (Seets_On_The_Plane a in airPort.Seets_On_The_Plane.ToList())
                    //{
                    //    RadioButton r = new RadioButton();
                    //    r.GroupName = "Place";
                    //    r.Content = a.Place_Num;
                    //    myStackPanel.Children.Add(r);
                    //}
                    //ChoicePlace.Content = myStackPanel;

                    YearFlightS.Text = DateTime.Now.Year.ToString();
                    MonthFlightS.Text = DateTime.Now.Month.ToString();
                    DayFlightS.Text = DateTime.Now.Day.ToString();
                    break;
                case 2:
                    Admins Admi = airPort.Admins.Find(Id);
                    NameAdmin.Text = Admi.Name;
                    SurnameAdmin.Text = Admi.Surname;
                    MiddleNameAdmin.Text = Admi.Middle_Name;
                    AdressAdmin.Text = Admi.Adress;
                    PhoneNumberAdmin.Text = Admi.Phone_Number;
                    Admin.Visibility = Visibility.Visible;
                    Passenger.Visibility = Visibility.Hidden;
                    Pil.Visibility = Visibility.Hidden;
                    YearFlight.Text = DateTime.Now.Year.ToString();
                    MonthFlight.Text = DateTime.Now.Month.ToString();
                    DayFlight.Text = DateTime.Now.Day.ToString();
                    Duration.Text = 2.ToString();
                    myStackPanel = new StackPanel();
                    myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    myStackPanel.VerticalAlignment = VerticalAlignment.Top;
                    foreach (AirPlaneTypes a in airPort.AirPlaneTypes.ToList())
                    {
                        RadioButton r = new RadioButton();
                        r.GroupName = "Types";
                        TextBlock text = new TextBlock();
                        text.Background = brush;text.Text = a.Types;
                        r.Content = text;
                        
                        myStackPanel.Children.Add(r);
                    }
                    airplaneType.Content = myStackPanel;
                    myStackPanel = new StackPanel();
                    myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    myStackPanel.VerticalAlignment = VerticalAlignment.Top;
                    foreach (AirPort a in airPort.AirPort.ToList())
                    {
                        RadioButton r = new RadioButton();
                        r.GroupName = "AirPorts";
                        TextBlock text = new TextBlock();
                        text.Background = brush;
                        text.Text = a.Name;
                        r.Content = text;
                        myStackPanel.Children.Add(r);
                    }
                    airplaneLocation.Content = myStackPanel;
                    
                    ListAirPlanesA.ItemsSource = airPort.AirPlanes.ToList();
                    break;

            }
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            Pilots p = airPort.Pilots.Find(Id);
            p.Name = Name.Text;
            p.Middle_Name = MiddleName.Text;
            p.Surname = Surname.Text;
            p.Adress = Adress.Text;
            p.Phone_Number = PhoneNumber.Text;
            airPort.SaveChanges();
        }

        private void EditInfos_Butt(object sender, RoutedEventArgs e)
        {
            InfosAboutMe.Visibility = Visibility.Visible;
            InfosAirplanes.Visibility = Visibility.Hidden;
            InfosAirPorts.Visibility = Visibility.Hidden;
            InfosFlights.Visibility = Visibility.Hidden;
        }

        private void AirPorts_Butt(object sender, RoutedEventArgs e)
        {
            InfosAirPorts.Visibility = Visibility.Visible;
            InfosAboutMe.Visibility = Visibility.Hidden;
            InfosAirplanes.Visibility = Visibility.Hidden;
            InfosFlights.Visibility = Visibility.Hidden;
            List<AirPort> airPorts = airPort.AirPort.ToList();
            ListAirPorts.ItemsSource = airPorts;
        }

        private void Flights_Butt(object sender, RoutedEventArgs e)
        {
            InfosFlights.Visibility = Visibility.Visible;
            InfosAboutMe.Visibility = Visibility.Hidden;
            InfosAirplanes.Visibility = Visibility.Hidden;
            InfosAirPorts.Visibility = Visibility.Hidden;
            List<Flights> flights = airPort.Flights.ToList();
            ListFlights.ItemsSource = flights;
        }
       private void Airplanes_Butt(object sender, RoutedEventArgs e)
        {
            InfosAirplanes.Visibility = Visibility.Visible;
            InfosAboutMe.Visibility = Visibility.Hidden;
            InfosAirPorts.Visibility = Visibility.Hidden;
            InfosFlights.Visibility = Visibility.Hidden;
            List<AirPlanes> airPlanes = airPort.AirPlanes.ToList();
            ListAirplanes.ItemsSource = airPlanes;

             
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListTicketsBuy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = e.Source.ToString();
            
            F = (Flights)ListTicketsBuy.SelectedItem;
            FlightNumBuy.Text = F.Flight_Num.ToString();
            FlightDateBuy.Text = F.Filight_Date.ToString();
            ToBuy.Text = F.Destination;
            FromBuy.Text = F.Point_Of_Departure;
            //ListTicketsBuy.Items[e.AddedItems]
        }

        private void Buy(object sender, RoutedEventArgs e)
        {
            Tickets_Sold t = new Tickets_Sold();
            foreach(Passengers p in airPort.Passengers.ToList())
            {
                if(Sires == p.Passport_Series&& Number == p.Passport_Number)
                {
                    t.Passengers = p;
                }
            }
            
            t.Flights = airPort.Flights.Find(F.Flight_Num,F.Filight_Date);t.Ticket_Num = 0;t.Flight_Num = F.Flight_Num;
            t.AirPlane_Num = F.AirPlane_Num; List<Seets_On_The_Plane> TF = new List<Seets_On_The_Plane>();
            foreach (Tickets_Sold ts in airPort.Tickets_Sold)
            {
                if ((ts.AirPlane_Num == t.AirPlane_Num) && (ts.Flight_Num == t.Flight_Num))
                {
                    TF.Add(ts.Seets_On_The_Plane);
                }
            }
            foreach (Seets_On_The_Plane s  in airPort.Seets_On_The_Plane.ToList())
            {
                if (s.AirPlane_Num == t.AirPlane_Num)
                {
                    if (!TF.Contains(s))
                    {
                        t.Seets_On_The_Plane = s;
                        break;
                    }
                }
                
            }
            if (t.Seets_On_The_Plane == null)
            {
                MessageBox.Show("No tickets available");
            }
            else
            {
                foreach (Tickets_Sold ts in airPort.Tickets_Sold)
                {
                    if (ts.Ticket_Num > t.Ticket_Num) t.Ticket_Num = ts.Ticket_Num + 1;
                    if (ts.Ticket_Num == t.Ticket_Num) t.Ticket_Num += 1;
                }
                airPort.Tickets_Sold.Add(t);
                airPort.SaveChanges();
            }
        }

        private void Add_Airplane(object sender, RoutedEventArgs e)
        {
            string type = null,location;AirPort a1 = null;
            StackPanel sp = (StackPanel)airplaneType.Content;
            foreach (RadioButton r in sp.Children)
            {
                if(r.Content is TextBlock t)
                if (r.IsChecked.Value)
                {
                    type = t.Text;
                }
            }
             sp = (StackPanel)airplaneLocation.Content;
            foreach (RadioButton r in sp.Children)
            {
                if (r.IsChecked.Value)
                {
                    if (r.Content is TextBlock t)
                    {
                        location = t.Text;
                        foreach (AirPort a in airPort.AirPort.ToList())
                        {
                            if (a.Name == location)
                            {
                                a1 = a;
                            }
                        }
                    }
                }
            }
            int id = 0;
            foreach(AirPlanes a in airPort.AirPlanes.ToList())
            {
                if (id < a.AirPlane_Num) id = a.AirPlane_Num;
            }
            AirPlanes pp = new AirPlanes
            {
                AirPlane_Num = id + 1,
                Name = NamePlane.Text,
                AirPort = a1,
                Count_Chairs = 0,
                Location = a1.City + " " + a1.Adress,
                AirPlaneTypes = airPort.AirPlaneTypes.Find(type),
                
            };
            airPort.AirPlanes.Add(pp);

                for(int i = 0;i < pp.AirPlaneTypes.All_Rows; i++)
                {
                    if(i < pp.AirPlaneTypes.Bussnes_Rows)
                    {
                        for(int j = 1; j < 5; j++)
                        {
                            airPort.Seets_On_The_Plane.Add(new Seets_On_The_Plane
                            {
                                AirPlane_Num = id + 1,
                                Row_Num = i,
                                Place_Num = j
                            });
                        }
     
                    }else
                    {
                        for (int j = 1; j < 7; j++)
                        {
                            airPort.Seets_On_The_Plane.Add(new Seets_On_The_Plane
                            {
                                AirPlane_Num = id + 1,
                                Row_Num = i,
                                Place_Num = j
                            });
                        }

                    }
                }

            
            airPort.SaveChanges();
            ListAirPlanesA.ItemsSource = airPort.AirPlanes.ToList();
        }

        private void AddAirportClick(object sender, RoutedEventArgs e)
        {
            airplaneType.Content = null;
            airplaneLocation.Content = null;
            ChoiceAirPlane.Content = null;
            ChoiceAirPortTo.Content = null;
            ChoicePilot.Content = null;
            AddAirplaneMenu.Visibility = Visibility.Hidden;
            AddAirPlane.Visibility = Visibility.Visible;
            AddFlight.Visibility = Visibility.Hidden;
            ProfileAdmin.Visibility = Visibility.Hidden;
        }

        private void AddAirport(object sender, RoutedEventArgs e)
        {
            AirPort a = new AirPort();
            a.Adress = AirPortAdressA.Text;
            a.City = AirPortCityA.Text;
            a.Name = AirPortNameA.Text;
            a.Runway = Convert.ToInt32(AirportRunwayA.Text);
            a.AirPort_Num = 0;
            foreach (AirPort p in airPort.AirPort)
            {
                if (a.AirPort_Num == p.AirPort_Num)a.AirPort_Num += 1;
                if (a.AirPort_Num < p.AirPort_Num) a.AirPort_Num = p.AirPort_Num + 1;
            }
            airPort.AirPort.Add(a);
            airPort.SaveChanges();

        }

        private void AddAirType(object sender, RoutedEventArgs e)
        {

            airPort.AirPlaneTypes.Add(new AirPlaneTypes
            {
                All_Rows = Convert.ToInt32(AllRows.Text),
                Bussnes_Rows = Convert.ToInt32(Busnessrows.Text),
                Types = TypeName.Text
            });airPort.SaveChanges();
            airplaneType.Content = null;
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;
            foreach (AirPlaneTypes a in airPort.AirPlaneTypes.ToList())
            {
                RadioButton r = new RadioButton();
                r.GroupName = "Types";
                r.Content = a.Types;
                myStackPanel.Children.Add(r);
            }
            airplaneType.Content = myStackPanel;
        }

        private void ViewAirplane(object sender, RoutedEventArgs e)
        {
            airplaneType.Content = null;
            airplaneLocation.Content = null;
            ChoiceAirPlane.Content = null;
            ChoiceAirPortTo.Content = null;
            ChoicePilot.Content = null;
            AddAirplaneMenu.Visibility = Visibility.Visible;
            AddAirPlane.Visibility = Visibility.Hidden;
            AddFlight.Visibility = Visibility.Hidden;
            ProfileAdmin.Visibility = Visibility.Hidden;
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;
            foreach (AirPlaneTypes a in airPort.AirPlaneTypes.ToList())
            {
                RadioButton r = new RadioButton();
                r.GroupName = "Types";
                TextBlock text = new TextBlock();
                text.Background = brush; text.Text = a.Types;
                r.Content = text;
                myStackPanel.Children.Add(r);
            }
            airplaneType.Content = myStackPanel;
            myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;
            foreach (AirPort a in airPort.AirPort.ToList())
            {
                RadioButton r = new RadioButton();
                r.GroupName = "AirPorts";
                TextBlock text = new TextBlock();
                text.Background = brush;
                text.Text = a.Name;
                r.Content = text;
                myStackPanel.Children.Add(r);
            }
            airplaneLocation.Content = myStackPanel;
            ListAirPlanesA.ItemsSource = airPort.AirPlanes.ToList();
        }
        private void CheckAirplane(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton r)
            {
                if (r.Content is TextBlock t)
                    AirplaneLabel.Content = t.Text;
                foreach (AirPlanes a in airPort.AirPlanes.ToList())
                {
                    if (a.Name == (string)AirplaneLabel.Content)
                    {
                        FromLabel.Content = a.AirPort.Name;
                    }
                }
            }
        }
        private void CheckTo(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton r)
            {
                if (r.Content is TextBlock t)
                    ToLabel.Content = t.Text;
             
            }
        }
        private void CheckPilot(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton r)
            {
                if (r.Content is TextBlock t)
                    PilotName.Content = t.Text;
            }
        }
        private void CheckTOS(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton r)
            {
                if (r.Content is TextBlock t)
                    ToS.Content = t.Text;
            }
        }
        private void CheckFROMS(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton r)
            {
                if (r.Content is TextBlock t)
                    FromS.Content = t.Text;
            }
        }
        private void FlightADD(object sender, RoutedEventArgs e)
        {
            airplaneType.Content = null;
            airplaneLocation.Content = null;
            ChoiceAirPlane.Content = null;
            ChoiceAirPortTo.Content = null;
            ChoicePilot.Content = null;
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;
            foreach (AirPort a in airPort.AirPort.ToList())
            {
                RadioButton r = new RadioButton();
                r.GroupName = "AirPorts";
                TextBlock text = new TextBlock();
                text.Background = brush;
                text.Text = a.Name;
                r.Content = text;
                r.Checked += CheckTo;
                myStackPanel.Children.Add(r);
            }
            ChoiceAirPortTo.Content = myStackPanel;
             myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;
            foreach (Pilots p in airPort.Pilots.ToList())
            {
                RadioButton r = new RadioButton();
                r.GroupName = "Pilots";
                TextBlock text = new TextBlock();
                text.Background = brush;
                text.Text = p.Surname;
                r.Content = text;
                r.Checked += CheckPilot;
                myStackPanel.Children.Add(r);
            }
            ChoicePilot.Content = myStackPanel;
             myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;
            foreach (AirPlanes p in airPort.AirPlanes.ToList())
            {
                RadioButton r = new RadioButton();
                r.GroupName = "AirPlanes";
                TextBlock text = new TextBlock();
                text.Background = brush;
                text.Text = p.Name;
                r.Content = text;
                r.Checked += CheckAirplane;
                myStackPanel.Children.Add(r);
            }
            ChoiceAirPlane.Content = myStackPanel;
            AddAirplaneMenu.Visibility = Visibility.Hidden;
            AddAirPlane.Visibility = Visibility.Hidden;
            AddFlight.Visibility = Visibility.Visible;
            ProfileAdmin.Visibility = Visibility.Hidden;
        }

        private void AddbuttonFlight(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = new DateTime(Convert.ToInt32(YearFlight.Text), Convert.ToInt32(MonthFlight.Text), Convert.ToInt32(DayFlight.Text));
            Flights f = new Flights
            {
                Point_Of_Departure = (string)FromLabel.Content,
                Filight_Date = dateTime,
                Destination = (string)ToLabel.Content,
                Flight_Num = 0
                
            };
            foreach(Flights f1 in airPort.Flights.ToList())
            {
                if (f1.Flight_Num == f.Flight_Num) f.Flight_Num += 1;
                if (f1.Flight_Num > f.Flight_Num) f.Flight_Num = f1.Flight_Num + 1;
            }
            foreach(AirPort a in airPort.AirPort.ToList())
            {
                if (a.Name == (string)FromLabel.Content) f.AirPortFrom_Num = a.AirPort_Num;
                if (a.Name == (string)ToLabel.Content) f.AirPortTO_Num = a.AirPort_Num;
            }
            foreach (AirPlanes a in airPort.AirPlanes.ToList())
            {
                if (a.Name == (string)AirplaneLabel.Content) f.AirPlanes = a;
            }
            foreach (Pilots a in airPort.Pilots.ToList())
            {
                if (a.Name == (string)PilotName.Content) f.Pilots = a;
            }
            TimeSpan time = new TimeSpan(Convert.ToInt32(Duration.Text), 0, 0);
            f.Duration = time;
            airPort.Flights.Add(f);
            airPort.SaveChanges();
        }

        private void BuyTicktButton(object sender, RoutedEventArgs e)
        {
            Ticketbuy.Visibility = Visibility.Visible;
            InfoAboutMe.Visibility = Visibility.Hidden;
            ShowMyTickets.Visibility = Visibility.Hidden;
            Flights.Visibility = Visibility.Hidden;
        }

        private void Find_Fight(object sender, RoutedEventArgs e)
        {
            List<Flights> fl = airPort.Flights.ToList();
            List<Flights> fs = new List<Flights>();
            DateTime dt = new DateTime(Convert.ToInt32(YearFlightS.Text), Convert.ToInt32(MonthFlightS.Text), Convert.ToInt32(DayFlightS.Text));
            int Idto = -1, IdFrom = -1;


            foreach (AirPort a in airPort.AirPort)
            {
                if (ToS.Content == a.Name) Idto = a.AirPort_Num;
                if (FromS.Content == a.Name) IdFrom = a.AirPort_Num;
            }
            foreach (Flights f1 in airPort.Flights.ToList())
            {
                if(f1.Filight_Date == dt && f1.AirPortFrom_Num == IdFrom && f1.AirPortTO_Num == Idto)
                {
                    fs.Add(f1);
                }
            }


            ListTicketsBuy.ItemsSource = fs;
        }

        private void ViewProfileAdmin(object sender, RoutedEventArgs e)
        {
            ProfileAdmin.Visibility = Visibility.Visible;
            AddAirplaneMenu.Visibility = Visibility.Hidden;
            AddAirPlane.Visibility = Visibility.Hidden;
            AddFlight.Visibility = Visibility.Hidden;
        }

        private void LeaveAccount(object sender, RoutedEventArgs e)
        {
            Role = -1;
            Interface.Sires = -1;
            Interface.username = "";
            Interface.password = "";
            Interface.Number = -1;
            Interface.Id = -1;
            MainFrame.Navigate(new Greetings());
        }

        private void CreateAnAccountAdmin(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Auth("Admin"));
        }
        public class TicketInfo
        {
            public int Flight_Num { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public DateTime Flight_Date { get; set; }
            public int Place_Num { get; set; }
            public int Row_Num { get; set; }
        }
        List<TicketInfo> TIkk;
        private void ShowTickets(object sender, RoutedEventArgs e)
        {
            InfoAboutMe.Visibility = Visibility.Hidden;
            ShowMyTickets.Visibility = Visibility.Visible;
            Flights.Visibility = Visibility.Hidden;
            Ticketbuy.Visibility = Visibility.Hidden;
            List<TicketInfo> Mytickets = new List<TicketInfo>();
            foreach (Tickets_Sold ts in airPort.Tickets_Sold)
            {
                if(Interface.Number == ts.Passport_Num && Interface.Sires == ts.Passport_Series)
                {
                    TicketInfo t = new TicketInfo();
                    t.Flight_Num = ts.Flight_Num;
                    t.Flight_Date = ts.Flight_Date;
                    t.From = airPort.AirPort.Find(ts.Flights.AirPortFrom_Num).City;
                    t.To = airPort.AirPort.Find(ts.Flights.AirPortTO_Num).City;
                    t.Row_Num = ts.Row_Num;
                    t.Place_Num = ts.Place_Num;
                    Mytickets.Add(t);
                }
            }
            Tickets.ItemsSource = Mytickets;
            TIkk = Mytickets;
        }

        private void ProfilePassShow(object sender, RoutedEventArgs e)
        {
            InfoAboutMe.Visibility = Visibility.Visible;
            ShowMyTickets.Visibility = Visibility.Hidden;
            Flights.Visibility = Visibility.Hidden;
            Ticketbuy.Visibility = Visibility.Hidden;
        }

        private void FlightsShowPas(object sender, RoutedEventArgs e)
        {
            InfoAboutMe.Visibility = Visibility.Hidden;
            ShowMyTickets.Visibility = Visibility.Hidden;
            Flights.Visibility = Visibility.Visible;
            Ticketbuy.Visibility = Visibility.Hidden;
        }

        private void PrintAll(object sender, RoutedEventArgs e)
        {
            Passengers p = airPort.Passengers.Find(Interface.Number,Interface.Sires);
            StreamWriter sw = new StreamWriter("Out.txt");
            sw.WriteLine("Ticket IcarAirlines");
            sw.WriteLine("Name: " + p.Name + " Sername: " + p.Surname + " Middle name: " + p.Middle_Name + " Passport number: " + p.Passport_Number + " Passport sires: " + p.Passport_Series);
            sw.WriteLine("_________________________________________________________");
            foreach (TicketInfo t in TIkk)
            {
                sw.WriteLine("Flight num: " + t.Flight_Num + " Flight date: " + t.Flight_Date + " From: " + t.From + " To: " + t.To + " Row: " + t.Row_Num + " Place: "+ t.Place_Num);
                

            }
            sw.WriteLine("_______________________________");
            sw.WriteLine("Thank you for using our company!");
            sw.Close();
        }
    }
}
