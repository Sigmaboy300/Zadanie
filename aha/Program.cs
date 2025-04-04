using System;
using System.Collections.Generic;

namespace Magazyn
{
    class Magazyn
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
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
                Console.Write("Twój wybór: ");

                string optionInput = Console.ReadLine();
                if (!int.TryParse(optionInput, out int option))
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        // Dodaj produkt
                        Console.Write("Podaj nazwę produktu: ");
                        string nazwa = Console.ReadLine();

                        Console.Write("Podaj ilość produktu: ");
                        if (!int.TryParse(Console.ReadLine(), out int ilosc))
                        {
                            Console.WriteLine("Błędna ilość! Operacja przerwana.");
                            break;
                        }

                        Console.Write("Podaj cenę jednostkową produktu: ");
                        if (!double.TryParse(Console.ReadLine(), out double cena))
                        {
                            Console.WriteLine("Błędna cena! Operacja przerwana.");
                            break;
                        }

                        products.Add(new Product(nazwa, ilosc, cena));
                        Console.WriteLine("Produkt został dodany.");
                        break;

                    case 2:
                        // Usuń produkt 
                        Console.Write("Podaj nazwę produktu do usunięcia: ");
                        string nazwaDoUsuniecia = Console.ReadLine();
                        Product productToRemove = products.Find(p =>
                            p.Nazwa.Equals(nazwaDoUsuniecia, StringComparison.OrdinalIgnoreCase));

                        if (productToRemove != null)
                        {
                            products.Remove(productToRemove);
                            Console.WriteLine("Produkt został usunięty.");
                        }
                        else
                        {
                            Console.WriteLine("Produkt o podanej nazwie nie został znaleziony.");
                        }
                        break;

                    case 3:
                        // Wyświetl listę produktów
                        if (products.Count == 0)
                        {
                            Console.WriteLine("Brak produktów w magazynie.");
                        }
                        else
                        {
                            Console.WriteLine("\nLista produktów:");
                            foreach (var product in products)
                            {
                                Console.WriteLine($"Nazwa: {product.Nazwa}, Ilość: {product.ilosc}, Cena: {product.cena}");
                            }
                        }
                        break;

                    case 4:
                        // Aktualizacja produktu
                        Console.Write("Podaj nazwę produktu do aktualizacji: ");
                        string nazwaDoAktualizacji = Console.ReadLine();
                        Product productToUpdate = products.Find(p =>
                            p.Nazwa.Equals(nazwaDoAktualizacji, StringComparison.OrdinalIgnoreCase));

                        if (productToUpdate == null)
                        {
                            Console.WriteLine("Produkt o podanej nazwie nie został znaleziony.");
                        }
                        else
                        {
                            Console.WriteLine("Wybierz dane do aktualizacji:");
                            Console.WriteLine("1. Ilość");
                            Console.WriteLine("2. Cena jednostkowa");
                            Console.WriteLine("3. Oba");
                            Console.Write("Twój wybór: ");
                            string updateOption = Console.ReadLine();

                            switch (updateOption)
                            {
                                case "1":
                                    Console.Write("Podaj nową ilość: ");
                                    if (int.TryParse(Console.ReadLine(), out int nowaIlosc))
                                    {
                                        productToUpdate.ilosc = nowaIlosc;
                                        Console.WriteLine("Ilość została zaktualizowana.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Błędna wartość ilości.");
                                    }
                                    break;

                                case "2":
                                    Console.Write("Podaj nową cenę: ");
                                    if (double.TryParse(Console.ReadLine(), out double nowaCena))
                                    {
                                        productToUpdate.cena = nowaCena;
                                        Console.WriteLine("Cena została zaktualizowana.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Błędna wartość ceny.");
                                    }
                                    break;

                                case "3":
                                    Console.Write("Podaj nową ilość: ");
                                    if (int.TryParse(Console.ReadLine(), out int qty))
                                    {
                                        productToUpdate.ilosc = qty;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Błędna wartość ilości.");
                                        break;
                                    }
                                    Console.Write("Podaj nową cenę: ");
                                    if (double.TryParse(Console.ReadLine(), out double priceValue))
                                    {
                                        productToUpdate.cena = priceValue;
                                        Console.WriteLine("Dane produktu zostały zaktualizowane.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Błędna wartość ceny.");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Nie rozpoznano opcji aktualizacji.");
                                    break;
                            }
                        }
                        break;

                    case 5:
                        // Oblicz wartość magazynu
                        double totalValue = 0.0;
                        foreach (var product in products)
                        {
                            totalValue += product.ilosc * product.cena;
                        }
                        Console.WriteLine($"Całkowita wartość magazynu wynosi: {totalValue}");
                        break;

                    case 6:
                        // Wyjście z programu
                        exit = true;
                        Console.WriteLine("Zakończono program.");
                        break;

                    default:
                        Console.WriteLine("Nie ma takiej opcji. Spróbuj ponownie.");
                        break;
                }
            }
        }
    }
}