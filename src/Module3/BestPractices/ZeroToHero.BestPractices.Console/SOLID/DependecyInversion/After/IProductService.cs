namespace ZeroToHero.BestPractices.Console.SOLID.DependecyInjection.After;
using System;

public interface IProductService
{
    void AddProduct(Product product);
    void RemoveProduct(Product product);
    void UpdateProduct(Product updatedProduct);
    Product GetProductById(Guid Id);
    void DisplayProductsMenu();
}
