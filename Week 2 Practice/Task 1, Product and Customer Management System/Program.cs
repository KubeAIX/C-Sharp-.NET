using System;
using System.Collections.Generic;
using System.ComponentModel;

class Program
{
    // make a list of Products

    static List<string> products =new List<string>();

    //make a dictionary for customers because in which each key must be unique and Customer has always unique Key
    // key = Coustomer ID
    //Value = Customer Name
                    //key   Value
    static Dictionary<int, string> customers = new Dictionary<int, string>();

    //make for categories of product
    //HashSet has must be Unique Value
    static HashSet<string> categories = new HashSet<string>();

    static void Main()
    {
        Console.WriteLine("\n Product and and customer Management System ");
        Console.WriteLine("1. Product management crud");
        Console.WriteLine("2. Customer management crud");
        Console.WriteLine("3. Category management crud");
        Console.WriteLine("4. Exit");
        Console.WriteLine("Enter Choice: ");
        // iff user enter string (TXT) than it convert it into Integer Like 1. OR One 
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                ProductMenu();
                break;
            case2:
                CustomerMenu();
                break;
            case 3:
                categories();
                break;
            case 4:
                return;

            default:
                Console.WriteLine("Invalid Choice ");



        }

    }

}

// make product list here
// 
static void ProductMenu()
{
 Console.WriteLine("\n Product Menu");
 Console.WriteLine("1. Add Products");
    Console.WriteLine("2. Display Product");
    Console.WriteLine("3. Update Produt");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Search Product");

    Console.Write("choice: ");
    int ch = Convert.ToInt32(Console.ReadLine());

    switch (ch)
    {
        case 1:
            console.WriteLine("Enter Product Name: ");
            ProductMenu().Add(Console.ReadLine());
            Console.WriteLine("Product Added");
            break;

        case 2:
            Console.WriteLine("\n Products: ");

    }


}
