namespace ZeroToHero.OOP.Console
{
    using System;

    public class ProgramDriver
    {
        public static void Drive()
        {
            Abstraction.BuildExample();
            Console.WriteLine();

            Inheritance.BuildExample();
            Console.WriteLine();

            MessagePassing.BuildExample();
            Console.WriteLine();

            Composition.BuildExample();
            Console.WriteLine();

            Delegation.BuildExample();
            Console.WriteLine();

            Encapsulation.BuildExample();
            Console.WriteLine();

            Polymorphism.BuildExample();
        }
    }

}
