using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");


        Console.Write("What is your grade (percent)? ");
        string percent = Console.ReadLine(); //this will make a variable string from the previous console.write statement
        int number = int.Parse(percent); //this will help convert a string into an integer

        string letter = " ";


        if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";
        }
        else if (number >= 70)
        {
            letter = "C";
        }
        else if (number >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string symbol ="";

        // if (number > 96, 86, 76, 66)
        // if (number % 10 >= 7 && number < 100)
        if (number < 60)
        {
            symbol ="";
        }
        else if (number >= 90)
        {
            if (number == 100)
            {
                symbol = " ";
            }
            else if (number % 10 > 3)
            {
                symbol = "";
            }
            else 
            {
                symbol = "-";
            }
        }
        else if (number % 10 >= 7)
        {
            symbol = "+";
        }
        // else if (number < 93, 83, 73, 63)
            // incorrect use of comma-separated values. C# does not support comma-separated comparisons like this.
            // use of && and || help define ranges or specific conditions.
            // using this makes the program assume that the string should only be assigned for grades above 60 
        else if (number % 10 <= 3 && number >= 60)
        {
            symbol = "-";
        }
        else
        {
            symbol = " ";
        }
        Console.WriteLine($"You grade is: {letter.ToUpper()}{symbol}"); //this will make the letters uppercase
        // this will make the letters uppercase

        if (number >= 70)
        {
            Console.WriteLine("You passed the class!");
        }

        else
        {
            Console.WriteLine("Keep working on it!");
        }
    }
}