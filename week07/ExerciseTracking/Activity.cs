using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    private string _notes;

    public Activity(DateTime date, int minutes, string notes)
    {
        _date = date;
        _minutes = minutes;
        _notes = notes;
    }

    public DateTime GetDate() => _date;
    public int GetMinutes() => _minutes;
    public string GetNotes() => _notes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min): " +
               $"     Distance {GetDistance():0.0} Mi, Speed {GetSpeed():0.0} Mph, Pace: {GetPace():0.00} min per Mi, Notes: {_notes}";
    }

    public abstract string ToCsv();
}