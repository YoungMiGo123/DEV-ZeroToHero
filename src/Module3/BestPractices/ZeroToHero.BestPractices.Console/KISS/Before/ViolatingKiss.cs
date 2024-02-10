
namespace ZeroToHero.BestPractices.Console.KISS.Before;

using System;

public class ViolatingKiss
{
    // BAD practice: Unnecessary complexity
    public static int CalculateArea(int length, int width)
    {
        int area = (length > 0 && width > 0) ? length * width : 0;
        return area;
    }
    // BAD practice: Unnecessary complexity
    public static void PrintNumbersRecursively(int number)
    {
        if (number >= 0)
        {
            PrintNumbersRecursively(number - 1);
            Console.WriteLine(number);
        }
    }

    public static void Build()
    {
        var area = CalculateArea(10, 20);
        Console.WriteLine(area);
        PrintNumbersRecursively(10);
    }
}
