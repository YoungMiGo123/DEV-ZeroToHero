
/*
//Example 1: Simple Function with Return Type

int Add(int a, int b)
{
    return a + b;
}

Console.WriteLine($"Sum: {Add(5, 7)}");

*/

/*
 // Example 2: Void Method with Parameters
 void Greet(string name)
 {
     Console.WriteLine($"Hello, {name}!");
 }
 var names = new List<string> { "Alice", "Bob", "Charlie" , "Lee"};

foreach (var name in names)
{
    Greet(name);
}
*/



/*
 //Example 3: Async Method with Task
async Task<int> DelayedSumAsync(int a, int b)
{
    await Task.Delay(2000); // Simulating an asynchronous operation
    return a + b;
}

Console.WriteLine($"Delayed Sum: {await DelayedSumAsync(3, 4)}");
*/



/*
//Example 4: Recursive Function
int Factorial(int n)
{
    if (n == 0 || n == 1)
        return 1;
    else
        return n * Factorial(n - 1);
}

Console.WriteLine($"Factorial of 5: {Factorial(5)}");
// 5 * 4 * 3 * 2 * 1 = 120
*/

/*
// Example 5: Extension Method

string reversed = "Hello".Reverse();
Console.WriteLine($"Reversed: {reversed}");

public static class StringExtensions
{
    public static string Reverse(this string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
*/




/*
 // Example 6: List of strings

List<string> GenerateFruits()
{
    List<string> fruits = new List<string>
    {
        "Apple",
        "Banana",
        "Orange",
        "Grapes",
        "Mango"
    };
    return fruits;
}

Console.WriteLine($"Fruits: {string.Join(", ", GenerateFruits())}");
*/ 
 



char[] GetAlphabet()
{
    char[] alphabet = new char[26];
    char currentChar = 'A';

    for (int i = 0; i < 26; i++)
    {
        alphabet[i] = currentChar;
        currentChar++;
    }

    return alphabet;
}

Console.WriteLine($"Alphabet: {string.Join(", ", GetAlphabet())}");
 
