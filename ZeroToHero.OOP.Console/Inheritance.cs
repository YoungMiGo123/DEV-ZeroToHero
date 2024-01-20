namespace ZeroToHero.OOP.Console
{
    using System;

    public class Inheritance
    {
        public class Animal
        {
            public void Eat()
            {
                Console.WriteLine("Animal is eating.");
            }
        }

        public class InheritedAnimal : Animal
        {
            public void Sleep()
            {
                Console.WriteLine("Animal is sleeping.");
            }
        }

        public static void BuildExample()
        {
            var dog = new InheritedAnimal();
            dog.Eat();
            dog.Sleep();
        }
    }

}
