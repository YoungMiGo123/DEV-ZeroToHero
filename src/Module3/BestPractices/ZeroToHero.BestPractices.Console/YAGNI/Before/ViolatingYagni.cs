
namespace ZeroToHero.BestPractices.Console.YAGNI.Before;

using System;
public class ShoppingCart
{
    public void AddItem(string item)
    {
        Console.WriteLine($"Adding item: {item}");
        // Logic to add item to the shopping cart
    }

    public void RemoveItem(string item)
    {
        Console.WriteLine($"Removing item: {item}");
        // Logic to remove item from the shopping cart
    }

    public void UpdateItem(string item)
    {
        Console.WriteLine($"Updating item: {item}");
        // Logic to update item in the shopping cart
    }

    public void CalculateTotal()
    {
        Console.WriteLine("Calculating total");
        // Logic to calculate total price of items in the shopping cart
    }

    public void ApplyDiscount()
    {
        Console.WriteLine("Applying discount");
        // Logic to apply discount to items in the shopping cart
    }

    public void Checkout()
    {
        Console.WriteLine("Checkout");
        // Logic to complete checkout process
    }
}
public class ViolatingYagni
{
    public static void Build()
    {
        var cart = new ShoppingCart();

        cart.AddItem("ItemA");
        cart.UpdateItem("ItemB");
        cart.Checkout();
    }
}
