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
    
    // - Account remembers deposit transactions
    // - Account remembers withdrawal transactions  
    // - Transactions include timestamp
    // - Transactions include amount and type
    // Date       | Amount | Balance
    // 14/01/2012 | -500   | 2500
    // 13/01/2012 | 2000   | 3000
    // 10/01/2012 | 1000   | 1000
    
    [Test]
    public void deposit_and_withdraw_transactions_are_recorded()
    {
        _bankAccountModel.Deposit(100);
        _bankAccountModel.Withdraw(50);
        
        var transactions = _bankAccountModel.GetTransactions();
        
        transactions.Should().HaveCount(2);
        transactions[0].Amount.Should().Be(100);
        transactions[0].Type.Should().Be(TransactionType.Deposit);
        transactions[1].Amount.Should().Be(50);
        transactions[1].Type.Should().Be(TransactionType.Withdrawal);
    }
}