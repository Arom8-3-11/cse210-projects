using System;

// public class SimpleGoal : Goal
// {
//     private bool _isComplete;

//     public SimpleGoal(string name, string description, int points)
//         : base(name, description, points)
//     {
//         _isComplete = false;
//     }

//     public override int RecordEvent()
//     {
//         _isComplete = true;
//         return _points;
//     }

//     public override bool IsComplete() => _isComplete;

//     public override string GetStringRepresentation()
//     {
//         return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
//     }
// }

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete; // Initialize completion status
    }

    public SimpleGoal(string name, string description, int points)
        : this(name, description, points, false) { }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }

    public void SetComplete(bool complete)
    {
        _isComplete = complete;
    }
}