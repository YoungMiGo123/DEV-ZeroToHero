namespace ZeroToHero.DecisionsAndIteration
{
    public enum Color {
         Red,
         Green, 
         Blue
    }
    public class SwitchStatements
    {
        public static void OldSwitchExample(string dayOfWeek)
        {
            switch (dayOfWeek.ToLower())
            {
                case "monday":
                    Console.WriteLine("It's the start of the week.");
                    break;
                case "friday":
                    Console.WriteLine("It's almost the weekend!");
                    break;
                default:
                    Console.WriteLine("It's a regular day.");
                    break;
            }
        }

        public static void NewSwitchExample(Color color)
        {
            var message = color switch
            {
                Color.Red => "Red symbolizes passion.",
                Color.Blue => "Blue is calming and tranquil.",
                _ => "This color has its own charm."
            };
            
            Console.WriteLine(message);  
        }
        public static void Build()
        {
            Console.WriteLine("\n-----Start SwitchStatements Examples -----\n");
            OldSwitchExample("monday");
            NewSwitchExample(Color.Red);
            Console.WriteLine("\n-----End SwitchStatements Examples -----\n");

        }

    }

}
