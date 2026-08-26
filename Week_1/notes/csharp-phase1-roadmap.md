# Phase 1: C# Fundamentals (via JS transfer)
### 3 weeks, ~5-7 hrs/week — console exercises only, no Unity yet

Same format as your JS curriculum: guided discovery, you write the code, I ask questions instead of handing you answers. Each week ends with a small console program that forces you to use everything from that week.

---

## Week 1 — Types, syntax, and OOP core

**Concepts**
- Static typing: `int`, `float`, `double`, `string`, `bool`, `var`
- Classes, constructors, fields vs. properties (`get`/`set`)
- Access modifiers: `public`, `private`, `protected`
- Methods, parameters, return types
- `if/else`, loops (`for`, `foreach`, `while`) — near-identical to JS, quick pass

**Guiding questions to sit with before coding**
- In JS, `let x = 5; x = "hello";` is legal. Why would C# refuse that? What problem is static typing solving that dynamic typing doesn't?
- A JS object literal and a C# class both bundle data + behavior. What's actually different about *how* you create an instance of each?
- Why would a language give you both fields and properties (`get`/`set`) instead of just letting you touch a variable directly? What's the "encapsulation" argument doing for you at scale?

**Exercise: `BankAccount` console app**
Build a class with a balance, owner name, and methods to deposit/withdraw. Withdraw should refuse to overdraw. Print a running log of transactions to the console.
- Constraint: use properties (not public fields) for balance, with a private setter.
- Constraint: make deposit/withdraw actual methods that validate input before mutating state.

This is deliberately close to what "budget category" objects will look like in your actual game later.

---

## Week 2 — Collections, LINQ, interfaces, inheritance

**Concepts**
- `List<T>`, `Dictionary<K,V>`, arrays — the `<T>` generic syntax and why it exists
- LINQ: `.Where()`, `.Select()`, `.OrderBy()`, `.Sum()`, `.FirstOrDefault()`
- Interfaces (`interface IExpense`) vs. abstract classes — when you'd reach for each
- Inheritance: `class RecurringExpense : Expense`
- `foreach` over custom collections

**Guiding questions**
- You've used `.filter()`, `.map()`, `.reduce()` a lot recently in your JS curriculum. Look at LINQ's `.Where()`, `.Select()`, `.Aggregate()` side by side with those — what maps to what? Where does the analogy break down?
- What's the actual difference between "a class that implements an interface" and "a class that inherits from a base class"? If you were modeling `SavingsGoal`, `Expense`, and `Income` for a budgeting game, which relationships are "is-a" (inheritance) and which are "can-do" (interface)?
- `Dictionary<string, float>` — why would you reach for this instead of a `List<Expense>` when tracking category totals?

**Exercise: `ExpenseTracker` console app**
List of expense objects (category, amount, date). Use LINQ to:
- total spend by category
- find the single largest expense
- filter expenses over a threshold
- sort by date

Add an interface `ITaxDeductible` that only some expense types implement, and use it to filter a subset.

---

## Week 3 — async/await, generics, and a bridging mini-project

**Concepts**
- `async`/`await`, `Task` and `Task<T>` — compare directly against your recent Promises/async-await JS unit
- Exception handling: `try/catch`, custom exceptions
- Generic methods (not just generic collections) — writing your own `<T>` method
- Nullable types (`int?`) and why C# cares about "could this be null" more explicitly than JS does

**Guiding questions**
- You just learned `async/await` and error handling in JS. What does `await` actually block on in both languages? Where's the difference between a `Promise` and a `Task`?
- Why might a strongly-typed language need a *separate* nullable syntax (`int?`) instead of just letting any variable be `null`, the way JS does?
- If you wrote a generic method `T FindLargest<T>(List<T> items)`, what constraint would you need to add so the compiler lets you compare items with `>`?

**Exercise: bridging mini-project — "Budget Simulator" (console)**
This is the one that should feel like a rough draft of your actual game's core loop:
- A `Budget` class holding a `List<Category>`, each with a name and monthly limit
- Simulate "days passing" in a loop; each day, randomly generate 0-2 expenses assigned to categories
- If a category goes over budget, throw a custom exception (`BudgetExceededException`) and catch it to print a warning instead of crashing
- Use an `async` method to simulate "saving" the budget state to a (fake, delayed) file write, using `await Task.Delay()` to mimic I/O
- At the end of the simulation, use LINQ to print a summary: total spent, top category, days over budget

If you can build that without me writing code for you, you're genuinely ready for Phase 2 (Unity) — that project touches every concept from all three weeks and structurally resembles what you'll port into `ScriptableObjects` and a `GameManager` later.

---

## How we'll run this
Same as your JS sessions — you write, I question and nudge, no code handed over unless you're properly stuck. Ping me at the start of whichever week you're on and we'll go concept by concept.
