using System;
class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        Console.Clear(); // this will clear the console
        Console.WriteLine("");
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Thread.Sleep(1000); // pause before going to the next line for 5 seconds
        Console.WriteLine("You will be given a random scripture to memorize.");
        Thread.Sleep(2000);
        Console.WriteLine("You can hide a few words at a time to test your memory.");
        Thread.Sleep(2000);
        Console.WriteLine("Starting now...");
        Thread.Sleep(1000);
        Library library = new Library();
        Scripture scripture = library.GetRandomScripture();


        // Orignal scripture reference and text
        // Reference reference = new Reference("John", 3, 16);
        // string text = "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";

        // Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("");
            Console.WriteLine("Press enter to hide the words or type 'quit' to end the program.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3); // hide 3 random words

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine($"               You've memorized: {scripture.GetReferenceText()}");
                Console.WriteLine("");
                Console.WriteLine("Congratulations! The program will now end since you've finished!");
                Console.WriteLine("");
                Thread.Sleep(1000);
                Console.WriteLine("                            Goodbye.                            ");
                Console.WriteLine("");

                break;
            }
        }
    }
}