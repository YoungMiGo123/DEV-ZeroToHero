namespace ZeroToHero.BestPractices.Console.SOLID.DependecyInjection.After;
using System;
using System.Collections.Generic;

public class ProductRepository : IProductRepository
{
    private List<Product> _products;
    public ProductRepository(List<Product> products)
    {
        _products = products;
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

        if (productToUpdate is not null)
        {
            productToUpdate.Name = updatedProduct.Name;
            productToUpdate.Price = updatedProduct.Price;
            productToUpdate.Description = updatedProduct.Description;
            productToUpdate.Type = updatedProduct.Type;
            return;
        }

        Console.WriteLine($"Product with name '{updatedProduct.Name}' not found.");
    }

    public Product GetProductById(Guid Id)
    {
        return _products.Find(p => p.Id == Id) ?? new Product() { Id = Guid.Empty };
    }
    public void SaveChanges() => Console.WriteLine("Changes saved to the database");

    public IEnumerable<Product> GetAllProducts()
    {
        return _products;
    }
}
