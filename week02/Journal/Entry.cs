using System;

public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;

    public Entry(string prompt, string response)
    {
        _prompt = prompt;
        _response = response;
        // auto sets the date tot the current date when 
        // the entry is created
        _date = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public void DisplayEntry()
    {
        Console.WriteLine("*  *  *  *  * Entry(s): *  *  *  *  *");
        Console.WriteLine("");
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine("");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine("");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine("");
    }
}