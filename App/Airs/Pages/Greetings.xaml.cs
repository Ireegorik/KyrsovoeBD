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
    /// Логика взаимодействия для Greetings.xaml
    /// </summary>
    public partial class Greetings : Page
    {
        public Greetings()
        {
            InitializeComponent();
        }
        private void Registration(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Auth("User"));
        }
        private void Sighin(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SighIn());
        }
    }
}
