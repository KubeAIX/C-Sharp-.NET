using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

class Program
{
    static void Main()
    {
        //productslist
        List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Category = "Electronics",
                Quantity = 10,
                Price = 120000
            },

            new Product
            {
                Id = 2,
                Name = "Mouse",
                Category = "Electronics",
                Quantity = 25,
                Price = 2500
            },

            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Category = "Electronics",
                Quantity = 15,
                Price = 5000
            },

            new Product
            {
                Id = 4,
                Name = "Office Chair",
                Category = "Furniture",
                Quantity = 8,
                Price = 25000
            },

            new Product
            {
                Id = 5,
                Name = "Office Desk",
                Category = "Furniture",
                Quantity = 5,
                Price = 35000
            },

            new Product
            {
                Id = 6,
                Name = "Monitor",
                Category = "Electronics",
                Quantity = 12,
                Price = 30000
            }
        };

        Console.WriteLine("FilteredReport");

        var filteredProducts = products
            .Where(p => p.Price > 10000);

        foreach (Product product in filteredProducts)
        {
            Console.WriteLine(
                $"{product.Name} - Rs.{product.Price}");
        }

        Console.WriteLine("sortedreport");

        var sortedProducts = products
            .OrderByDescending(p => p.Price);

        foreach (Product product in sortedProducts)
        {
            Console.WriteLine(
                $"{product.Name} - Rs.{product.Price}");
        }

        Console.WriteLine("Group Report");

        var groupedProducts = products
            .GroupBy(p => p.Category);

        foreach (var group in groupedProducts)
        {
            Console.WriteLine($"\nCategory: {group.Key}");

            foreach (Product product in group)
            {
                Console.WriteLine(
                    $"  {product.Name} - Rs.{product.Price}");
            }
        }

        Console.WriteLine("Product Names");

        var productNames = products
            .Select(p => p.Name);

        foreach (string name in productNames)
        {
            Console.WriteLine(name);
        }

        int totalProducts = products.Count();

        Console.WriteLine(
            $"\nTotal Products: {totalProducts}");

        bool lowStockExists =
            products.Any(p => p.Quantity < 10);

        Console.WriteLine(
            $"Low Stock Exists: {lowStockExists}");

        Product foundProduct =
            products.FirstOrDefault(p => p.Id == 3);

        Console.WriteLine("SEARCH RESULT");

        if (foundProduct != null)
        {
            Console.WriteLine(
                $"Found: {foundProduct.Name}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}