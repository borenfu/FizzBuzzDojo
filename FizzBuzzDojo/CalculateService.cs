namespace FizzBuzzDojo;

public class CalculateService
{
    public string Result(int i)
    {
        var result = string.Empty;
        for (var j = 1; j <= i; j++)
        {
            result += j;
        }

        return result;
    }
}