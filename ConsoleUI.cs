using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_Project
{
    internal class ConsoleUI
    {

        public static string[] menuOptions =
        {
            "--- Witaj w ConsoleFastFood ---",
            "Złóż zamówienie",
            "Przeglądaj zamówienia",
            "Wyjdź",
        };

        public static int select = 1;
        public static bool exit = false;

        public static void MenuUI()
        {

            while (!exit)
            {
                Console.Clear();
                MenuDisplay(menuOptions, select);

                ConsoleKey key = Console.ReadKey(true).Key;

                switch(key)
                {
                    case ConsoleKey.UpArrow:
                        select = (select > 1) ? select - 1 : menuOptions.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        select = (select < menuOptions.Length - 1) ? select + 1 : 1;
                        break;
                    case ConsoleKey.Enter:
                        exit = MenuSelection(select);
                        break;
                }
            }
        }

        static void MenuDisplay(string[] options, int selectedIndex)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($">> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($" {options[i]}");
                }
            }
        }

        static bool MenuSelection(int selected)
        {
            switch (selected)
            {
                case 1:
                    OrderScreen.PlaceAnOrder();
                    break;
                case 2:
                    OrderScreen.BrowseOrders();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór!");
                    break;
            }

            Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować ");
            Console.ReadKey();
            return false;
        }
    }

}
