namespace ZeroToHero.BestPractices.Console.SOLID.DependecyInjection.Before;
using System;
using System.Collections.Generic;


public enum ProductType
{
    Electronics,
    Clothing,
    Books,
    Food
}
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public ProductType Type { get; set; }

    public void DisplayProductInfo()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price:C}, Description: {Description}, Type: {Type}");
    }
}

public class ProductService
{
    private List<Product> _products = [];

    public ProductService()
    {

    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public void RemoveProduct(Product product)
    {
        _products.RemoveAll(x => x.Id == product.Id);
    }
    public void UpdateProduct(Product updatedProduct)
    {
        var productToUpdate = _products.Find(p => p.Id == updatedProduct.Id);

        if (productToUpdate != null)
        {
            // Update the product properties
            productToUpdate.Name = updatedProduct.Name;
            productToUpdate.Price = updatedProduct.Price;
            productToUpdate.Description = updatedProduct.Description;
            productToUpdate.Type = updatedProduct.Type;
        }
        else
        {
            Console.WriteLine($"Product with name '{updatedProduct.Name}' not found.");
        }
    }

    public Product GetProductById(Guid Id)
    {
        return _products.Find(p => p.Id == Id) ?? new Product() { Id = Guid.Empty };
    }
    public void SaveChanges() => Console.WriteLine("Changes saved to the database");

    public void DisplayProductMenu()
    {
        foreach (var product in _products)
        {
            product.DisplayProductInfo();
        }
    }

}


public class DependencyInversionViolationExample
{
    public static void Build()
    {
        Console.WriteLine("DependencyInversionViolationExample\n");

        var productService = new ProductService();
        var products = new List<Product>
        {
            new() { Id = Guid.NewGuid(), Description = "Brand new laptop", Name = "Laptop", Price = 10000, Type = ProductType.Electronics },
            new() { Id = Guid.NewGuid(), Description = "Brand new T-Shirt", Name = "T-Shirt", Price = 150, Type = ProductType.Clothing },
            new() { Id = Guid.NewGuid(), Description = "Brand new Book", Name = "Book", Price = 250, Type = ProductType.Books},
            new() { Id = Guid.NewGuid(), Description = "Fresh new Apple", Name = "Apple", Price = 20, Type = ProductType.Food},
            new() { Id = Guid.NewGuid(), Description = "Fresh new Steak", Name = "Steak", Price = 350, Type = ProductType.Food}
           
        };
        foreach(var product in products)
        {
            productService.AddProduct(product);
        }
        productService.SaveChanges();
        productService.DisplayProductMenu();
    }
}
