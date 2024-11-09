using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_Project
{
    internal class MenuItems
    {
        public abstract class MenuItem
        {
            public string Name { get; }
            public decimal Price { get; }

            protected MenuItem(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public override string ToString()
            {
                return $"{Name} - {Price:C}";
            }
        }

        public class Burger : MenuItem
        {
            public Burger(string name, decimal price) : base(name, price) { }
        }

        public class Drink : MenuItem
        {
            public Drink(string name, decimal price) : base(name, price) { }
        }

        public class Fries : MenuItem
        {
            public Fries(string name, decimal price) : base(name, price) { }
        }

        public static class Menu
        {
            public static List<MenuItem> Burgers = new List<MenuItem>
        {
            new Burger("Burger klasyczny", 12.99m),
            new Burger("Cheeseburger", 14.99m),
            new Burger("Burger bekonowy", 16.99m),
            new Burger("Burger podwójny bez ogórka", 15.99m)
        };

            public static List<MenuItem> Drinks = new List<MenuItem>
        {
            new Drink("Coca-Cola", 5.99m),
            new Drink("Sprite", 5.99m),
            new Drink("Woda", 3.99m)
        };

            public static List<MenuItem> Fries = new List<MenuItem>
        {
            new Fries("Małe Frytki", 4.99m),
            new Fries("Duże Frytki", 6.99m)
        };
        }
    }
}
