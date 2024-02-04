namespace ZeroToHero.Collections.TodoApp
{
    public class InputReader
    {
        public static string ReadUserInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
