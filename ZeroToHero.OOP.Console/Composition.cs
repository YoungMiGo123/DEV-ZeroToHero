namespace ZeroToHero.OOP.Console
{
    using System;

    public class Composition
    {
        public class Engine
        {
            public void TurnOff()
            {
                Console.WriteLine("Engine turned off.");
            }
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
            public void StopCar()
            {
                _engine.TurnOff();
                Console.WriteLine("Car stopped.");
            }
        }

        public static void BuildExample()
        {
            var myCar = new Car();
            myCar.StartCar();
            myCar.StopCar();
        }
    }

}
