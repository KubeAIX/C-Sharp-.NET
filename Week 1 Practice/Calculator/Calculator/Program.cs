using System;
class CalculatorProgram
{
    static void Main(string[] args)
    {
        bool continuecalculator = true;
        while (continuecalculator)
        {
            Console.Write("Enter First Number: ");
            double num1 = GetValidNumber();

            Console.Write("Enter Second Number: ");
            double num2 = GetValidNumber();

            Console.WriteLine("\n Calculate Menu");

            Console.WriteLine("1. Additon");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            Console.Write("Choose Option: ");
            int choice = GetValidChoice();

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Result = {Add(num1, num2)}");
                    break;
                case 2:
                    Console.Write($"Result = {Subtract(num1, num2)}");
                    break;
                case 3:
                    Console.Write($"Result = {Multiply(num1, num2)}");
                    break;
                case 4:
                    Console.Write($"Result = {Divide(num1, num2)}");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;


            }
            Console.WriteLine("\nDo you want another calculation?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. Exit");

            Console.Write("Choose: ");

            int again = GetContinueChoice();


            if (again == 2)
            {
                continuecalculator = false;
            }

        }
    }
    static double Add(double a, double b)
    {
        return a + b;

    }
    static double Subtract(double a, double b)
    {
        return a - b;

    }
    static double Multiply(double a, double b)
    {
        return a * b;

    }
    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Division by zero is not Allowed");
            return 0;
        }
        return a / b;
    }


    static double GetValidNumber()
    {
        double number;

        while (!double.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid Input please enter valid number: ");

        }
        return number;
    }
    static int GetValidChoice()
    {
        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.Write("Invalid Choice Enter option 1-4: ");

        }
        return choice;
    }
    static int GetContinueChoice()
    {
        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
        {
            Console.Write("Enter 1 for Yes or 2 for Exit: ");
        }

        return choice;
    }
}