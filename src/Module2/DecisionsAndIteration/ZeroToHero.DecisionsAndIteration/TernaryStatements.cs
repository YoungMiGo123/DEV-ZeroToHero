namespace ZeroToHero.DecisionsAndIteration
{
    public class TernaryStatements
    {
        public static void TemperatureExample(int temperature)
        {
            string weather = (temperature > 20) ? "Warm" : "Cool";
            Console.WriteLine($"The weather is {weather}");
        }

        public static void VoteEligibilityExample(int age)
        {
            string message = age >= 18 ? "You are eligible to vote." : "You are not eligible to vote yet.";
            Console.WriteLine(message);
        }
        public static void Build()
        {
            Console.WriteLine("\n-----Start Ternary Statements Examples -----\n");
            TemperatureExample(25);
            VoteEligibilityExample(22);
            Console.WriteLine("\n-----End Ternary Statements Examples -----\n");
        }
    }

}
