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

    public Expense(string Category, float balance)
    {
        Category = category;
        Balance = balance;
    }
}
