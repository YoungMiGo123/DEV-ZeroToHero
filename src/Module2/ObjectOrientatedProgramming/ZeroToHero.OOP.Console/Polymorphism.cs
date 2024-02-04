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
        public class ChessPiece 
        {
            public virtual void Move() => Console.WriteLine("Chess piece moves.");
        }
        public class King : ChessPiece
        {
            public override void Move()
            {
                Console.WriteLine("King moves one square in any direction.");
            }
        }
        public class Queen : ChessPiece
        {
            public override void Move()
            {
                Console.WriteLine("Queen moves diagonally, horizontally, or vertically any number of squares.");
            }
        }
        public class Bishop : ChessPiece
        {
            public override void Move()
            {
                Console.WriteLine("Bishop moves diagonally any number of squares.");
            }
        }
        public class Knight : ChessPiece
        {
            public override void Move()
            {
                Console.WriteLine("Knight moves in an ‘L’ shape’.");
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
            Shape genericShape = new();
            Shape circle = new Circle();
            Shape rectangle = new Rectangle();

            DisplayShapeInfo(genericShape);
            DisplayShapeInfo(circle);
            DisplayShapeInfo(rectangle);


            var chessPieces = new ChessPiece[]
            {
                new King(),
                new Queen(),
                new Bishop(),
                new Knight()
            };
            foreach (var chessPiece in chessPieces)
            {
                chessPiece.Move();
            }
        }

        private static void DisplayShapeInfo(Shape shape)
        {
            shape.DisplayInfo();
        }
    }

}
