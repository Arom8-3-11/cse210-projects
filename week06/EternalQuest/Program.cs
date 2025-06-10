using System;
// I added a progress goal and negative goal classes to the general goal system.
// The progress goal allows tracking of progress towards a target, while the negative goal deducts points when an event is recorded.
// The main program initializes the GoalManager and starts the application.
class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the EternalQuest Project.");
        Console.Clear();
        // Initialize the GoalManager and start the application
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}