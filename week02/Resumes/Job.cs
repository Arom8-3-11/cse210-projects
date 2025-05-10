

public class Job
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"     Job Title: {_jobTitle}");
        Console.WriteLine($"     Company: {_company}");
        Console.WriteLine($"     Years Worked: {_startYear} - {_endYear}");
    }
}