using System;
using System.Collections.Generic;

//This is Abstract Class 
abstract class Product
{
    public int Id;
    public string Name;

    public Product(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public abstract void Display();
}

//laptop child class of Product 
//laptop has id's and Name like Dell. HP
class Laptop : Product
{
    public Laptop(int id, string name)
        : base(id, name)
    {
    }

    public override void Display()
    {
        Console.WriteLine($"Laptop -> ID: {Id}, Name: {Name}");
    }
}

//interface  INTERFACE OF Product Repository

interface IProductRepository
{
    void Add(Product product);

    void Remove(int id);

    void ShowAll();
}

//product repo class

class ProductRepository : IProductRepository //product interface 
{
    private List<Product> products = new List<Product>();

    public void Add(Product product)
    {
        products.Add(product);
        Console.WriteLine("Product Added.");
    }

    public void Remove(int id)
    {                      //lambda operator
        //Take a product object p, and check whether its Id is equal to the variable 
        //than remove karo is product ko
        products.RemoveAll(p => p.Id == id);
        Console.WriteLine("Product Removed.");
    }

    public void ShowAll()
    {
        Console.WriteLine("\nProduct List");

        foreach (Product product in products)
        {
            product.Display();
        }
    }
}
//mainprogram

class Program
{
    static void Main()
    {
        IProductRepository repo = new ProductRepository();

        repo.Add(new Laptop(1, "Dell XPS"));
        repo.Add(new Laptop(2, "HP EliteBook"));
        repo.Add(new Laptop(3, "Lenovo ThinkPad X 380 Yoga"));

        repo.ShowAll();

        repo.Remove(2);

        repo.ShowAll();

        Console.ReadLine();
    }
}
