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
    [TestCase(1, 1, "1")]
    [TestCase(1, 2, "1,2")]
    public void normal_case_when_number_is_not_altered(int startNumber, int endNumber, string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(1, 3, "1,2,FizzFizz")]
    [TestCase(1, 4, "1,2,FizzFizz,4")]
    public void fizz_case_when_number_is_divided_by_3(int startNumber, int endNumber, string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(1, 5, "1,2,FizzFizz,4,BuzzBuzz")]
    public void buzz_case_when_number_is_divided_by_5(int startNumber, int endNumber, string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(1, 15, "1,2,FizzFizz,4,BuzzBuzz,Fizz,7,8,Fizz,Buzz,11,Fizz,Fizz,14,FizzBuzzBuzz")]
    public void fizzbuzz_case_when_number_is_divided_by_3_and_5(int startNumber, int endNumber, string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(10, 13, "Buzz,11,Fizz,Fizz")]
    public void fizz_case_when_number_contains_3(int startNumber, int endNumber, string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(50, 52, "BuzzBuzz,FizzBuzz,Buzz")]
    public void fizz_case_when_number_contains_5(int startNumber, int endNumber, string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(53, 55, "FizzBuzz,FizzBuzz,BuzzBuzz")]
    public void fizz_case_when_number_contains_3_and_5(int startNumber, int endNumber, string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(45, 45, "FizzBuzzBuzz")]
    public void fizz_case_when_number_divide_3_and_contains_5(int startNumber, int endNumber, string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(30, 30, "FizzFizzBuzz")]
    public void fizz_case_when_number_divide_5_and_contains_3(int startNumber, int endNumber, string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }

    [Test]
    [TestCase(34, 35, "Fizz,FizzBuzzBuzz")]
    public void fizzBuzzBuzz_case_when_number_divided_5_and_contains_3_and_5(int startNumber, int endNumber,
        string expected)
    {
        var result = _calculate.Result(startNumber, endNumber);

        result.Should().Be(expected);
    }
}