using System;
// This is a Subclass of Activity

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    // Added method for a fun breath animation
    // I'll keep the hidden methods for reference, but not use them in the final part of the program

        // Uncomment this method shows a simple asterisk animation for breathing (don't forget to uncomment the ShowBreathAnimation method in the Run method)
    // public void ShowBreathAnimation(int seconds, string direction)
    // {
    //     Console.Write(direction + " ");
    //     int totalSteps = 20;
    //     int totalMillis = seconds * 1000;
    //     for (int i = 1; i <= totalSteps; i++)
    //     {
    //         Console.Write("*");
    //         // Slow down as you approach the end
    //         int stepDelay = totalMillis / totalSteps;
    //         System.Threading.Thread.Sleep(stepDelay);
    //     }
    //     Console.WriteLine();
    // }


        // Uncomment this method if you want to use the bar animation (don't forget to uncomment the ShowBreathBar method in the Run method)

    public void ShowBreathBar(int seconds, string direction)
    {
        int totalSteps = 20;
        int delay = (seconds * 1000) / totalSteps;
        if (direction.Contains("in"))
        {
            for (int i = 1; i <= totalSteps; i++)
            {
                Console.Write("\r" + direction + " [" + new string('#', i) + new string(' ', totalSteps - i) + "]");
                System.Threading.Thread.Sleep(delay);
            }
        }
        else // "out"
        {
            for (int i = totalSteps; i >= 1; i--)
            {
                Console.Write("\r" + direction + " [" + new string('#', i) + new string(' ', totalSteps - i) + "]");
                System.Threading.Thread.Sleep(delay);
            }
        }
        Console.WriteLine();
    }


        // Uncomment this method if you want to use the text fade animation (don't forget to uncomment the ShowBreathTextFade method in the Run method)

    // public void ShowBreathTextFade(int seconds, string direction)
    // {
    //     int totalSteps = 10;
    //     int delay = (seconds * 1000) / totalSteps;
    //     if (direction.Contains("in"))
    //     {
    //         for (int i = 0; i <= totalSteps; i++)
    //         {
    //             Console.Write("\r" + new string(' ', totalSteps - i) + direction);
    //             System.Threading.Thread.Sleep(delay);
    //         }
    //     }
    //     else
    //     {
    //         for (int i = totalSteps; i >= 0; i--)
    //         {
    //             Console.Write("\r" + new string(' ', totalSteps - i) + direction + "   ");
    //             System.Threading.Thread.Sleep(delay);
    //         }
    //     }
    //     Console.WriteLine();
    // }


        // Uncomment this method if you want to use the dots animation (don't forget to uncomment the ShowBreathDots method in the Run method)

    // public void ShowBreathDots(int seconds, string direction)
    // {
    //     Console.Write(direction + " ");
    //     for (int i = 0; i < seconds; i++)
    //     {
    //         Console.Write(".");
    //         System.Threading.Thread.Sleep(1000);
    //     }
    //     Console.WriteLine();
    // }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            //countdown animation

            // Console.Write("Breathe in... ");
            // ShowCountdown(3);
            // if (DateTime.Now >= endTime) break;
            // Console.Write("Breathe out... ");
            // ShowCountdown(3);

            // asterisk animation

            // ShowBreathAnimation(6, "Breathe in...");
            // if (DateTime.Now >= endTime) break;
            // ShowBreathAnimation(4, "Breathe out...");

            // Bar animation

            ShowBreathBar(6, "Breathe in...");
            if (DateTime.Now >= endTime) break;
            ShowBreathBar(4, "Breathe out...");

            // Text fade animation

            // ShowBreathTextFade(6, "Breathe in...");
            // if (DateTime.Now >= endTime) break;
            // ShowBreathTextFade(4, "Breathe out...");

            // dots animation

            // ShowBreathDots(6, "Breathe in...");
            // if (DateTime.Now >= endTime) break;
            // ShowBreathDots(4, "Breathe out...");
            // Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}