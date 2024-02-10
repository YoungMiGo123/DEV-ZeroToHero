namespace ZeroToHero.BestPractices.Console.SOLID.DependecyInjection.After;
using System;
using System.Collections.Generic;

public interface IProductRepository
{
    void AddProduct(Product product);
    void RemoveProduct(Product product);
    void UpdateProduct(Product updatedProduct);
    Product GetProductById(Guid Id);
    IEnumerable<Product> GetAllProducts();
    void SaveChanges();

}
