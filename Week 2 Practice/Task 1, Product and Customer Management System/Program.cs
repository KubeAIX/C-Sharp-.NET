using System;
using System.Collections.Generic;

class Program
{
    // make a list of Products
    static List<string> products = new List<string>();

    //make a dictionary for customers because in which each key must be unique and Customer has always unique Key
    // key = Coustomer ID
    //Value = Customer Name

                      //key   Value
    static Dictionary<int, string> customers = new Dictionary<int, string>();

    // HashSet for Product Categories
    static HashSet<string> categories = new HashSet<string>();


    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n Product and and customer Management System ");
            Console.WriteLine("1. Product management crud");
            Console.WriteLine("2. Customer management crud");
            Console.WriteLine("3. Category management crud");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter Choice: ");
            // iff user enter string (TXT) than it convert it into Integer Like 1. OR One 
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ProductMenu();
                    break;

                case 2:
                    CustomerMenu();
                    break;

                case 3:
                    CategoryMenu();
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }

    // make product list here CRUD Operations
    static void ProductMenu()
    {
        Console.WriteLine("\n Product Menu");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Display Products");
        Console.WriteLine("3. Update Product");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("5. Search Product");

        Console.Write("Choice: ");
        //
        // ch = Convert.ToInt32(Console.ReadLine());
        int ch = int.Parse(Console.ReadLine());
        switch (ch)
        {
            case 1:
                Console.Write("Enter Product Name: ");
                products.Add(Console.ReadLine());
                Console.WriteLine("Product Added.");
                break;

            case 2:
                Console.WriteLine("\nProducts:");

                if (products.Count == 0)
                {
                    Console.WriteLine("No Products.");
                }
                else
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine($"{i}. {products[i]}");
                    }
                }
                break;

            case 3:
                Console.Write("Enter Index to Update: ");
                // int updateIndex = Convert.ToInt32(Console.ReadLine());
                int updateIndex = int.Parse(Console.ReadLine());
                if (updateIndex>=0&&updateIndex<products.Count)
                {
                    Console.Write("New Product Name: ");
                    products[updateIndex] = Console.ReadLine();
                    Console.WriteLine("Updated Successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }

                break;

            case 4:
                Console.Write("Enter Product Name to Delete: ");
                string deleteProduct = Console.ReadLine();

                if (products.Remove(deleteProduct))
                    Console.WriteLine("Deleted Successfully.");
                else
                    Console.WriteLine("Product Not Found.");

                break;

            case 5:
                Console.Write("Enter Product Name to Search: ");
                string search = Console.ReadLine();

                if (products.Contains(search))
                    Console.WriteLine("Product Found.");
                else
                    Console.WriteLine("Product Not Found.");

                break;

            default:
                Console.WriteLine("Invalid Choice.");
                break;
        }
    }
    //Customer Crud Operation
    static void CustomerMenu()
    {
        Console.WriteLine("\nCustomer Menu");
        Console.WriteLine("1. Add Customer");
        Console.WriteLine("2. Display Customers");
          Console.WriteLine("3. Update Customer");
          Console.WriteLine("4. Delete Customer");
          Console.WriteLine("5. Search Customer");
          Console.Write("Choice: ");
        //int ch = Convert.ToInt32(Console.ReadLine());
        int ch = int.Parse(Console.ReadLine());
        switch (ch)
        {
            case 1:

                Console.Write("Enter Customer ID: ");
                //  int id = Convert.ToInt32(Console.ReadLine());
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();

                if (!customers.ContainsKey(id))
                {
                    customers.Add(id, name);
                    Console.WriteLine("Customer Added.");
                }
                   else
                {
                    Console.WriteLine("ID Already Exists.");
                }

                   break;

                  case 2:

                   Console.WriteLine("\nCustomers:");

                      if (customers.Count == 0)
                       {
                            Console.WriteLine("No Customers.");
                        }
                   else
                   {
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"ID : {customer.Key}  Name : {customer.Value}");
                    }
                }

                break;

            case 3:

                Console.Write("Enter Customer ID: ");
                //int updateId = Convert.ToInt32(Console.ReadLine());
                int updateId = int.Parse(Console.ReadLine());
                if (customers.ContainsKey(updateId))
                {
                    Console.Write("Enter New Name: ");
                    customers[updateId] = Console.ReadLine();
                    Console.WriteLine("Updated Successfully.");
                }
                else
                {
                    Console.WriteLine("Customer Not Found.");
                }

                break;

                    case 4:

                    Console.Write("Enter Customer ID: ");
                // int deleteId = Convert.ToInt32(Console.ReadLine());
                int deleteId = int.Parse(Console.ReadLine());
                if (customers.Remove(deleteId))
                    Console.WriteLine("Deleted Successfully.");
                    else
                    Console.WriteLine("Customer Not Found.");

                break;

                case 5:

                Console.Write("Enter Customer ID: ");

                //int searchId = Convert.ToInt32(Console.ReadLine()); not working yet resolve this soon
                int searchId = int.Parse(Console.ReadLine());
                if (customers.ContainsKey(searchId))
                    Console.WriteLine("Customer Name : " + customers[searchId]);
                else
                    Console.WriteLine("Customer Not Found.");

                break;

                default:
                Console.WriteLine("Invalid Choice.");
                break;
        }
    }

 
    //Category CRUD Operations in which unique value is required
    static void CategoryMenu()
    {
        Console.WriteLine("\nCategory Menu");
        Console.WriteLine("1. Add Category");
        Console.WriteLine("2. Display Categories");
        Console.WriteLine("3. Delete Category");
        Console.WriteLine("4. Search Category");

        Console.Write("Choice: ");
        int ch = int.Parse(Console.ReadLine());

        switch (ch)
        {
            case 1:

                Console.Write("Enter Category: ");
                string category = Console.ReadLine();

                if (categories.Add(category))
                    Console.WriteLine("Category Added.");
                else
                    Console.WriteLine("Duplicate Not Allowed.");

                break;

            case 2:

                Console.WriteLine("\nCategories:");
                //c is variable store one category at a time.
                foreach (string c in categories)
                {
                    Console.WriteLine(c);
                }

                 break;

                 case 3:

                Console.Write("Enter Category: ");
                string remove = Console.ReadLine();

                if (categories.Remove(remove))
                    Console.WriteLine("Deleted Successfully.");
                else
                    Console.WriteLine("Category Not Found.");

                break;

                case 4:

                Console.Write("Enter Category: ");
                string search = Console.ReadLine();

                if (categories.Contains(search))
                    Console.WriteLine("Category Found.");
                else
                    Console.WriteLine("Category Not Found.");

                break;

                 default:
                Console.WriteLine("Invalid");
                break;
      
        }
    }

   

 }