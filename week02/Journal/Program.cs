using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Journal Project.");
        Console.WriteLine("");

        PromptGenerator promptGenerator = new PromptGenerator();

        Journal myJournal = new Journal();
        Random random = new Random();

        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("*  *  *  *  * Menu: *  *  *  *  *");
            
            Console.WriteLine("");

            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the entry");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            Console.WriteLine("");

            Console.Write("Enter your choice (1-5): ");
            choice = Console.ReadLine();
            Console.WriteLine("");

            switch (choice) // I found this easier to use than using a bunch of if/else statements
            //it also makes sure that the user doesn't go out of the choice options

            
            {
                case "1":
                    Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine("");
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {randomPrompt}");
                    Console.WriteLine("");
                    // Display random prompt and get user's response
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.WriteLine("");

                    // Add the entry to the journal
                    myJournal.AddEntry(randomPrompt, response);
                    break;

                case "2":
                    Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine("");
                    Console.WriteLine("         Journal Entry(s):");
                    Console.WriteLine("");
                    myJournal.DisplayJournal();
                    Console.WriteLine("");
                    break;

                case "3":
                    // saving to a csv file
                    string saveFilename = "Journal.csv";
                    
                    myJournal.SaveToFile(saveFilename);
                    Console.WriteLine("");
                    Console.WriteLine($"Journal saved to {saveFilename}.");
                    Console.WriteLine("");
                    break;

                case "4":
                    // loading from a csv file
                    string loadFilename = "Journal.csv";

                    myJournal.LoadFromFile(loadFilename);
                    Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine("\nJournal Entries Loaded:");
                    Console.WriteLine("");
                    // Display the loaded journal entries
                    // this is what I was missing origanally was causing the journal entries to not display
                    // after loading the file
                    myJournal.DisplayJournal();
                    break;

                case "5":
                    // Quit the program
                    Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine("");
                    Console.WriteLine("Have a nice day, goodbye!");
                    Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine("");
                    break;

                //this will restart the loop if the numbers
                // are not between 1 and 5
                // after asking how default works, I learned it helps prevent crashing in the code
                // and allows the user to try again without having to restart the program
                default:
                    Console.WriteLine("Invalid option. Please try again (must be 1-5).");
                    break;
            }


        //this is the orginal code that I used that
        //is no longer needed. it works but not all of what I was wanting
        //nothing is below this, but I will keep this here for future reference

            //     // Generate a random prompt - this will randomply select a propmt for the user
            //     string randomPrompt = prompts[random.Next(prompts.Count)];

            //     // Display random prompt and get user's response
            //     Console.WriteLine($"\nPrompt: {randomPrompt}");
            //     Console.Write("Your response: ");
            //     string response = Console.ReadLine();

            //     // Add the entry to the journal
            //     myJournal.AddEntry(randomPrompt, response);

            //     // Ask if the user wants to add another entry or quit
            //     Console.Write("\nType 'quit' to stop or press Enter to add another entry: ");
            //     choice = Console.ReadLine().ToLower();
            // }

            // // Display the journal
            // Console.WriteLine("\nJournal Entries:");
            // myJournal.DisplayJournal();

            // Journal myJournal = new Journal();
            // myJournal.AddEntry("What was the best part of your day?", "Spending time with family.");
            // myJournal.DisplayJournal();
        }
    }
}