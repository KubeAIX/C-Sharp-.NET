using System;
// Build a marks and grade calculator with validation and repeated input.
class Program
{ 
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Marks and Grade Calculator");

            double marks = -1; //loop runs at least once
            while (marks < 0 || marks > 100)
            {
                Console.Write("Enter the students marks (0 to 100): ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out marks) && marks >= 0 && marks <= 100)
                {
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
                    marks = -1; 
                }
            }

            string grade;
            if (marks >= 90)
            {
                grade = "A";
            }
            else if (marks >= 80)
            {
                grade = "B";
            }
            else if (marks >= 70)
            {
                grade = "C";
            }
            else if (marks >= 55)// below than 55 considered fail
            {
                grade = "D";
            }
       else
            {
                grade = "F";
            }

            Console.WriteLine($"Result: Marks = {marks}, Grade = {grade}\n");
            Console.Write("Do you want to calculate another grade? (yes/no): ");// repeated input if user select yes or y. if no
            string choice = Console.ReadLine().Trim().ToLower(); //.trim remove space agar usr ghalti sy spce dy dy.
            if (choice != "yes" && choice != "y")// here use yes and y both
            {//No than close the program or clik other button  to close the procedure
                Console.WriteLine("Thank you for using the calculator.");
                break; 
            }

            Console.WriteLine(); //
        }
    }
}