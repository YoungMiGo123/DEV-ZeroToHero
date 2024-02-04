namespace ZeroToHero.Collections.Console.Dictionary
{
    public class Employee
    {
        public string Name { get; }
        public int Age { get; }
        public string Role { get; }

        public Employee(string name, int age, string role)
        {
            Name = name;
            Age = age;
            Role = role;
        }
    }
}
