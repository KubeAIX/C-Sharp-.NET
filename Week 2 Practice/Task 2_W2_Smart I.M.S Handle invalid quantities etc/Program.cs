using System;
using System.Collections.Generic;

class InvalidQuantityException : Exception
{
    public InvalidQuantityException(string message) : base(message) { } //Constructor
}

class Product
{
    public int Id;
    public string Name;
    public int Quantity;
}

class Program
{
    static List<Product> products = new List<Product>();
     //making list of products
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nInventory System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Quantity");
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddProduct();
                    break;

                case "2":
                    UpdateQuantity();
                    break;

                case "3":
                    ViewProducts();
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void AddProduct()
    {
        try
        {
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());

            // Duplicate Entry
            if (products.Exists(p => p.Id == id))
                throw new Exception("Duplicate Product ID!");

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            // Defensive Validation
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Must enter the product name fill it.");

            Console.Write("Enter Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            // Custom Exception
            if (qty < 0)
                throw new InvalidQuantityException("Quantity cannot be negative.");

            products.Add(new Product
            {
                Id = id,
                Name = name,
                Quantity = qty
            });

            Console.WriteLine("Product Added Successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Only numbers are allowed.");
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Add operation completed.");
        }
    }

    static void UpdateQuantity()
    {
        try
        {
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());

            Product product = products.Find(p => p.Id == id);

            // Missing Record
            if (product == null)
                throw new Exception("Product not found.");

            Console.Write("Enter New Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            if (qty < 0)
                throw new InvalidQuantityException("Quantity cannot be negative.");

            product.Quantity = qty;

            Console.WriteLine("Quantity Updated.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input.");
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ViewProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }

        Console.WriteLine("\nID\tName\tQuantity");

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}\t{p.Name}\t{p.Quantity}");
        }
    }
}