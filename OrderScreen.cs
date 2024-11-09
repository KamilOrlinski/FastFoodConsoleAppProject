using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_Project
{
    internal class OrderScreen
    {
        public static void PlaceAnOrder()
        {
            Console.WriteLine("Złóż zamówienie: ");
            OrderingScreen.DisplayOrderingScreen();
        }

        public static void BrowseOrders()
        {
            Console.WriteLine("Wyświetlanie zamówień: ");
            Thread.Sleep(1000);
        }
    }
}
