using FluentAssertions;

namespace BankAccountKata;

public class BankAccountKataTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void deposit_case_when_account_is_created_balance_0()
    {
        var bankAccountModel = new BankAccountModel();
        bankAccountModel.StartAccount();
        bankAccountModel.balance.Should().Be(0);
    }
}

public class BankAccountModel
{
    public decimal balance { get; set; }

    public void StartAccount()
    {
        balance = 0;
    }
}