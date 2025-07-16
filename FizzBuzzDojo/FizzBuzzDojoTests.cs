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
    
    [Test]
    [TestCase(3, "1,2,Fizz")]
    [TestCase(4, "1,2,Fizz,4")]
    public void fizz_case_when_number_is_divided_by_3(int maxNumber, string expected)
    {
        var calculate = new CalculateService();
        var result = calculate.Result(maxNumber);

        result.Should().Be(expected);
    }
    
    [Test]
    [TestCase(5, "1,2,Fizz,4,Buzz")]
    public void buzz_case_when_number_is_divided_by_5(int maxNumber, string expected)
    {
        var calculate = new CalculateService();
        var result = calculate.Result(maxNumber);

        result.Should().Be(expected);
    }
    
}