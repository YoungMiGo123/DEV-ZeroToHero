namespace ZeroToHero.OOP.Console
{
    using System;

    public class Polymorphism
    {
        public class Shape
        {
            public virtual void DisplayInfo()
            {
                Console.WriteLine("This is a generic shape.");
            }
        }

        public class Circle : Shape
        {
            public override void DisplayInfo()
            {
                Console.WriteLine("This is a circle.");
            }
        }

        public class Rectangle : Shape
        {
            public override void DisplayInfo()
            {
                Console.WriteLine("This is a rectangle.");
            }
        }

        public static void BuildExample()
        {
            Shape genericShape = new Shape();
            Shape circle = new Circle();
            Shape rectangle = new Rectangle();

            DisplayShapeInfo(genericShape);
            DisplayShapeInfo(circle);
            DisplayShapeInfo(rectangle);
        }

        private static void DisplayShapeInfo(Shape shape)
        {
            shape.DisplayInfo();
        }
    }

}
