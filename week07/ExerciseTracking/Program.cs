// I found this similar to last week's project, but just adding the functions of encapsulation
// I made mine in which it will save onto a csv file and managed by another file

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine();
        // Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        ActivityManager manager = new ActivityManager();
        manager.Run();
        Console.WriteLine();
        Console.WriteLine("Thank you for using the Exercise Tracking application!");
    }
}