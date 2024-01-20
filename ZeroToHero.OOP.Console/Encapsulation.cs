namespace ZeroToHero.OOP.Console
{
    using System;

    public class Encapsulation
    {
        public class EncapsulatedClass
        {
            private string data;

            public void SetData(string newData)
            {
                data = newData;
            }

            public void DisplayData()
            {
                Console.WriteLine($"Data: {data}");
            }
        }

        public static void BuildExample()
        {
            var example = new EncapsulatedClass();
            example.SetData("Encapsulation Example");
            example.DisplayData();
        }
    }

}
