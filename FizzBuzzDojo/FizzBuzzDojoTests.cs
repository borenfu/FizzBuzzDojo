using FluentAssertions;

namespace FizzBuzzDojo;

public class FizzBuzzDojoTests
{
    private CalculateService _calculate;

    [SetUp]
    public void SetUp()
    {
        _calculate = new CalculateService();
    }

    [Test]
    [TestCase(1, "1")]
    [TestCase(2, "1,2")]
    public void normal_case_when_number_is_not_altered(int maxNumber, string expected)
    {
        var result = _calculate.Result(maxNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(3, "1,2,Fizz")]
    [TestCase(4, "1,2,Fizz,4")]
    public void fizz_case_when_number_is_divided_by_3(int maxNumber, string expected)
    {
        var result = _calculate.Result(maxNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(5, "1,2,Fizz,4,Buzz")]
    public void buzz_case_when_number_is_divided_by_5(int maxNumber, string expected)
    {
        var result = _calculate.Result(maxNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(15, "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz")]
    public void fizzbuzz_case_when_number_is_divided_by_3_and_5(int maxNumber, string expected)
    {
        var result = _calculate.Result(maxNumber);

        result.Should().Be(expected);
    }
}