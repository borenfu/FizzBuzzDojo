using FluentAssertions;

namespace BankAccountKata;

public class BankAccountKataTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void create_account_and_balance_is_0()
    {
        var bankAccountModel = new BankAccountModel();
        bankAccountModel.CreateAccount();
        bankAccountModel.GetBalance().Should().Be(0);
    }
    
    [Test]
    public void deposit_100_balance_100()
    {
        var bankAccountModel = new BankAccountModel();
        bankAccountModel.CreateAccount();
        bankAccountModel.Deposit(100);
        bankAccountModel.GetBalance().Should().Be(100);
    }
}