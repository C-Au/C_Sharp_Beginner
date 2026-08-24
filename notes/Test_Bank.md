# Test_Bank — What This Code Does

This file is a tiny practice program about a bank account. In everyday terms: it creates an account for a person, tries to put money in it, and then prints how much is there.

## The big picture

Imagine a paper account card:

- It has a name on it (who owns the account).
- It has a balance (how much money is in it).
- The bank has a rule: **you cannot have a negative balance**. If someone tries to open an account with a negative amount, the bank just sets the balance to **$0**.

That is exactly what this program does.

## Line by line (the part that actually runs)

```csharp
BankAccount account = new BankAccount("Colin", -500);
Console.WriteLine($"{account.Owner}'s balance: {account.Balance}");
```

1. **Create a new account** named Colin, and try to start it with **-500**.
2. **Print a sentence** like: `Colin's balance: 0`

Why `0` and not `-500`? Because later in the class, any negative amount is rejected and replaced with zero.

The `$"..."` text is just a convenient way to build a sentence and drop values into it. `{account.Owner}` becomes `Colin`. `{account.Balance}` becomes the current money amount.

## The `BankAccount` class — the blueprint

A **class** is a recipe. It does not create a real account by itself. It only describes what every account should look like and how it should behave.

```csharp
public class BankAccount
```

Think of this as: “Here is the official form for a bank account.”

### The name field

```csharp
public string Owner;
```

- `Owner` is the name on the account.
- `public` means other code is allowed to read or change it freely.
- `string` means it is text, like `"Colin"`.

This is like writing the customer’s name on the front of the card. Anyone with the card can scribble over the name. That is simple, but not very protected.

### The hidden money amount

```csharp
private float _balance;
```

- `_balance` is the real number stored in memory.
- `private` means **only this class** can touch it directly.
- `float` is a number that can have a decimal point, like `100.50`.

The underscore at the start (`_balance`) is just a common naming habit for a private “behind the scenes” value.

This is the locked drawer. Customers should not reach into it themselves.

### The public `Balance` property — the teller window

```csharp
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
```

A **property** is a controlled doorway to private data.

- **`get`** is “please tell me the balance.” It simply returns whatever is in `_balance`.
- **`set`** is “please change the balance.” Before it accepts the new number, it checks a rule.

`value` is the new amount someone is trying to assign. For example, if the program says `Balance = -500`, then `value` is `-500`.

The rule is:

- If the new amount is less than 0, store **0** instead.
- Otherwise, store the amount as given.

So the program never actually keeps a negative balance. It silently corrects it.

That is why creating the account with `-500` still prints `0`.

### The constructor — opening a new account

```csharp
public BankAccount(string owner, float balance)
{
    Owner = owner;
    Balance = balance;
}
```

A **constructor** is the “open this account” step. It runs automatically when you write `new BankAccount(...)`.

It takes two pieces of information:

1. The owner’s name
2. The starting balance

Then it fills them in:

- `Owner = owner;` writes the name onto the account.
- `Balance = balance;` goes through the teller window, **not** straight into the locked drawer.

That last point matters. Because it uses `Balance` (the property) instead of `_balance` (the private field), the “no negatives” rule still applies when the account is first created.

If the constructor had said `_balance = balance;`, Colin’s account would have started at `-500`. Using `Balance = balance;` is what forces `-500` to become `0`.

## What happens when you run it

1. C# builds a new `BankAccount` object.
2. The constructor stores `"Colin"` as the owner.
3. The constructor tries to store `-500` as the balance.
4. The `Balance` setter sees that `-500` is negative, so it stores `0`.
5. The program prints Colin’s name and the corrected balance.

Expected output:

```text
Colin's balance: 0
```

## Everyday analogy

Opening this account is like handing a teller a form that says:

- Name: Colin
- Starting deposit: **-500**

The teller looks at the form, says “we do not allow a negative starting amount,” writes **0** on the official record, and then reads that official record back to you.

## A few beginner takeaways

- **Class** = the blueprint.
- **Object / instance** = one real account made from that blueprint (`account`).
- **Field** = stored data (`Owner`, `_balance`).
- **Property** = a safe way to read or change data, with rules.
- **Constructor** = the setup that happens when a new object is created.
- **`public` vs `private`** = “anyone can touch this” vs “only this class can touch this.”

The most important idea in this file is **data protection**. The program does not just store a number. It guards that number so a bad value cannot sneak in.
