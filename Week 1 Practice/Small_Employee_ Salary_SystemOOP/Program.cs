using System;
using System.Collections.Generic;

// abstract class is a incomplete class
abstract class Employee
{
    //encapsulation
    private int id;
    private string name;

    // Public
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    //constructor
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    //
    public abstract double CalculateSalary();

    public virtual void Display()
    {
        Console.WriteLine("===========");
        Console.WriteLine("Employee ID   : " + Id);
        Console.WriteLine("Employee Name : " + Name);
        Console.WriteLine("Salary        : " + CalculateSalary());
    }
}

class FullTimeEmployee : Employee
{
    public double MonthlySalary { get; set; }

    public FullTimeEmployee(int id, string name, double monthlySalary)
        : base(id, name)
    {
        MonthlySalary = monthlySalary;
    }

    //polymorphism
    public override double CalculateSalary()
    {
        return MonthlySalary;
    }

    public override void Display()
    {
        Console.WriteLine("\nFull-Time Employee");
        base.Display();
    }
}
//inheritance
class PartTimeEmployee : Employee
{
    public int HoursWorked { get; set; }
    public double HourlyRate { get; set; }

    public PartTimeEmployee(int id, string name, int hoursWorked, double hourlyRate)
        : base(id, name)
    {
        HoursWorked = hoursWorked;
        HourlyRate = hourlyRate;
    }

    public override double CalculateSalary()
    {
        return HoursWorked * HourlyRate;
    }

    public override void Display()
    {
        Console.WriteLine("\nPart-Time Employee");
        base.Display();
    }
}

class Program
{
    static void Main()
    {
     
        List<Employee> employees = new List<Employee>();

        employees.Add(new FullTimeEmployee(101, "Ahad", 80000));
        employees.Add(new PartTimeEmployee(102, "Hamza", 120, 600));
        employees.Add(new FullTimeEmployee(103, "Umar", 95000));
        employees.Add(new PartTimeEmployee(104, "Ayesha", 90, 700));

        Console.WriteLine("Employee Salary System");

      //override
        foreach (Employee emp in employees)
        {
            emp.Display();
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}