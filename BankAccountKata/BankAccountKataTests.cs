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
    //
    // Date       | Amount | Balance
    // 14/01/2012 | -500   | 2500
    // 13/01/2012 | 2000   | 3000
    // 10/01/2012 | 1000   | 1000
    [Test]
    public void print_statement()
    {
        _bankAccountModel.Deposit(100);
        _bankAccountModel.Withdraw(50);
        _bankAccountModel.Deposit(250);
        _bankAccountModel.Withdraw(110);
        var statement = _bankAccountModel.GetStatement();
        var splits = statement.Split('\n');
        splits.Should().HaveCount(6);
        
        StatementShouldBe(splits[4], 100, 100);
        StatementShouldBe(splits[3], 50, 50);
        StatementShouldBe(splits[2], 250, 300);
        StatementShouldBe(splits[1], 110, 190);

    }

    private static void StatementShouldBe(string line, decimal amount, decimal balance)
    {
        var details = line.Split('|');
        details.Should().HaveCount(3);
        DateTime.Parse(details[0]).Should().Be(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
        decimal.Parse(details[1].Trim()).Should().Be(amount);
        decimal.Parse(details[2].Trim()).Should().Be(balance);
    }
}