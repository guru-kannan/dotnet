namespace Banking;

public class Account
{
    public decimal Balance { get; private set; }
    public event AccountOperation? UnderBalance;
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine("Deposit successful");
    }
    public void Withdraw(decimal amount)
    {
        if (Balance - amount < 0)
        {
            UnderBalance?.Invoke("Insufficient fund");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine("Withdraw successful");
        }
    }
}
