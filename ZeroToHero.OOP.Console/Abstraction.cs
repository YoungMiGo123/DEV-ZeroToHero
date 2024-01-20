using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroToHero.OOP.Console
{
    using System;

    public class Abstraction
    {
        public interface IShape
        {
            void DisplayInfo();
        }
        public abstract class AbstractShape
        {
            public abstract void DisplayInfo();
        }

        public class ConcreteShape : IShape
        {
            public void DisplayInfo()
            {
                Console.WriteLine("This is a concrete example of abstraction.");
            }
        }

        public class Circle : IShape
        {
            public void DisplayInfo()
            {
                Console.WriteLine("This is a circle."); 
            }
        }

        public static void BuildExample()
        {
            IShape shape = new ConcreteShape();

            shape.DisplayInfo();

            shape = new Circle();
            
            shape.DisplayInfo();
        }
    }
}
