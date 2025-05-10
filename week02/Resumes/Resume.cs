using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Method to display the resume details
    public void DisplayResume()
    {
        Console.WriteLine($"                   Name: {_name}"                     );
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("Jobs:");
        Console.WriteLine("");

        foreach (Job job in _jobs)
        {
            job.Display();

            Console.WriteLine();
        }
        
        Console.WriteLine("------------------------------------------------------");
    }
}