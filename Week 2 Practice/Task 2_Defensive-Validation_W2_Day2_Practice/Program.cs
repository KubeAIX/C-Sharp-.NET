using System;

using System.Collections.Generic;

class Program
{
    static void Main()
    //for stdunts record yahan dic use karengy Keys unique hoti hain, values duplicate ho sakti hain.
    {           // key, Value
        Dictionary<int, string> students = new Dictionary<int, string>();
        // here ARID University Registration Numbers are used as keys and student names as values
        students.Add(4669, "Abdul Ahad");
        students.Add(4668, "Abdul Saboor");
        students.Add(4680, "Maria Zahid");
        students.Add(4676, "Umar Tahir");
        Console.WriteLine("Enter your Registration Number: ");
        // use 
        int id = Convert.ToInt32(Console.ReadLine());

        //Defensive Validation

        if (!students.ContainsKey(id))
        {
            Console.WriteLine("Student Not found, yours data not available contact Admin");
            return;

        }  // use concatination to show the student name

        Console.WriteLine("StudentName: " + students[id]);


    }
     
}