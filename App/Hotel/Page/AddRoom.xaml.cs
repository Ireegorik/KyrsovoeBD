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
    /// Логика взаимодействия для AddRoom.xaml
    /// </summary>
    public partial class AddRoom : System.Windows.Controls.Page
    {
        public AddRoom()
        {
            InitializeComponent();
            DataRoom.ItemsSource = bd.Rooms.ToList();
        }
        private void RoomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Zas.IsEnabled = true;
        }

        private void Addrooms(object sender, RoutedEventArgs e)
        {
            if (bd.Rooms.Count() > 0)
            {
                int id = bd.Rooms.ToList()[bd.Rooms.Count() - 1].Room_Id + 1;
                bd.Rooms.Add(new Rooms { Room_Num = NumR.Text, Status = "свободна", Room_Id =  id});
            }
            else
                bd.Rooms.Add(new Rooms { Room_Num = NumR.Text, Status = "свободна", Room_Id = 0 });
            bd.SaveChanges();
            DataRoom.ItemsSource = bd.Rooms.ToList();
        }

        private void Visel(object sender, RoutedEventArgs e)
        {
            if(DataRoom.SelectedItem != null)
            {
                bd.Rooms.Find((Rooms)DataRoom.SelectedItem).Status = "свободна";
            }
        }
    }
}
