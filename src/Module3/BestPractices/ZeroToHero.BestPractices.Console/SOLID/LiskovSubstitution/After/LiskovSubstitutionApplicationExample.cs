

namespace ZeroToHero.BestPractices.Console.SOLID.LiskovSubstitution.After;

using System;


public abstract class BankAccount
{
    public decimal Balance { get; protected set; }

    public abstract void Deposit(decimal amount);

    public abstract void Withdraw(decimal amount);

}

public class SavingsAccount : BankAccount
{
    public override void Deposit(decimal amount)
    {
        decimal interestRate = 0.05m;
        Balance += amount * interestRate;
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount >= 100) // Savings account requires minimum balance of 100
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Cannot withdraw due to minimum balance of 100 requirement");
        }
    }

}

public class TaxFreeSavingsAccount : BankAccount
{
    public override void Deposit(decimal amount)
    {
        decimal interestRate = 0.10m;
        Balance += amount * interestRate;
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount >= 0)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Cannot withdraw due to minimum balance of 0 requirement");
        }
    }
}

public abstract class SpecializedBankAccount
{
    public decimal Balance { get; protected set; }

    public abstract void Deposit(decimal amount);

    public abstract void Transfer(decimal amount, BankAccount toAccount);
}

public class FixedDepositAccount : SpecializedBankAccount
{
    public override void Deposit(decimal amount)
    {
        decimal interestRate = 0.15m;
        Balance += amount * interestRate;
    }

    public override void Transfer(decimal amount, BankAccount toAccount)
    {
        if (Balance - amount >= 0)
        {
            Balance -= amount;
            toAccount.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Cannot transfer due to minimum balance of 0 requirement");
        }
    }
}

public class LiskovSubstitutionApplicationExample
{
    public static void Build()
    {
        Console.WriteLine("LiskovSubstitutionApplicationExample\n");

        BankAccount account = new SavingsAccount();
        account.Deposit(500);
        account.Withdraw(200);

        account = new TaxFreeSavingsAccount();
        account.Deposit(500);
        account.Withdraw(200);

        var specializedAccount = new FixedDepositAccount();
        specializedAccount.Deposit(500);
        specializedAccount.Transfer(200, account);
    }
}
