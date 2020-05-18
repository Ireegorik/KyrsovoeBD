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
namespace Airs.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для MainMenuAdmin.xaml
    /// </summary>
    public partial class MainMenuAdmin : Page
    {
        public MainMenuAdmin()
        {
            InitializeComponent();
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
        private void Confirm_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
