using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Category { get; set; } = "";

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}
class DuplicateProductException : Exception
{
    public DuplicateProductException(string message)
        : base(message)
    {
    }
}

class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message)
        : base(message)
    {
    }
}

class InvalidQuantityException : Exception
{
    public InvalidQuantityException(string message)
        : base(message)
    {
    }
}
interface IInventoryService
{
    void AddProduct(Product product);

    void RemoveProduct(int id);

    Product? FindProduct(int id);

    void DisplayAllProducts();

    void SearchProducts(string keyword);

    void ShowLowStockProducts();

    void ShowProductsByCategory();

    void ShowInventoryStatistics();

    Task SaveInventoryAsync();

    Task LoadInventoryAsync();
}
class InventoryService : IInventoryService
{
    private readonly List<Product> products = new List<Product>();

    private readonly string filePath = "inventory.json";
    public void AddProduct(Product product)
    {
        if (product.Quantity < 0)
        {
            throw new InvalidQuantityException(
                "Quantity cannot be negative.");
        }

        bool exists = products.Any(p => p.Id == product.Id);

        if (exists)
        {
            throw new DuplicateProductException(
                $"Product with ID {product.Id} already exists.");
        }

        products.Add(product);

        Console.WriteLine("Product added successfully.");
    }
    public void RemoveProduct(int id)
    {
        Product? product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            throw new ProductNotFoundException(
                $"Product with ID {id} was not found.");
        }

        products.Remove(product);

        Console.WriteLine("Product removed successfully.");
    }
    public Product? FindProduct(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }
    public void DisplayAllProducts()
    {
        if (!products.Any())
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        var sortedProducts = products
            .OrderBy(p => p.Name)
            .ToList();

        Console.WriteLine("All Products");

        foreach (Product product in sortedProducts)
        {
            Console.WriteLine(
                $"ID: {product.Id} | " +
                $"Name: {product.Name} | " +
                $"Category: {product.Category} | " +
                $"Price: {product.Price:C} | " +
                $"Quantity: {product.Quantity}");
        }
    }
    public void SearchProducts(string keyword)
    {
        var results = products
            .Where(p =>
                p.Name.Contains(keyword,
                    StringComparison.OrdinalIgnoreCase)
                ||
                p.Category.Contains(keyword,
                    StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p.Name)
            .ToList();

        if (!results.Any())
        {
            Console.WriteLine("No products found.");
            return;
        }

        Console.WriteLine("Search results");

        foreach (Product product in results)
        {
            Console.WriteLine(
                $"{product.Id} | " +
                $"{product.Name} | " +
                $"{product.Category} | " +
                $"{product.Price:C} | " +
                $"Qty: {product.Quantity}");
        }
    }



    public void ShowLowStockProducts()
    {
        var lowStockProducts = products
            .Where(p => p.Quantity <= 5)
            .OrderBy(p => p.Quantity)
            .ToList();

        if (!lowStockProducts.Any())
        {
            Console.WriteLine("No LowStock products.");
            return;
        }

        Console.WriteLine("Low Stock");

        foreach (Product product in lowStockProducts)
        {
            Console.WriteLine(
                $"{product.Name} - Quantity: {product.Quantity}");
        }
    }
    public void ShowProductsByCategory()
    {
        var groups = products
            .GroupBy(p => p.Category)
            .OrderBy(g => g.Key);

        Console.WriteLine("ProductsBy Categories");

        foreach (var group in groups)
        {
            Console.WriteLine($"\nCategory: {group.Key}");

            foreach (Product product in group)
            {
                Console.WriteLine(
                    $"  {product.Name} - Qty: {product.Quantity}");
            }
        }
    }
    public void ShowInventoryStatistics()
    {
        int totalProducts = products.Count();

        int totalQuantity = products.Sum(p => p.Quantity);

        decimal totalValue = products.Sum(
            p => p.Price * p.Quantity);

        Console.WriteLine("Inventory stats");

        Console.WriteLine($"Different Products: {totalProducts}");

        Console.WriteLine($"Total Items: {totalQuantity}");

        Console.WriteLine($"Total Inventory Value: {totalValue:C}");
    }
    public async Task SaveInventoryAsync()
    {
        string json = JsonSerializer.Serialize(
            products,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        await File.WriteAllTextAsync(filePath, json);

        Console.WriteLine("Inventory saved successfully.");
    }
    public async Task LoadInventoryAsync()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine(
                "No inventory file found. Starting with empty inventory.");

            return;
        }

        string json = await File.ReadAllTextAsync(filePath);

        List<Product>? loadedProducts =
            JsonSerializer.Deserialize<List<Product>>(json);

        if (loadedProducts != null)
        {
            products.Clear();

            products.AddRange(loadedProducts);
        }

        Console.WriteLine("Inventory loaded successfully.");
    }
}
class Program
{
    static async Task Main(string[] args)
    {
        IInventoryService inventory =
            new InventoryService();
        await inventory.LoadInventoryAsync();


        while (true)
        {
            Console.WriteLine("PRODUCT INVENTORY SYSTEM");
        

            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Find Product");
            Console.WriteLine("4. Display All Products");
            Console.WriteLine("5. Search Products");
            Console.WriteLine("6. Show Low Stock");
            Console.WriteLine("7. Group By Category");
            Console.WriteLine("8. Inventory Statistics");
            Console.WriteLine("9. Save Inventory");
            Console.WriteLine("10. Exit");

            Console.Write("\nEnter choice: ");

            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {

                    case "1":

                        Console.Write("Enter ID: ");

                        if (!int.TryParse(
                                Console.ReadLine(),
                                out int id))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }


                        Console.Write("Enter Name: ");

                        string name =
                            Console.ReadLine() ?? "";


                        Console.Write("Enter Category: ");

                        string category =
                            Console.ReadLine() ?? "";


                        Console.Write("Enter Price: ");

                        if (!decimal.TryParse(
                                Console.ReadLine(),
                                out decimal price))
                        {
                            Console.WriteLine("Invalid price.");
                            break;
                        }


                        Console.Write("Enter Quantity: ");

                        if (!int.TryParse(
                                Console.ReadLine(),
                                out int quantity))
                        {
                            Console.WriteLine("Invalid quantity.");
                            break;
                        }


                        Product product = new Product
                        {
                            Id = id,
                            Name = name,
                            Category = category,
                            Price = price,
                            Quantity = quantity
                        };

                        inventory.AddProduct(product);

                        break;


                    case "2":

                        Console.Write("Enter Product ID: ");

                        if (!int.TryParse(
                                Console.ReadLine(),
                                out int removeId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }

                        inventory.RemoveProduct(removeId);

                        break;


                    case "3":

                        Console.Write("Enter Product ID: ");

                        if (!int.TryParse(
                                Console.ReadLine(),
                                out int findId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }

                        Product? foundProduct =
                            inventory.FindProduct(findId);

                        if (foundProduct == null)
                        {
                            Console.WriteLine("Product not found.");
                        }
                        else
                        {
                            Console.WriteLine(
                                $"ID: {foundProduct.Id}");

                            Console.WriteLine(
                                $"Name: {foundProduct.Name}");

                            Console.WriteLine(
                                $"Category: {foundProduct.Category}");

                            Console.WriteLine(
                                $"Price: {foundProduct.Price:C}");

                            Console.WriteLine(
                                $"Quantity: {foundProduct.Quantity}");
                        }

                        break;

                    case "4":

                        inventory.DisplayAllProducts();

                        break;

                    case "5":

                        Console.Write("Enter search keyword: ");

                        string keyword =
                            Console.ReadLine() ?? "";

                        inventory.SearchProducts(keyword);

                        break;

                    case "6":

                        inventory.ShowLowStockProducts();

                        break;

                    case "7":

                        inventory.ShowProductsByCategory();

                        break;

                    case "8":

                        inventory.ShowInventoryStatistics();

                        break;
                    case "9":

                        await inventory.SaveInventoryAsync();

                        break;

                    case "10":

                        await inventory.SaveInventoryAsync();

                        Console.WriteLine(
                            "Inventory saved. Goodbye!");

                        return;


                    default:

                        Console.WriteLine(
                            "Invalid menu option.");

                        break;
                }
            }

            catch (DuplicateProductException ex)
            {
                Console.WriteLine(
                    $"Duplicate Error: {ex.Message}");
            }

            catch (ProductNotFoundException ex)
            {
                Console.WriteLine(
                    $"Not Found: {ex.Message}");
            }

            catch (InvalidQuantityException ex)
            {
                Console.WriteLine(
                    $"Quantity Error: {ex.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Unexpected Error: {ex.Message}");
            }
        }
    }
}