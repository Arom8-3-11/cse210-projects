using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        LoadGoalsSilent();
        while (true)
        {
            Console.WriteLine($"\nScore: {_score}");
            Console.WriteLine("-------------");
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Edit Goal");
            Console.WriteLine("7. Delete Goal");
            Console.WriteLine("8. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();


            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    EditGoal();
                    break;
                case "7":
                    DeleteGoal();
                    break;
                case "8":
                    return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type: 1) Simple 2) Eternal 3) Checklist 4) Progress 5) Negative"); //added progress and negative goals
        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Target times: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new CheckListGoal(name, desc, points, target, bonus));
                break;
            case "4": //added progress goal
                Console.Write("Target progress amount: ");
                int progressTarget = int.Parse(Console.ReadLine());
                _goals.Add(new ProgressGoal(name, desc, points, progressTarget));
                break;
            case "5": //added negative goal
                _goals.Add(new NegativeGoal(name, desc, points));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }

    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int idx = int.Parse(Console.ReadLine()) - 1;
        int earned = _goals[idx].RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points!");
    }

    public void SaveGoals()
    {
        // Console.Write("Filename: ");
        string filename = "SavedGoals.csv"; // For simplicity, using a fixed filename
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine(_score);
            foreach (Goal g in _goals)
                sw.WriteLine(g.GetStringRepresentation());
        }
        Console.WriteLine("Goals saved to: " + filename);
    }

    // public void LoadGoals() //saved for future reference
    // {
    //     // Console.Write("Filename: ");
    //     string filename = "SavedGoals.csv"; // For simplicity, using a fixed filename
    //     if (!File.Exists(filename))
    //     {
    //         Console.WriteLine("File not found.");
    //         return;
    //     }
    //     _goals.Clear();
    //     string[] lines = File.ReadAllLines(filename);
    //     _score = int.Parse(lines[0]);
    //     for (int i = 1; i < lines.Length; i++)
    //     {
    //         string[] parts = lines[i].Split(',');
    //         if (parts[0] == "SimpleGoal")
    //             _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])) { /* set _isComplete if needed */ });
    //         else if (parts[0] == "EternalGoal")
    //             _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
    //         else if (parts[0] == "ChecklistGoal")
    //             _goals.Add(new CheckListGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
    //     }
    //     Console.WriteLine("Goals loaded from: " + filename);
    //     ListGoalDetails();
    public void LoadGoals()
    {
        string filename = "SavedGoals.csv"; // saved to fixed filename for simplicity
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new CheckListGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                    break;
                case "ProgressGoal":
                    _goals.Add(new ProgressGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                default:
                    Console.WriteLine($"Unknown goal type: {parts[0]}");
                    break;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Goals loaded from SavedGoals.csv.");
        Console.WriteLine();
        Console.WriteLine("Current Goals:");
        Console.WriteLine("-------------");
        ListGoalDetails();
        Console.WriteLine();

    }

    public void EditGoal()
    {
        ListGoalDetails();
        Console.Write("Enter the number of the goal to edit: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= _goals.Count)
        {
            Goal goal = _goals[idx - 1];
            Console.WriteLine($"Editing: {goal.GetDetailsString()}");
            Console.Write("New description (leave blank to keep current): ");
            string desc = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(desc))
                goal.SetDescription(desc); // If _description is protected, otherwise add a setter

            Console.Write("New points (leave blank to keep current): ");
            string pts = Console.ReadLine();
            if (int.TryParse(pts, out int newPoints))
                goal.SetPoints(newPoints); // If _points is protected, otherwise add a setter

            Console.WriteLine("Goal updated.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void DeleteGoal()
    {
        ListGoalDetails();
        Console.Write("Enter the number of the goal to delete: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= _goals.Count)
        {
            Console.WriteLine($"Deleting: {_goals[idx - 1].GetDetailsString()}");
            _goals.RemoveAt(idx - 1);
            Console.WriteLine("Goal deleted.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
    public void SaveGoalsAppend()
    {
        string filename = "SavedGoals.csv";
        using (StreamWriter sw = new StreamWriter(filename, append: true))
        {
            foreach (Goal g in _goals)
                sw.WriteLine(g.GetStringRepresentation());
        }
        Console.WriteLine("Goals appended to: " + filename);
    }
    private void LoadGoalsSilent()
    {
        string filename = "SavedGoals.csv";
        if (!File.Exists(filename))
            return;
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new CheckListGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                    break;
                case "ProgressGoal":
                    _goals.Add(new ProgressGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
            }
        }
    }
}