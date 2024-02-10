namespace ZeroToHero.BestPractices.Console.SOLID.DependecyInjection.After;
using System;

public class ProductService(IProductRepository _productRepository) : IProductService
{
    public void AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
        _productRepository.SaveChanges();
    }

    public void DisplayProductsMenu()
    {
        var products = _productRepository.GetAllProducts();
        foreach(var product in products)
        {
            Console.WriteLine(product);
        }
    }

    public Product GetProductById(Guid Id)
    {
        return _productRepository.GetProductById(Id);
    }

    public void RemoveProduct(Product product)
    {
        _productRepository.RemoveProduct(product);
        _productRepository.SaveChanges();

    }

    public void UpdateProduct(Product updatedProduct)
    {
        _productRepository.UpdateProduct(updatedProduct);
        _productRepository.SaveChanges();
    }
}
