using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PZ_Project.MenuItems;

namespace PZ_Project
{
    internal class OrderingScreen
    {
        private static int category = 0;
        private static int item = 0;
        private static List<MenuItem> currentCategoryItems;
        private static List<MenuItem> order = new List<MenuItem>();

        public static void DisplayOrderingScreen()
        {
            LoadCategoryItems();
            bool ordering = true;

            while (ordering)
            {
                Console.Clear();
                Console.WriteLine("=== Ekran Składania Zamówienia ===");
                DisplayCategories();
                Console.WriteLine("\nWybierz produkt za pomocą strzałek i dodaj go do zamówienia za pomocą Enter.");
                Console.WriteLine("Jeżeli skończysz składanie zamówienia naciśnij Escape");

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        item = (item > 0) ? item - 1 : currentCategoryItems.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        item = (item < currentCategoryItems.Count - 1) ? item + 1 : 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        category = (category > 0) ? category - 1 : 2;
                        LoadCategoryItems();
                        item = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        category = (category < 2) ? category + 1 : 0;
                        LoadCategoryItems();
                        item = 0;
                        break;
                    case ConsoleKey.Enter:
                        AddItemToOrder(currentCategoryItems[item]);
                        Console.WriteLine($"\nDodano {currentCategoryItems[item].Name} do zamówienia.");
                        Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        ordering = false;
                        break;
                }
            }

            DisplayOrderSummary();
        }

        private static void DisplayCategories()
        {
            string[] categories = { "Burgery", "Napoje", "Frytki" };
            Console.WriteLine("Kategorie: ");

            for (int i = 0; i < categories.Length; i++)
            {
                if (i == category)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"> {categories[i]} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"  {categories[i]} ");
                }
            }

            Console.WriteLine("\n\nProdukty:");

            for (int i = 0; i < currentCategoryItems.Count; i++)
            {
                if (i == item)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"> {currentCategoryItems[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {currentCategoryItems[i]}");
                }
            }
        }

        private static void LoadCategoryItems()
        {
            switch (category)
            {
                case 0:
                    currentCategoryItems = Menu.Burgers;
                    break;
                case 1:
                    currentCategoryItems = Menu.Drinks;
                    break;
                case 2:
                    currentCategoryItems = Menu.Fries;
                    break;
            }
        }

        private static void AddItemToOrder(MenuItem item)
        {
            order.Add(item);
        }

        private static void DisplayOrderSummary()
        {
            Console.Clear();
            Console.WriteLine("=== Podsumowanie Zamówienia ===");
            decimal total = 0;

            foreach (var item in order)
            {
                Console.WriteLine(item);
                total += item.Price;
            }

            Console.WriteLine($"\nŁączna kwota: {total:C}");
            Console.WriteLine("\nCzy chcesz przejść do ekranu płatności? (Tak/Nie)");

            bool validChoice = false;

            while (!validChoice)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.T)
                {
                    validChoice = true;
                    DisplayPaymentScreen();
                }
                else if (key == ConsoleKey.N)
                {
                    validChoice = true;
                    Console.WriteLine("\nKontynuowanie składania zamówienia...");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                    Console.ReadKey();
                    DisplayOrderingScreen();
                }
                else
                {
                    Console.WriteLine("\nNieprawidłowy wybór. Wybierz 'T' dla Tak lub 'N' dla Nie.");
                }
            }
        }

        private static void DisplayPaymentScreen()
        {
            Console.Clear();
            Console.WriteLine("=== Ekran Płatności ===");
            Console.WriteLine("Dziękujemy za złożenie zamówienia! Przejdź do kasy, aby sfinalizować płatność.");
            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
