using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Journal Project.");
        Console.WriteLine("");

        PromptGenerator promptGenerator = new PromptGenerator();
        // List<string> prompts = new List<string>
        // {
        //     "Who was the most interesting person I interacted with today?",
        //     "What was the best part of my day?",
        //     "How did I see the hand of the Lord in my life today?",
        //     "What was the strongest emotion I felt today?",
        //     "If you had one thing I could do over today, what would it be?",
        //     "What is a small act of kindness you witnessed or experienced recently?",
        //     "What is something you learned today that surprised you?",
        //     "What is a goal you want to achieve in the next month?",
        //     "What is something you are grateful for today?",
        //     "What is a challenge you faced today and how did you overcome it?",
        //     "What is a book or article you read recently that inspired you?",
        //     "What is a skill you want to learn or improve?",
        //     "What is a place you want to visit and why?",
        //     "What is a quote or saying that resonates with you?",
        //     "What is a hobby or activity that brings you joy?",
        //     "What is a memory that makes you smile?",
        //     "What is a lesson you learned from a mistake?",
        //     "What is a personal value that is important to you?",
        //     "What is a dream or aspiration you have for the future?",
        //     "How can you reframe one of your biggest regrets in life?",
        //     "How do you feel about asking for help?",
        //     "Find two unrelated objects near you and think of a clever way they might be used together.",
        //     "Consider and reflect on what might be your 'favorite failure.'",
        //     "If you could eliminate any one disease or illness from the world, what would you choose and why?",
        //     "Imagine that you have arrived at a closed door. What does it look like and what’s on the other side?",
        //     "Invent your own planet. Draw a rough sketch of the planet and its inhabitants. How is it different than Earth?"
        // };

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
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {randomPrompt}");
                    // string randomPrompt = prompts[random.Next(prompts.Count)];

                    // Display random prompt and get user's response
                    // Console.WriteLine($"\nPrompt: {randomPrompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    // Add the entry to the journal
                    myJournal.AddEntry(randomPrompt, response);
                    break;

                case "2":
                    Console.WriteLine("\nJournal Entry:");
                    myJournal.DisplayJournal();
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