

namespace ZeroToHero.BestPractices.Console.SOLID.LiskovSubstitution.Before;

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
        decimal interestRate = 0.05m;
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
public class FixedDepositAccount : BankAccount
{
    public override void Deposit(decimal amount)
    {
        decimal interestRate = 0.1m;
        Balance += amount * interestRate;
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine("Cannot withdraw from fixed deposit account");
    }
}
public class LiskovSubstitutionViolationExample
{
    public static void Build()
    {
        Console.WriteLine("LiskovSubstitutionViolationExample\n");

        BankAccount account = new SavingsAccount();
        account.Deposit(500);
        account.Withdraw(200);

        account = new TaxFreeSavingsAccount();
        account.Deposit(500);
        account.Withdraw(200);

        account = new FixedDepositAccount();
        account.Deposit(500);
        account.Withdraw(200);
    }
}
