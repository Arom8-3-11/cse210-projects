public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps, string notes)
        : base(date, minutes, notes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50.0 / 1609.34; // miles
    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / GetDistance();
    public override string ToCsv()
    {
        return $"Swimming,{GetDate():yyyy-MM-dd},{GetMinutes()},{_laps},{GetNotes()}";
    }
}