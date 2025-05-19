using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    public int GetNumerator()
    {
        return numerator;
    }
    public void SetNumerator(int num)
    {
        numerator = num;
    }

    public int GetDenominator()
    {
        return denominator;
    }
    public void SetDenominator(int denom)
    {
        denominator = denom;
    }

    //Constructor that has no parameters that initializes the number to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    //Constructor that has one parmeter for the top and that initializes the denominator to 1. So that if you pass in the number 5, the fraction would be initialized to 5/1
    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    //Constructor that has two parameters, One for the top and one for the bottome
    public Fraction(int top, int bottom)
    {
        numerator = top;
        denominator = bottom;
    }

    //method demo
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)numerator / (double)denominator;
    }

}