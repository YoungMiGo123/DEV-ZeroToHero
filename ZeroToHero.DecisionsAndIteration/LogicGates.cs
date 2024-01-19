namespace ZeroToHero.DecisionsAndIteration
{
    public class LogicGates
    {
        public static void BooleanLogicExample(bool condition1, bool condition2)
        {
            // AND gate
            bool resultAnd = condition1 && condition2;
            Console.WriteLine($"AND gate result: {resultAnd}");

            // OR gate
            bool resultOr = condition1 || condition2;
            Console.WriteLine($"OR gate result: {resultOr}");

            // NOT gate
            bool resultNot = !condition1;
            Console.WriteLine($"NOT gate result: {resultNot}");
        }
        public static void Build()
        {
            Console.WriteLine("\n-----Start LogicGates Examples -----\n");
            BooleanLogicExample(true, false);
            Console.WriteLine("\n-----End LogicGates Examples -----\n");

        }
    }
}
