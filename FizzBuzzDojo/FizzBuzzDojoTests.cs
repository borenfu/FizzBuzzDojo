using FluentAssertions;

namespace FizzBuzzDojo;

public class FizzBuzzDojoTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(1, "1")]
    [TestCase(2, "1,2")]
    public void normal_case_when_number_is_not_altered(int maxNumber, string expected)
    {
        var calculate = new CalculateService();
        var result = calculate.Result(maxNumber);

        result.Should().Be(expected);
    }
}