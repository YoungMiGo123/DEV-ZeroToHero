namespace ZeroToHero.BestPractices.Console.SOLID.DependecyInjection.After;
using System;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public ProductType Type { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price:C}, Description: {Description}, Type: {Type}";
    }
}
