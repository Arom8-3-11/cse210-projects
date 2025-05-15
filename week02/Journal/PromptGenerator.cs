using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> prompts;
    private Random random;

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If you had one thing I could do over today, what would it be?",
            "What is a small act of kindness you witnessed or experienced recently?",
            "What is something you learned today that surprised you?",
            "What is a goal you want to achieve in the next month?",
            "What is something you are grateful for today?",
            "What is a challenge you faced today and how did you overcome it?",
            "What is a book or article you read recently that inspired you?",
            "What is a skill you want to learn or improve?",
            "What is a place you want to visit and why?",
            "What is a quote or saying that resonates with you?",
            "What is a hobby or activity that brings you joy?",
            "What is a memory that makes you smile?",
            "What is a lesson you learned from a mistake?",
            "What is a personal value that is important to you?",
            "What is a dream or aspiration you have for the future?",
            "How can you reframe one of your biggest regrets in life?",
            "How do you feel about asking for help?",
            "Find two unrelated objects near you and think of a clever way they might be used together.",
            "Consider and reflect on what might be your 'favorite failure.'",
            "If you could eliminate any one disease or illness from the world, what would you choose and why?",
            "Imagine that you have arrived at a closed door. What does it look like and what’s on the other side?",
            "Invent your own planet. Draw a rough sketch of the planet and its inhabitants. How is it different than Earth?"
        };
        random = new Random();
    }

    public string GetRandomPrompt()
    {
        return prompts[random.Next(prompts.Count)];
    }
}
