using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    //Student Class
    class Student
    {
        //Properties
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public double GPA { get; set; }

        //Constructor
        public Student(int id, string name, int age, string department, double gpa)
        {
            StudentId = id;
            Name = name;
            Age = age;
            Department = department;
            GPA = gpa;
        }

        //Display Student Information
        public void Display()
        {
            Console.WriteLine("=====");
            Console.WriteLine($"ID         : {StudentId}");
            Console.WriteLine($"Name       : {Name}");
            Console.WriteLine($"Age        : {Age}");
            Console.WriteLine($"Department : {Department}");
            Console.WriteLine($"GPA        : {GPA}");
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\nSTUDENT MANAGEMENT SYSTEM");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Search Student");
                Console.WriteLine("5. Display All Students");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        UpdateStudent();
                        break;

                    case 3:
                        DeleteStudent();
                        break;

                    case 4:
                        SearchStudent();
                        break;

                    case 5:
                        DisplayStudents();
                        break;

                    case 6:
                        Console.WriteLine("Thank you!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }

            } while (choice != 6);
        }

        // Add Student
        static void AddStudent()
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Student s in students)
            {
                if (s.StudentId == id)
                {
                    Console.WriteLine("Student ID already exists!");
                    return;
                }
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Department: ");
            string department = Console.ReadLine();

            Console.Write("Enter GPA: ");
            double gpa = Convert.ToDouble(Console.ReadLine());

            Student student = new Student(id, name, age, department, gpa);

            students.Add(student);

            Console.WriteLine("Student Added Successfully!");
        }

        // Update Student
        static void UpdateStudent()
        {
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.StudentId == id);

            if (student == null)
            {
                Console.WriteLine("Student Not Found.");
                return;
            }

            Console.Write("Enter New Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter New Age: ");
            student.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Department: ");
            student.Department = Console.ReadLine();

            Console.Write("Enter New GPA: ");
            student.GPA = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Student Updated Successfully!");
        }

        // Delete Student
        static void DeleteStudent()
        {
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.StudentId == id);

            if (student == null)
            {
                Console.WriteLine("Student Not Found.");
                return;
            }

            students.Remove(student);

            Console.WriteLine("Student Deleted Successfully!");
        }

        // Search Student
        static void SearchStudent()
        {
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.StudentId == id);

            if (student == null)
            {
                Console.WriteLine("Student Not Found.");
                return;
            }

            student.Display();
        }

        // Display All Students
        static void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found.");
                return;
            }

            Console.WriteLine("\nStudent List");

            foreach (Student student in students)
            {
                student.Display();
            }
        }
    }
}