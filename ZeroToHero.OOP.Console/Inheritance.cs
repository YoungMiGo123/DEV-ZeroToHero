namespace ZeroToHero.OOP.Console
{
    using System;

    public class Inheritance
    {
        public class Animal
        {
            public virtual void Eat()
            {
                Console.WriteLine("Animal is eating.");
            }
        }

        public class Dog : Animal
        {
            public void Bark()
            {
                Console.WriteLine("Dog is barking");
            }
            public override void Eat()
            {
                Console.WriteLine("Eating chicken");
            }
        }
        public class Fish : Animal
        {
            public void Swim()
            {
                Console.WriteLine("Fish is swimming.");
            }
            public override void Eat()
            {
                Console.WriteLine("Eating plankton");
            }
        }

        public static void BuildExample()
        {
            var animal = new Animal();
            animal.Eat();
            
            var dog = new Dog();
            dog.Eat();
            dog.Bark();

            var fish = new Fish();
            fish.Eat();
            fish.Swim();
        }
    }

}
