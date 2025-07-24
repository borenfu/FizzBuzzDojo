namespace BankAccountKata;

public class Transaction
{
    public Transaction(DateTime timestamp, decimal amount, decimal balance, TransactionType type)
    {
        Timestamp = timestamp;
        Amount = amount;
        Type = type;
        Balance = balance;
    }

    public DateTime Timestamp { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public TransactionType Type { get; set; } // "Deposit" or "Withdrawal"
}

public enum TransactionType
{
    None = 0,
    Deposit = 1,
    Withdrawal = 2
}