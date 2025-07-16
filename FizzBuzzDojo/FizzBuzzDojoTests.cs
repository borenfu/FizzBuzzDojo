using FluentAssertions;

namespace FizzBuzzDojo;

public class FizzBuzzDojoTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void normal_case_when_number_1_is_1()
    {
        var calculate = new CalculateService();
        var result = calculate.Result(1);

        result.Should().Be("1");
    }
}