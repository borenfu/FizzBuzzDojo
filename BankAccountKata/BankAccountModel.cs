using System.Text;

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

    public string GetStatement()
    {
        var transactions = GetTransactions();
        transactions.Reverse();
        
        var statement = new StringBuilder();
        statement.AppendLine("Date       | Amount | Balance");
        
        foreach (var transaction in transactions)
        {
            statement.AppendLine(transaction.Timestamp.ToString("yyyy/MM/dd") + " | "
                + transaction.Amount.ToString() + " | " 
                + transaction.Balance.ToString());
        }
        
        return statement.ToString();
    }
}