using System;
using System.Collections.Generic;

namespace NDTCore.DesignPattern.Structural.Composite
{
    // Component
    public interface IItem
    {
        string Name { get; }
        double GetPrice();
    }

    // Leaf - Individual Product
    public class Product : IItem
    {
        public string Name { get; }
        private double Price { get; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public double GetPrice()
        {
            return Price;
        }
    }

    // Composite - Box that can contain Products or other Boxes
    public class Box : IItem
    {
        public string Name { get; }
        private readonly List<IItem> items = new List<IItem>();

        public Box(string name)
        {
            Name = name;
        }

        public void AddItem(IItem item)
        {
            items.Add(item);
        }

        public double GetPrice()
        {
            double total = 0;
            foreach (var item in items)
            {
                total += item.GetPrice();
            }
            return total;
        }
    }

    // Client Code
    class Program
    {
        static void Main()
        {
            // Individual products
            Product phone = new Product("Smartphone", 500);
            Product laptop = new Product("Laptop", 1200);
            Product charger = new Product("Charger", 50);

            // Box 1 contains phone and charger
            Box smallBox = new Box("Small Box");
            smallBox.AddItem(phone);
            smallBox.AddItem(charger);

            // Box 2 contains laptop
            Box mediumBox = new Box("Medium Box");
            mediumBox.AddItem(laptop);

            // Main Box contains Box 1 and Box 2
            Box bigBox = new Box("Big Box");
            bigBox.AddItem(smallBox);
            bigBox.AddItem(mediumBox);

            // Display total price of small box
            Console.WriteLine($"Total price of '{smallBox.Name}': ${smallBox.GetPrice()}");

            // Display total price of medium box
            Console.WriteLine($"Total price of '{mediumBox.Name}': ${mediumBox.GetPrice()}");

            // Display total price of big box
            Console.WriteLine($"Total price of '{bigBox.Name}': ${bigBox.GetPrice()}");
        }
    }
}