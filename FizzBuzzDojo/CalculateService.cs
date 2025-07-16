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

            result.Append(j);
        }

        return result.ToString();
    }
}