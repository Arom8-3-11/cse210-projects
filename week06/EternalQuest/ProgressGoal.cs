using System;
// progress goal class
// This class represents a goal that tracks progress towards a target and awards points based on the amount of progress made.

public class ProgressGoal : Goal
{
    private int _progress;
    private int _target;
    private int _perUnitPoints;

    public ProgressGoal(string name, string description, int perUnitPoints, int target, int progress = 0)
        : base(name, description, perUnitPoints)
    {
        _perUnitPoints = perUnitPoints;
        _target = target;
        _progress = progress;
    }

    public override int RecordEvent()
    {
        Console.Write($"How much progress did you make towards '{_shortName}'? ");
        int amount = int.Parse(Console.ReadLine());
        _progress += amount;
        int earned = amount * _perUnitPoints;
        if (_progress > _target) _progress = _target;
        return earned;
    }

    public override bool IsComplete() => _progress >= _target;

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Progress: {_progress}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal|{_shortName}|{_description}|{_perUnitPoints}|{_target}|{_progress}";
    }
}