using System;
using System.Collections.Generic;

namespace Magazyn
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public Product(string name, int quantity, double unitPrice)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public Product() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> inventory = new List<Product>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nWybierz opcję:");
                Console.WriteLine("1. Dodaj produkt");
                Console.WriteLine("2. Usuń produkt");
                Console.WriteLine("3. Wyświetl listę produktów");
                Console.WriteLine("4. Aktualizuj produkt");
                Console.WriteLine("5. Oblicz wartość magazynu");
                Console.WriteLine("6. Wyjście");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddProduct(inventory);
                        break;
                    case "2":
                        RemoveProduct(inventory);
                        break;
                    case "3":
                        DisplayProducts(inventory);
                        break;
                    case "4":
                        UpdateProduct(inventory);
                        break;
                    case "5":
                        CalculateInventoryValue(inventory);
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja!");
                        break;
                }
            }
        }

        static void AddProduct(List<Product> inventory)
        {
            Console.Write("Podaj nazwę produktu: ");
            string name = Console.ReadLine();

            Console.Write("Podaj ilość: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj cenę: ");
            double price = Convert.ToDouble(Console.ReadLine());

            inventory.Add(new Product(name, quantity, price));
            Console.WriteLine("Produkt dodany!");
        }

        static void RemoveProduct(List<Product> inventory)
        {
            Console.Write("Podaj nazwę produktu do usunięcia: ");
            string name = Console.ReadLine();

            Product productToRemove = inventory.Find(p => p.Name == name);
            if (productToRemove != null)
            {
                inventory.Remove(productToRemove);
                Console.WriteLine("Produkt usunięty!");
            }
            else
            {
                Console.WriteLine("Nie znaleziono produktu.");
            }
        }

        static void DisplayProducts(List<Product> inventory)
        {
            Console.WriteLine("\nLista produktów:");
            foreach (var product in inventory)
            {
                Console.WriteLine($"Nazwa: {product.Name}, Ilość: {product.Quantity}, Cena: {product.UnitPrice:C}");
            }
        }

        static void UpdateProduct(List<Product> inventory)
        {
            Console.Write("Podaj nazwę produktu do aktualizacji: ");
            string name = Console.ReadLine();

            Product productToUpdate = inventory.Find(p => p.Name == name);
            if (productToUpdate != null)
            {
                Console.WriteLine("Co chcesz zaktualizować?");
                Console.WriteLine("1. Ilość");
                Console.WriteLine("2. Cenę");
                Console.WriteLine("3. Oba");

                string option = Console.ReadLine();
                if (option == "1" || option == "3")
                {
                    Console.Write("Nowa ilość: ");
                    productToUpdate.Quantity = Convert.ToInt32(Console.ReadLine());
                }
                if (option == "2" || option == "3")
                {
                    Console.Write("Nowa cena: ");
                    productToUpdate.UnitPrice = Convert.ToDouble(Console.ReadLine());
                }

                Console.WriteLine("Produkt zaktualizowany.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono produktu.");
            }
        }

        static void CalculateInventoryValue(List<Product> inventory)
        {
            double totalValue = 0;
            foreach (var product in inventory)
            {
                totalValue += product.Quantity * product.UnitPrice;
            }
            Console.WriteLine($"Całkowita wartość magazynu: {totalValue:C}");
        }
    }
}
