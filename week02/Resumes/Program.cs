using System;
using System.Transactions;

class Program
{
        static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Resumes Project.");

        Console.WriteLine("");
        // Create a new job instance/object named job1
        Job job1 = new Job();
        job1._jobTitle = "Sandwich Artist";
        job1._company = "Subway";
        job1._startYear = 2018;
        job1._endYear = 2020;

        // Create second job instance
        Job job2 = new Job();
        job2._jobTitle = "Cashier, Art/Hobbies Department Lead";
        job2._company = "Hobby Lobby";
        job2._startYear = 2021;
        job2._endYear = 2025;

        // commented out since not needed

        // Display the job details
        // job1.DisplayJobDetails();

        // Console.WriteLine(); // Add a blank line for better readability
        
        // job2.DisplayJobDetails();
        // Print the current date in a readable format
        Console.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd"));

        // create new resume instance
        Resume myResume = new Resume();
        myResume._name = "Audrey Romrell";

        // Add jobs to resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);


        // display resume
        myResume.DisplayResume();
        myResume.DisplayResume();
        Console.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd"));
        
    }
}