
namespace ZeroToHero.BestPractices.Console.KISS.After;

using System;

public class ApplyingKiss
{
    // GOOD practice: Keeping it simple
    public static int CalculateArea(int length, int width)
    {
        return length * width;
    }
    //GOOD Practice: Keeping it simple
    public static void PrintNumbersLoop(int number)
    {
        for (int i = 0; i <= number; i++)
        {
            Console.WriteLine(i);
        }
    }
    public static void Build()
    {
        var area = CalculateArea(10, 20);
        Console.WriteLine(area);
        PrintNumbersLoop(10);
    }
}
