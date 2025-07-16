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
        var calculate = new Calculate();
        var result = calculate.Result();

        result.Should().Be("1");
    }
}

public class Calculate
{
    public string Result()
    {
        return "1";
    }
}