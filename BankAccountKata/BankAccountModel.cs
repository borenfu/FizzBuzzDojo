namespace BankAccountKata;

public class BankAccountModel
{
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
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InvalidOperationException("Not enough balance to withdraw.");
        }

        Balance -= amount;
    }

    public List<Transaction> GetTransactions()
    {
        throw new NotImplementedException();
    }
}