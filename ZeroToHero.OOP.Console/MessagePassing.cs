namespace ZeroToHero.OOP.Console
{
    using System;

    public class MessagePassing
    {
        public class Messenger
        {
            public void DisplayMessage(string message)
            {
                Console.WriteLine($"Received message: {message}");
            }
        }

        public static void BuildExample()
        {
            var messenger = new Messenger();
            messenger.DisplayMessage("Hello from another class!");
        }
    }

}
