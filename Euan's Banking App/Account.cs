public abstract class Account
{
    //encapsulation
    private readonly string _accountNumber;
    private readonly string _accountHolder;
    private readonly List<string> _transactionHistory;
    private decimal _balance;
    
    public Account(string accountNumber, string accountHolder, decimal balance)
    {
        _accountNumber = accountNumber;
        _accountHolder = accountHolder;
        _balance = balance;
        _transactionHistory = new List<string>();//initialises the list
    }

    public string AccountNumber => _accountNumber; 
    public string AccountHolder => _accountHolder;
    public decimal Balance
    {
        get => _balance;
        protected set => _balance = value;
    }
    public List<string> TransactionHistory => _transactionHistory;

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
        AddTransaction($"Deposited: {amount}");
    }

    public virtual void Withdraw(decimal amount)
    {
        Balance -= amount;
    }

    public virtual void DisplayBalance()
    {
        Console.WriteLine($"Current Balance is {Balance}");
    }

    public void AddTransaction(string transaction)
    {
        TransactionHistory.Add($"{DateTime.Now}: {transaction}");
    }

    public void PrintTransactionHistory()
    {
        foreach (var transaction in TransactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }
}
