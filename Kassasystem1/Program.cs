using System;
using System.Collections.Generic;

class Program
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice => Price * Quantity;
    }

    static void Main(string[] args)
    {
        List<Product> cart = new List<Product>();
        bool running = true;

        Console.WriteLine("Välkommen till Kassasystemet!");

        while (running)
        {
            Console.WriteLine("\nVälj ett alternativ:");
            Console.WriteLine("1. Lägg till produkt");
            Console.WriteLine("2. Visa kvitto");
            Console.WriteLine("3. Avsluta");
            Console.Write("Ditt val: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(cart);
                    break;

                case "2":
                    PrintReceipt(cart);
                    break;

                case "3":
                    running = false;
                    Console.WriteLine("Tack för att du använde Kassasystemet!");
                    break;

                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    static void AddProduct(List<Product> cart)
    {
        Console.Write("Ange produktens namn: ");
        string name = Console.ReadLine();

        Console.Write("Ange produktens pris: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Ogiltigt pris, försök igen.");
            return;
        }

        Console.Write("Ange kvantitet: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Ogiltig kvantitet, försök igen.");
            return;
        }

        cart.Add(new Product { Name = name, Price = price, Quantity = quantity });
        Console.WriteLine($"Produkten {name} har lagts till.");
    }

    static void PrintReceipt(List<Product> cart)
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Kundvagnen är tom.");
            return;
        }

        Console.WriteLine("\n--- KVITTO ---");
        decimal total = 0;

        foreach (var product in cart)
        {
            Console.WriteLine($"{product.Name} - {product.Quantity} x {product.Price:C} = {product.TotalPrice:C}");
            total += product.TotalPrice;
        }

        Console.WriteLine("----------------");
        Console.WriteLine($"Totalt: {total:C}");
        Console.WriteLine("Tack för ditt köp!");
    }
}
