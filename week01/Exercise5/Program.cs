using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        // these next six lines did not work with this project. it could but not with what we are working on for this specific assignment

        // Console.WriteLine("Hello Prep5 World!");
        // Console.WriteLine("- - - - - Welcome to the Program! - - - - -");
        // Console.Write("Please enter a username: ");
        // string name = Console.ReadLine();
        // Console.Write("Please enter your favorite number: ");
        // int number = int.Parse()


        //the lines above can work, just not quite the right method used with display method



        DisplayWelcome(); //with these first few lines, it helps create a display seperate from the rest of the code
        // this will take the information from the rest of the variables

        string username = PromptUserName();
        int usernumber = PromptUserNumber();

        int squarednumber = SquareNumber(usernumber);

        displayresult(username, squarednumber);
        static void DisplayWelcome() //the void in this situation means that the variable will not have a return value
        { //as for "static" means that the variable belongs to the program class and not an object
            Console.WriteLine("Welcome tothe program!");
        }
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();

            return name;
        }
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());

            return number;
        }
        static int SquareNumber(int number)
        {
            int square = number * number;
            return square; 
        }
        static void displayresult(string name, int square)
        {
            Console.WriteLine($"{name}, the square of the number is {square}");
        }
    }
}