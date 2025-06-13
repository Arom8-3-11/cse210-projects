public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed, string notes)
        : base(date, minutes, notes)
    {
        _speed = speed;
    }

    public override double GetDistance() => _speed * GetMinutes() / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;
    public override string ToCsv()
    {
        return $"Cycling,{GetDate():yyyy-MM-dd},{GetMinutes()},{_speed},{GetNotes()}";
    }
}