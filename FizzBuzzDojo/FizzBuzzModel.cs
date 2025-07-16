namespace FizzBuzzDojo;

public class FizzBuzzModel(int number)
{
    private bool IsDividedBy3 => number % 3 == 0;
    private bool IsDividedBy5 => number % 5 == 0;
    private bool IsContain3 => number.ToString().Contains('3');

    public string GetValue()
    {
        var value = string.Empty;
        
        if (IsDividedBy3 || IsContain3)
        {
            value += "Fizz";
        }

        if (IsDividedBy5)
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