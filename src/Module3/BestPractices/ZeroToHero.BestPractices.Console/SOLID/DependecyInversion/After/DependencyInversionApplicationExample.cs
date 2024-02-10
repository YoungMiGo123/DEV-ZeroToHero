namespace ZeroToHero.BestPractices.Console.SOLID.DependecyInjection.After;

using System;
public class DependencyInversionApplicationExample
{
    public static void Build()
    {
        Console.WriteLine("DependencyInversionApplicationExample\n");

        var initialProducts = new List<Product>
        {
            new() { Id = Guid.NewGuid(), Description = "Brand new laptop", Name = "Laptop", Price = 10000, Type = ProductType.Electronics },
            new() { Id = Guid.NewGuid(), Description = "Brand new T-Shirt", Name = "T-Shirt", Price = 150, Type = ProductType.Clothing },
            new() { Id = Guid.NewGuid(), Description = "Brand new Book", Name = "Book", Price = 250, Type = ProductType.Books},
        };

        IProductRepository productRepository = new ProductRepository(initialProducts);
        IProductService productService = new ProductService(productRepository);

        productService.DisplayProductsMenu();

        var newProduct = new Product() 
        { 
            Id = Guid.NewGuid(),
            Description = "Fresh new Apple", 
            Name = "Apple", Price = 20, 
            Type = ProductType.Food 
        };

        productService.DisplayProductsMenu();

        productService.AddProduct(newProduct);
        
        var updatedProduct = new Product()
        { 
            Id = initialProducts[0].Id,
            Description = "Brand new ACER laptop with high end specs i5, 32gb ram, 1TB ssd", 
            Name = "Laptop", 
            Price = 25000,
            Type = ProductType.Electronics
        };
        productService.UpdateProduct(updatedProduct);   
        productService.DisplayProductsMenu();
  
    }
}
