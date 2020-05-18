using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Airs
{
    static class Interface
    {
       public static AirPortEntities airPort = new AirPortEntities();
       public static string username;
       public static string password;
       public static Frame MainFrame;
       public static int Role;
       public static int Id;
       public static int Sires, Number;
    }
}
