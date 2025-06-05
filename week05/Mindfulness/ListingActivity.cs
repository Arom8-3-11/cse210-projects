using System;
using System.Collections.Generic;
// this is a subclass of Activity

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are some of your favorite memories?",
        "What are some things you are grateful for?",
        "What are some things you love about your life?",
        "What are some things you enjoy doing?",
        "What are some things that make you happy?",
        "What are some things you are looking forward to?",
        "What are some things you are proud of?",
        "What are some things you have learned recently?",
        "Who are some people you admire?",
        "Why are you grateful for your family?",
        "When was a time you felt truly at peace?",
        "When was a time you felt truly happy?",
        "What are some things you love about your job?"
    };

    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { } // constructor = body of the constructor, the body is empty because all the work is done by calling the base class constructor with ": base(...)"

    public void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        Console.WriteLine();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("You may begin in: ");
        ShowCountdown(3);

        int duration = GetDuration();
        // int elapsed = 0;
        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("List an item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
        DisplayEndingMessage();
    }
}