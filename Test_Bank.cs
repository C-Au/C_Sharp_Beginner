BankAccount account = new BankAccount("Colin", -500);
Console.WriteLine($"{account.Owner}'s balance: {account.Balance}");

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
}
