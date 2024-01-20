using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroToHero.OOP.Console
{
    using System;

    public class Abstraction
    {
        public abstract class AbstractShape
        {
            public abstract void DisplayInfo();
        }

        public class ConcreteShape : AbstractShape
        {
            public override void DisplayInfo()
            {
                Console.WriteLine("This is a concrete example of abstraction.");
            }
        }

        public static void BuildExample()
        {
            var example = new ConcreteShape();
            example.DisplayInfo();
        }
    }
}
