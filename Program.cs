using System;
using SplashKitSDK;
public enum MenuOption
{
    Withdraw,
    Deposit,
    Transfer,
    Print,
    Quit
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to my bank :)");
        Console.WriteLine("");
        MenuOption userSelection;
        Account account = new Account("Landy",1000);
        Account jakeAccount = new Account("Jake's Account",2000);
        do
        {
            userSelection = ReadUserOption();
        
            switch(userSelection)
            {

                case MenuOption.Withdraw: 
                    Console.WriteLine("You have chosen 1. Withdraw");
                    DoWithdraw(account);
                    break;
                case MenuOption.Deposit:
                    Console.WriteLine("You have chosen 2. Deposit");
                    DoDeposit(account);
                    break;
                case MenuOption.Transfer:
                    Console.WriteLine("You have chosen 3. Transfer");
                    DoTransfor(jakeAccount,account);
                    break;
                case MenuOption.Print:
                    Console.WriteLine("You have chosen 4. Print");
                    DoPrint(account);
                    break;
                case MenuOption.Quit:
                    Console.WriteLine("You have chosen 5. Quit");
                    Console.WriteLine("Quit...");
                    break;
            }
        }while(Convert.ToInt32(userSelection) != 4);

    }

    private static MenuOption ReadUserOption()
    {
        int option;
        
        do
        {
            Console.WriteLine("1. Withdraw  2. Deposit 3. Transfer from Jake's account to your account  4. Print  5. Quit");
            Console.WriteLine("Choose an option [1-5]");

            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                option = -1; 
            }
            
            
        } while(option<1 || option>5);

        return (MenuOption)(option-1);
    }
    public static void DoWithdraw(Account account)
    {
        Console.WriteLine("How much you would like to withdraw?");
        Withdraw withdraw = new Withdraw(account, Convert.ToDecimal(Console.ReadLine()));
        withdraw.Execute();
        withdraw.Print();
    } 

    public static void DoDeposit(Account account)
    {
        
        Console.WriteLine("How much you would like to deposit?");
        Deposit deposit = new Deposit(account, Convert.ToDecimal(Console.ReadLine()));
        deposit.Execute();
        deposit.Print();
    } 
    public static void DoTransfor(Account fromAccount, Account toAccount)
    {
        
        Console.WriteLine("How much you would like to transfer?");
        Transfer transfer = new Transfer(fromAccount, toAccount, Convert.ToDecimal(Console.ReadLine()));
        transfer.Execute();
        transfer.Print();
    } 
    private static void DoPrint(Account account)
    {
        account.Print();
    }
}



