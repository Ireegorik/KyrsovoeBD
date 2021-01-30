using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hotel
{
    static class Holder
    {
        public static Frame MainFrame;
        public static HotelBDEntities bd = new HotelBDEntities();
        public static Users user;
       
    }
}
