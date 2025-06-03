using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "What would you do differently if you had to do it again?",
        "How can you apply what you learned from this experience to other challenges in your life?",
        "What strengths did you discover in yourself during this experience?",
        "How can you use these strengths in other areas of your life?",
        "What would you tell someone else who is facing a similar challenge?",
        "How can you encourage others to reflect on their own experiences?",
        "What role did your support system play in this experience?",
        "How can you strengthen your support system for future challenges?",
        "What would you say to your past self before this experience?",
        "How can you celebrate your achievements from this experience?",
        "What advice would you give to someone who is struggling with a similar situation?",
        "How can you continue to grow from this experience in the future?"
    };

    public ReflectionActivity() : base(
        "Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    public void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        Console.WriteLine();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(3);

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5);
        }
        DisplayEndingMessage();
    }
}