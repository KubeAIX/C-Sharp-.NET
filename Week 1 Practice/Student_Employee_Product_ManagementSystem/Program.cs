using System;
using System.Collections.Generic;

namespace Student_Employee_Product_ManagementSystem
{
    //sstudent Class
    class Student
    {
        public int Id;
        public string Name;
        public int Age;
        public string Course;
    }

    //emplolyee class
    class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
    }

    //product Class
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int Stock;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Employee> employees = new List<Employee>();
            List<Product> products = new List<Product>();

            int choice;

            do
            {
                Console.WriteLine("\n ===== Student_Employee_Product Management=====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Add Employee");
                Console.WriteLine("4. Display Employees");
                Console.WriteLine("5. Add Product");
                Console.WriteLine("6. Display Products");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Student s = new Student();

                        Console.Write("Enter Student ID: ");
                        s.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Student Name: ");
                        s.Name = Console.ReadLine();

                        Console.Write("Enter Student Age: ");
                        s.Age = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Course: ");
                        s.Course = Console.ReadLine();
                        students.Add(s);

                        Console.WriteLine("Student Added Successfully!");
                        break;

                    case 2:
                        Console.WriteLine("\n=====Students=====");

                        foreach (Student student in students)
                        {
                            Console.WriteLine($"ID: {student.Id}");
                            Console.WriteLine($"Name: {student.Name}");
                            Console.WriteLine($"Age: {student.Age}");
                            Console.WriteLine($"Course: {student.Course}");
                            Console.WriteLine("==========");
                        }
                        break;

                    case 3:
                        Employee e = new Employee();

                        Console.Write("Enter Employee ID: ");
                        e.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Employee Name: ");
                        e.Name = Console.ReadLine();

                        Console.Write("Enter Department: ");
                        e.Department = Console.ReadLine();

                        Console.Write("Enter Salary: ");
                        e.Salary = Convert.ToDouble(Console.ReadLine());

                        employees.Add(e);

                        Console.WriteLine("Employee Added Successfully!");
                        break;

                    case 4:
                        Console.WriteLine("\n=====Employees=====");

                        foreach (Employee employee in employees)
                        {
                            Console.WriteLine($"ID: {employee.Id}");
                            Console.WriteLine($"Name: {employee.Name}");
                            Console.WriteLine($"Department: {employee.Department}");
                            Console.WriteLine($"Salary: {employee.Salary}");
                            Console.WriteLine("==========");
                        }
                        break;

                    case 5:
                        Product p = new Product();

                        Console.Write("Enter Product ID: ");
                        p.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Product Name: ");
                        p.Name = Console.ReadLine();

                        Console.Write("Enter Price: ");
                        p.Price = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Stock: ");
                        p.Stock = Convert.ToInt32(Console.ReadLine());

                        products.Add(p);

                        Console.WriteLine("Product Added Successfully!");
                        break;

                    case 6:
                        Console.WriteLine("\n=====Products=====");

                        foreach (Product product in products)
                        {
                            Console.WriteLine($"ID: {product.Id}");
                            Console.WriteLine($"Name: {product.Name}");
                            Console.WriteLine($"Price: {product.Price}");
                            Console.WriteLine($"Stock: {product.Stock}");
                            Console.WriteLine("==========");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Program Closed.");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            } while (choice != 0);
        }
    }
}