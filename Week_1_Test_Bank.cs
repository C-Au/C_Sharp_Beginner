BankAccount account = new BankAccount("Colin", -500);
Console.WriteLine($"{account.Owner}'s balance: {account.Balance}");

// account.Withdraw(10000);
// account.Deposit(-50);

public class BankAccount
{
    public string Owner;
    private float _balance;

    public float Balance
    {
        get { return _balance; }
        set
        {
            if (value < 0)
            {
                _balance = 0;
            }
            else
            {
                _balance = value;
            }
        }
    }

    public BankAccount(string owner, float balance)
    {
        Owner = owner;
        Balance = balance;
    }

    public void Deposit(float amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("amount cannot be a negative value.");
            return;
        }

        Balance += amount;
        Console.WriteLine($"New balance is: {Balance}");
    }

    public void Withdraw(float amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("amount cannot be a negative value.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("amount cannot be greater than the balance.");
            return;
        }

        Balance -= amount;
        Console.WriteLine($"New balance is: {Balance}");
    }
}
