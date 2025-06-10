using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public void SetDescription(string desc) { _description = desc; }
    public void SetPoints(int points) { _points = points; }

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description})";
    }
    public abstract string GetStringRepresentation();
}