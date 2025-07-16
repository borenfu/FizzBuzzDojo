namespace FizzBuzzDojo;

public class FizzBuzzModel(int number)
{
    private bool IsDividedBy3 => number % 3 == 0;
    private bool IsDividedBy5 => number % 5 == 0;

    public string GetValue()
    {
        if (number == 1)
        {
            return number.ToString();
        }

        if (IsDividedBy5 && IsDividedBy3)
        {
            return ",FizzBuzz";
        }

        if (IsDividedBy3)
        {
            return ",Fizz";
        }

        if (IsDividedBy5)
        {
            return ",Buzz";
        }

        return "," + number;
    }
}