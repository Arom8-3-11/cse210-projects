using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        Console.WriteLine();

        List<int> numbers = new List<int>();

        int usernum = -1;
        while (usernum != 0)
        {
            Console.Write("Enter a number (Enter 0 to quit) ");

            string userRes = Console.ReadLine(); 
            usernum = int.Parse(userRes); //C#, Parse is a method used to convert a string representation of a number into its numeric equivalent
            if (usernum != 0)
            {
                numbers.Add(usernum);
            }
        }

        int sum =0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"the sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is : {average}");

        int max = numbers[0];

        foreach (int number in numbers) //this is the command in which will help with iterating through each number in the list allowing it to add up
        {
            if  (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}