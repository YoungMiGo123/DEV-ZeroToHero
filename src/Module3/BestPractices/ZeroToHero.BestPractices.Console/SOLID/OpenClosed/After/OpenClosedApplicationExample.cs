namespace ZeroToHero.BestPractices.Console.SOLID.OpenClosed.After;

using System;
using System.Collections.Generic;
using ZeroToHero.BestPractices.Console.SOLID.OpenClosed.Before;

public enum ProductType
{
    Electronics,
    Clothing
}
public interface IDiscountCalculator
{
    ProductType Type { get; set; }
    decimal CalculateDiscount(Product product);
}

public class ElectronicsDiscountCalculator : IDiscountCalculator
{
    public ProductType Type { get; set; } = ProductType.Electronics;
    public decimal CalculateDiscount(Product product)
    {
        if (product.Type != Type)
        {
            return 0;
        }
        return product.Price * 0.1m; // 10% discount for electronics
    }
}

public class ClothingDiscountCalculator : IDiscountCalculator
{
    public ProductType Type { get; set; } = ProductType.Clothing;

    public decimal CalculateDiscount(Product product)
    {
        if(product.Type != Type)
        {
            return 0;
        }
        return product.Price * 0.05m; // 5% discount for clothing
    }
}

public class DiscountService
{
    private readonly List<IDiscountCalculator> _discountCalculators;

    public DiscountService(List<IDiscountCalculator> discountCalculators)
    {
        _discountCalculators = discountCalculators;
    }

    public decimal CalculateDiscount(Product product)
    {
        decimal discount = 0;

        foreach (var calculator in _discountCalculators)
        {
            discount += calculator.CalculateDiscount(product);
        }

        return discount;
    }
}

public class HomewareDiscountCalculator : IDiscountCalculator
{
    public ProductType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public decimal CalculateDiscount(Product product)
    {
        throw new NotImplementedException();
    }
}
public class OpenClosedApplicationExample
{
    public static void Build()
    {
        Console.WriteLine("OpenClosedApplicationExample\n");

        var products = new List<Product>
        {
            new() { Name = "Laptop", Price = 1000, Type = ProductType.Electronics },
            new() { Name = "T-Shirt", Price = 20, Type = ProductType.Clothing  },
        };

        var discountCalculators = new List<IDiscountCalculator>
        {
            new ElectronicsDiscountCalculator(),
            new ClothingDiscountCalculator(),
            //new HomewareDiscountCalculator()
        };

        var discountService = new DiscountService(discountCalculators);
        decimal totalDiscount = 0;

        foreach (var product in products)
        {
            totalDiscount += discountService.CalculateDiscount(product);
        }

        Console.WriteLine($"Total Discount: {totalDiscount:C}");
    }
}
