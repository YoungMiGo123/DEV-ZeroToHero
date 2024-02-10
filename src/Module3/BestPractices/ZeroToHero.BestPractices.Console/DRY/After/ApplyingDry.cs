
namespace ZeroToHero.BestPractices.Console.DRY.After;

using System;
public class Calculator
{
    private int PerformOperation(int a, int b, Func<int, int, int> operation, string operationName)
    {
        Console.WriteLine($"{operationName} {a} and {b}");
        return operation(a, b);
    }

    public int Add(int a, int b)
    {
        return PerformOperation(a, b, (x, y) => x + y, "Adding");
    }

    public int Subtract(int a, int b)
    {
        return PerformOperation(a, b, (x, y) => x - y, "Subtracting");
    }

    public int Multiply(int a, int b)
    {
        return PerformOperation(a, b, (x, y) => x * y, "Multiplying");
    }
}
public class ApplyingDry
{
    public static void Build()
    {
        var calculator = new Calculator();

        int result1 = calculator.Add(5, 3);
        Console.WriteLine($"Result: {result1}");

        int result2 = calculator.Subtract(10, 7);
        Console.WriteLine($"Result: {result2}");

        int result3 = calculator.Multiply(4, 6);
        Console.WriteLine($"Result: {result3}");
    }
}
