using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        
        string game = "yes";
        // Console.Write("Would you like to play a game? (yes/no)" );
        // string play = Console.ReadLine().ToLower();
        while (game == "yes")
        {
            Console.WriteLine();
            Console.WriteLine("What is the magic number? ");
            Console.WriteLine();

            Random number = new Random();
            int magicnum = number.Next(1, 101);

            int guess = -1;
            int tries =0;

            // Console.Write("What is your guess? ");
            // string guessnumber = Console.ReadLine();
            // int guess = int.Parse(guessnumber);

            while (guess != magicnum)
            {

                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                Console.WriteLine();

                tries += 1; //stretch
                if (magicnum > guess)
                {
                    Console.WriteLine("higher");
                    Console.WriteLine();
                }

                else if (magicnum < guess)
                {
                    Console.WriteLine("Lower");
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine(" - - - - - - - - - - - - - - - - - - -");
                    Console.WriteLine();
                    Console.WriteLine("You are correct!");
                    Console.WriteLine();
                    Console.WriteLine($"You made {tries} guesses"); //stretch
                }
            }
            Console.Write("Would you like to play again? (yes/no) ");
            game = Console.ReadLine().ToLower();
                        
            while (game != "yes" && game != "no")
            {
                Console.Write("Please enter yes or no: ");
                game = Console.ReadLine().ToLower();
            }
        }
        Console.WriteLine();
        Console.WriteLine("Okay, thanks for playing!"); //stretch
    }
}