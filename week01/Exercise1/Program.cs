using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");

        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        Console.Write("What is your last name? ");
        string second = Console.ReadLine();

        Console.WriteLine($"Your name is {second}, {first} {second}. ");
    }
}