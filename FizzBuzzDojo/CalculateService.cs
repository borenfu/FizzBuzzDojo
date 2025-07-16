using System.Text;

namespace FizzBuzzDojo;

public class CalculateService
{
    public string Result(int startNumber, int endNumber)
    {
        var result = new StringBuilder();

        for (var i = startNumber; i <= endNumber; i++)
        {
            var fizzBuzzModel = new FizzBuzzModel(i);
            var value = fizzBuzzModel.GetValue();
            result.Append(value);
        }

        return result.ToString();
    }
}