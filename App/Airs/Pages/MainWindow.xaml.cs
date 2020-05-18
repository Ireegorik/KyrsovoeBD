using Airs.Pages;
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


namespace Airs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            /*
            airPort.Tickets_Sold.RemoveRange(airPort.Tickets_Sold.ToList());
            airPort.Seets_On_The_Plane.RemoveRange(airPort.Seets_On_The_Plane.ToList());
            airPort.AirPlanes.RemoveRange(airPort.AirPlanes.ToList());
            airPort.AirPlaneTypes.RemoveRange(airPort.AirPlaneTypes.ToList());
            airPort.Passengers.RemoveRange(airPort.Passengers.ToList());
            airPort.Flights.RemoveRange(airPort.Flights.ToList());
            airPort.AirPort.RemoveRange(airPort.AirPort.ToList());
            airPort.Pilots.RemoveRange(airPort.Pilots.ToList());
            airPort.Login_Password.RemoveRange(airPort.Login_Password.ToList()); airPort.SaveChanges();
            */

            InitializeComponent();
            MainFrame = BaseFrame;
            MainFrame.Navigate(  new Greetings());
        }
    }
}