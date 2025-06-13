using System;
using System.Collections.Generic;
using System.IO;

public class ActivityManager
{
    private List<Activity> _activities = new List<Activity>();
    private const string FileName = "ActivityProgress.csv";

    public void Run()
    {
        LoadActivitiesSilent();

        while (true)
        {

            Console.WriteLine("--- Exercise Menu ---");
            Console.WriteLine();
            Console.WriteLine("1. Add Running Activity");
            Console.WriteLine("2. Add Cycling Activity");
            Console.WriteLine("3. Add Swimming Activity");
            Console.WriteLine("4. View All Activity Summaries");
            Console.WriteLine("5. Load Activities");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Choose an option(1-6): ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddRunning();
                    Console.WriteLine();
                    break;
                case "2":
                    AddCycling();
                    Console.WriteLine();
                    break;
                case "3":
                    AddSwimming();
                    Console.WriteLine();
                    break;
                case "4":
                    ShowSummaries();
                    Console.WriteLine();
                    break;
                case "5":
                    LoadActivities();
                    Console.WriteLine();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    private void AddRunning()
    {
        DateTime date = DateTime.Today;
        Console.WriteLine($"{date:yyyy-MM-dd}");
        Console.Write("Minutes: ");
        int minutes = int.Parse(Console.ReadLine());
        Console.Write("Distance (Mi): ");
        double distance = double.Parse(Console.ReadLine());
        Console.Write("Notes: ");
        string notes = Console.ReadLine();
        _activities.Add(new Running(date, minutes, distance, notes));
        Console.WriteLine();
        Console.WriteLine("Running activity added!");
        SaveActivities();
    }

    private void AddCycling()
    {
        DateTime date = DateTime.Today;
        Console.WriteLine($"{date:yyyy-MM-dd}");
        Console.Write("Minutes: ");
        int minutes = int.Parse(Console.ReadLine());
        Console.Write("Speed (Mph): ");
        double speed = double.Parse(Console.ReadLine());
        Console.Write("Notes: ");
        string notes = Console.ReadLine();
        _activities.Add(new Cycling(date, minutes, speed, notes));
        Console.WriteLine();
        Console.WriteLine("Cycling activity added!");
        SaveActivities();
    }

    private void AddSwimming()
    {
        DateTime date = DateTime.Today;
        Console.WriteLine($"{date:yyyy-MM-dd}");
        Console.Write("Minutes: ");
        int minutes = int.Parse(Console.ReadLine());
        Console.Write("Laps: ");
        int laps = int.Parse(Console.ReadLine());
        Console.Write("Notes: ");
        string notes = Console.ReadLine();
        _activities.Add(new Swimming(date, minutes, laps, notes));
        Console.WriteLine();
        Console.WriteLine("Swimming activity added!");
        SaveActivities();
    }

    private void ShowSummaries()
    {
        if (_activities.Count == 0)
        {
            Console.WriteLine("No activities recorded.");
            return;
        }
        foreach (var activity in _activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }

    // --- Save and Load Methods ---

    private void SaveActivities()
    {
        // Sort by activity type and then by date
        var sorted = new List<Activity>(_activities);
        sorted.Sort((a, b) =>
        {
            int typeCompare = a.GetType().Name.CompareTo(b.GetType().Name);
            if (typeCompare != 0)
                return typeCompare;
            return a.GetDate().CompareTo(b.GetDate());
        });

        using (StreamWriter sw = new StreamWriter(FileName))
        {
            foreach (var activity in sorted)
            {
                sw.WriteLine(activity.ToCsv());
            }
        }
    }

    private void LoadActivities()
    {
        _activities.Clear();
        if (!File.Exists(FileName))
            return;

        string[] lines = File.ReadAllLines(FileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string type = parts[0];
            DateTime date = DateTime.Parse(parts[1]);
            int minutes = int.Parse(parts[2]);
            switch (type)
            {
                case "Running":
                    double distance = double.Parse(parts[3]);
                    string runningNotes = parts.Length > 4 ? parts[4] : "";
                    _activities.Add(new Running(date, minutes, distance, runningNotes));
                    break;
                case "Cycling":
                    double speed = double.Parse(parts[3]);
                    string cyclingNotes = parts.Length > 4 ? parts[4] : "";
                    _activities.Add(new Cycling(date, minutes, speed, cyclingNotes));
                    break;
                case "Swimming":
                    int laps = int.Parse(parts[3]);
                    string swimmingNotes = parts.Length > 4 ? parts[4] : "";
                    _activities.Add(new Swimming(date, minutes, laps, swimmingNotes));
                    break;
            }
        }
        Console.WriteLine("Activities loaded from ActivityProgress.csv.");
    } 

    private void LoadActivitiesSilent()
    {
        _activities.Clear();
        if (!File.Exists(FileName))
            return;

        string[] lines = File.ReadAllLines(FileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length < 4) continue; // Skip malformed lines

            string type = parts[0];
            DateTime date;
            if (!DateTime.TryParse(parts[1], out date)) continue; // Skip if date is invalid
            int minutes;
            if (!int.TryParse(parts[2], out minutes)) continue; // Skip if minutes is invalid

            switch (type)
            {
                case "Running":
                    double distance = double.TryParse(parts[3], out distance) ? distance : 0;
                    string runningNotes = parts.Length > 4 ? parts[4] : "";
                    _activities.Add(new Running(date, minutes, distance, runningNotes));
                    break;
                case "Cycling":
                    double speed = double.TryParse(parts[3], out speed) ? speed : 0;
                    string cyclingNotes = parts.Length > 4 ? parts[4] : "";
                    _activities.Add(new Cycling(date, minutes, speed, cyclingNotes));
                    break;
                case "Swimming":
                    int laps = int.TryParse(parts[3], out laps) ? laps : 0;
                    string swimmingNotes = parts.Length > 4 ? parts[4] : "";
                    _activities.Add(new Swimming(date, minutes, laps, swimmingNotes));
                    break;
            }
        }
    }
}
