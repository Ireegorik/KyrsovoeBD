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
    /// Логика взаимодействия для TakeRoom.xaml
    /// </summary>
    public partial class TakeRoom : System.Windows.Controls.Page
    {
        public TakeRoom()
        {
            InitializeComponent();
            Refresh();
        }
        private void RoomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rooms r = (Rooms)RoomList.SelectedItem;
            if(r.Status == "свободна")
            {
                Zas.IsEnabled = true;
            }
            else
            {
                Zas.IsEnabled = false;
            }
            
        }
        void Refresh()
        {
            List<Rooms> rooms = new List<Rooms>();
            foreach (Rooms r in bd.Rooms.ToList())
            {
                if (r.Status == "свободна") rooms.Add(r); else if (r.Holder == user.Login) rooms.Add(r);
            }
            RoomList.ItemsSource = rooms;
        }
        private void Zas_Click(object sender, RoutedEventArgs e)
        {

            Rooms r = (Rooms)RoomList.SelectedItem;

            Rooms d = bd.Rooms.Find(r.Room_Id);
            d.Users = user;
            d.Status = "занята";
            bd.SaveChanges();
            Refresh();
        }
    }
}
