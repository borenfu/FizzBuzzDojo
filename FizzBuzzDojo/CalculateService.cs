using System.Text;

namespace FizzBuzzDojo;

public class CalculateService
{
    public string Result(int i)
    {
        var result = new StringBuilder();
        for (var j = 1; j <= i; j++)
        {
            if (j > 1)
            {
                result.Append(',');
            }

            if (j % 3 == 0)
            {
                result.Append("Fizz");
            }
            else
            {
                result.Append(j);
            }
        }

        return result.ToString();
    }
}