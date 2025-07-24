namespace BankAccountKata;

public class BankAccountModel
{
    private readonly List<Transaction> _transactions = [];
    private decimal Balance { get; set; }

    public void CreateAccount()
    {
        Balance = 0;
    }

    public decimal GetBalance()
    {
        return Balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }

        Balance += amount;

        var transaction = new Transaction(DateTime.Now, amount, Balance, TransactionType.Deposit);
        _transactions.Add(transaction);
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InvalidOperationException("Not enough balance to withdraw.");
        }

        Balance -= amount;

        var transaction = new Transaction(DateTime.Now, amount, Balance, TransactionType.Withdrawal);
        _transactions.Add(transaction);
    }

    public List<Transaction> GetTransactions()
    {
        return _transactions;
    }
}