public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance, string notes)
        : base(date, minutes, notes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / _distance;
    public override string ToCsv()
    {
        return $"Running,{GetDate():yyyy-MM-dd},{GetMinutes()},{_distance},{GetNotes()}";
    }
}