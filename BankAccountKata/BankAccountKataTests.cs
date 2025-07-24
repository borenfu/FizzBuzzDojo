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
    
    [Test]
    public void deposit_negative_amount_throw_argument_exception()
    {
        var act = () => _bankAccountModel.Deposit(-1);
        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void withdraw_enough_balance()
    {
        _bankAccountModel.Deposit(50);
        _bankAccountModel.Withdraw(50);
        _bankAccountModel.GetBalance().Should().Be(0);
    }

    [Test]
    public void withdraw_not_enough_balance_throw_exception()
    {
        _bankAccountModel.Deposit(50);
        var act = () => _bankAccountModel.Withdraw(100);
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Not enough balance to withdraw.");
    }
}