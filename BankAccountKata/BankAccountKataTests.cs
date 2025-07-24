using FluentAssertions;

namespace BankAccountKata;

public class BankAccountKataTests
{
    private BankAccountModel _bankAccountModel;

    [SetUp]
    public void Setup()
    {
        _bankAccountModel = new BankAccountModel();
        _bankAccountModel.CreateAccount();
    }

    [Test]
    public void create_account_and_balance_is_0()
    {
        _bankAccountModel.GetBalance().Should().Be(0);
    }

    [Test]
    public void deposit_100_balance_100()
    {
        _bankAccountModel.Deposit(100);
        _bankAccountModel.GetBalance().Should().Be(100);
    }
}