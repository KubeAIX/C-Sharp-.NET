using System;

class Program
{
    static void Main()
    {
        double balance = 10000;
        Console.WriteLine("Enter The Withdraw Amount");

        if (!double.TryParse(Console.ReadLine(), out double amount))
        {
            Console.WriteLine("Please Enter a Valid Number: ");
            return;

        }
        //if the amount ye smaller than and equals to Zero than  machines show message Amount must be greater than zero.

            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero '0' ");

                return;

            }

            //Use Execption Handling to check if the amount is greater than the balance and show message Insufficient Balance.

            try
            {
                if (amount > balance)
                {
                    throw new Exception("Insufficient Balance...");
                }
                //balance = balance - amount; but i use compounD Assignment operater 
                balance -= amount;

                Console.WriteLine("Withdraw Succuessful.");
                Console.WriteLine("Your Current Balance is: " + balance);
            }
            catch (Exception exception) //exception is a variable to store exception object
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("Thank you for using our ATM.");



        }
}
