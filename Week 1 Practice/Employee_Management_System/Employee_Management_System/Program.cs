using System;

namespace Employee_Management_System
{  //make class employee
    public class Employee
    {
        public int ID;
        public string Name;
        public string Email;
        public int Age;
        public decimal Salary;
        public string Department;
    }

    class Program
    {
        //readonly
        private static readonly Employee[] employees = new Employee[50];
        private static int total = 0;

        static void Main()
        {
            while (true)
            {
                Console.Write("\nTask 1, Employee Management System\n 1. Add \n 2. Display \n 3. Find ID \n 4. Search Name\n 5. Update \n 6. Delete \n 7. Salary Filter \n 8. Exit");
                Console.Write("\nSelect the option: ");
                string choice = Console.ReadLine();

                if (choice == "1") Add();
                else if (choice == "2") Display();
                else if (choice == "3") Find();
                else if (choice == "4") Search();
                else if (choice == "5") Update();
                else if (choice == "6") Delete();
                else if (choice == "7") Filter();
                else if (choice == "8") return;
            }
        }

        static void Add()
        {
            // Add new employee
            Employee e = new();
            Console.Write("Employee ID: "); e.ID = int.Parse(Console.ReadLine());

            for (int i = 0; i < total; i++)
                if (employees[i].ID == e.ID) { Console.WriteLine("ID exists!"); return; }

            Console.Write("Name: "); e.Name = Console.ReadLine();
            Console.Write("Email: "); e.Email = Console.ReadLine();
            Console.Write("Age: "); e.Age = int.Parse(Console.ReadLine());
            Console.Write("Salary: "); e.Salary = decimal.Parse(Console.ReadLine());
            Console.Write("Dept: "); e.Department = Console.ReadLine();

            employees[total] = e;
            total++;
            Console.WriteLine("Saved!");
        }

        static void Display()
        { //Display new
            if (total == 0) Console.WriteLine("Empty database.");
            for (int i = 0; i < total; i++)
                Show(employees[i]);
        }

        static void Find()
        { //find emp
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            for (int i = 0; i < total; i++)
                if (employees[i].ID == id) { Show(employees[i]); return; }
            Console.WriteLine("Not found.");
        }

        static void Search()
        {//search
            Console.Write("Enter Search Text: ");
            string text = Console.ReadLine();

            for (int i = 0; i < total; i++)
            {
                
                if (employees[i].Name != null && employees[i].Name.Contains(text, StringComparison.OrdinalIgnoreCase))
                {
                    Show(employees[i]);
                }
            }
        }

        static void Update()
        { //Update emp
            Console.Write("Enter ID to Update: ");
            int id = int.Parse(Console.ReadLine());
            for (int i = 0; i < total; i++)
            {
                if (employees[i].ID == id)
                {
                    Console.Write("New Name: "); string n = Console.ReadLine(); if (n != "") employees[i].Name = n;
                    Console.Write("New Email: "); string em = Console.ReadLine(); if (em != "") employees[i].Email = em;
                    Console.Write("New Age: "); string a = Console.ReadLine(); if (a != "") employees[i].Age = int.Parse(a);
                    Console.Write("New Salary: "); string s = Console.ReadLine(); if (s != "") employees[i].Salary = decimal.Parse(s);
                    Console.Write("New Dept: "); string d = Console.ReadLine(); if (d != "") employees[i].Department = d;
                    return;
                }
            }
            Console.WriteLine("Not found.");
        }

        static void Delete()
        {//delete

            Console.Write("Enter ID to Delete: ");
            int id = int.Parse(Console.ReadLine());
            for (int i = 0; i < total; i++)
            {
                if (employees[i].ID == id)
                {
                    for (int j = i; j < total - 1; j++) employees[j] = employees[j + 1];
                    employees[total - 1] = null;
                    total--;
                    Console.WriteLine("Deleted!");
                    return;
                }
            }
            Console.WriteLine("Not found.");
        }

        static void Filter()
        { //salary filter
            Console.Write("Min Salary: ");
            decimal min = decimal.Parse(Console.ReadLine());
            for (int i = 0; i < total; i++)
                if (employees[i].Salary > min) Show(employees[i]);
        }

        static void Show(Employee e)
        {
            Console.WriteLine($"[{e.ID}] {e.Name} | {e.Email} | Age: {e.Age} | ${e.Salary} | {e.Department}");
        }
    }
}