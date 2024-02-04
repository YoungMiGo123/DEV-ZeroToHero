namespace ZeroToHero.OOP.Console
{
    using System;

    public class Delegation
    {
        public class Worker
        {
            public void PerformTask()
            {
                Console.WriteLine("Worker is performing the task.");
            }
        }

        public class Delegator
        {
            private Worker _worker => new();

            public void DelegateTask()
            {
                Console.WriteLine("Delegator is delegating the task.");
                _worker.PerformTask();
            }
        }

        public static void BuildExample()
        {
            var delegator = new Delegator();
            delegator.DelegateTask();
        }
    }

}
