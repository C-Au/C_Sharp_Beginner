Expense account = new Expense("Food", 500);
Console.WriteLine($"{account.Owner}'s balance: {account.Balance}");
public class Expense
{
    public string Category;

    public DateOnly DateTime;

    private float _amount;

    public float Amount
    {
        get { return _amount; }
        set
        {
            if (value < 0)
            {
                _amount = 0;
            }
            else
            {
                _amount = value;
            }
        }
    }
}
