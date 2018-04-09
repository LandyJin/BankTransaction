using System;

public class Transfer
{
    private Account _toAccount;
    private Account _fromAccount;
    private decimal _amount;
    private Withdraw _theWithdraw;
    private Deposit _theDeposit;

    public bool Success
    {
        get; set;
    }

    public Transfer(Account fromAccount, Account toAccount, decimal amount)
    {
        _toAccount = toAccount;
        _fromAccount = fromAccount;
        _amount = amount;
    }

    public bool PerformTransfer()
    {
        _theWithdraw = new Withdraw(_fromAccount, _amount);
        _theWithdraw.Execute();
        Success = _theWithdraw.Success;
        if(Success)
        {
            _theDeposit = new Deposit(_toAccount, _amount);
            _theDeposit.Execute();
            Success = _theDeposit.Success;
            if(!Success)
            {
                _theDeposit = new Deposit(_fromAccount, _amount);
                _theDeposit.Execute();

            }
        }
        return Success;
    }

    public void Print()
    {
        if (Success)
        {
            Console.WriteLine("Transferred $ " + _amount + " from Jake's Account to Landy's Account");
            Console.Write("    ");
            _theWithdraw.Print();
            Console.Write("    ");
            _theDeposit.Print();

        }
        else
        {
            Console.WriteLine("Sorry, you transaction was unsucced");
        }
    }
    public void Execute()
    {
        PerformTransfer();

    }
}