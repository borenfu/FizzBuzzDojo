namespace FizzBuzzDojo;

public class FizzBuzzModel(int number)
{
    private bool IsDividedBy3 => number % 3 == 0;
    private bool IsDividedBy5 => number % 5 == 0;
    private bool IsContain3 => number.ToString().Contains('3');
    private bool IsContain5 => number.ToString().Contains('5');

    public string GetValue()
    {
        var value = string.Empty;

        if (IsDividedBy3 || IsContain3)
        {
            value += "Fizz";
        }

        if (IsDividedBy5 || IsContain5)
        {
            value += "Buzz";
        }

        if (value == string.Empty)
        {
            return "," + number;
        }

        return "," + value;
    }
}