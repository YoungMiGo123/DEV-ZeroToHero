namespace ZeroToHero.BestPractices.Console.SOLID.OpenClosed.Before;

using System;
using System.Collections.Generic;
using ZeroToHero.BestPractices.Console.SOLID.OpenClosed.After;

public class DiscountService
{
    public decimal CalculateDiscount(List<Product> products)
    {
        decimal discount = 0;

        foreach (var product in products)
        {
            if (product.Type is ProductType.Electronics)
            {
                discount += product.Price * 0.1m; // 10% discount for electronics
            }
            else if (product.Type is ProductType.Clothing)
            {
                discount += product.Price * 0.05m; // 5% discount for clothing
            }
            // Add more conditions for other types of products
        }

        return discount;
    }
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductType Type { get; set; }
}

public class OpenClosedViolationExample
{
    public static void Build()
    {
        Console.WriteLine("OpenClosedViolationExample\n");

        var products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1000, Type = ProductType.Electronics },
            new Product { Name = "T-Shirt", Price = 20, Type = ProductType.Clothing },
            // Add more products
        };

        var discountService = new DiscountService();
        var totalDiscount = discountService.CalculateDiscount(products);

        Console.WriteLine($"Total Discount: {totalDiscount:C}");
    }
}
