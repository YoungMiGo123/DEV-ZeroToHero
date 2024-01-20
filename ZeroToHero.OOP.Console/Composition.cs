namespace ZeroToHero.OOP.Console
{
    using System;

    public class Composition
    {
        public class Engine
        {
            public void Start()
            {
                Console.WriteLine("Engine started.");
            }
        }

        public class Car
        {
            private Engine _engine = new Engine();

            public void StartCar()
            {
                _engine.Start();
                Console.WriteLine("Car started.");
            }
        }

        public static void BuildExample()
        {
            var myCar = new Car();
            myCar.StartCar();
        }
    }

}
