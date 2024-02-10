

namespace ZeroToHero.BestPractices.Console.YAGNI.After;

using System;

public class ShoppingCart
{
    public void AddItem(string item)
    {
        Console.WriteLine($"Adding item: {item}");
        // Logic to add item to the shopping cart
    }

    public void UpdateItem(string item)
    {
        Console.WriteLine($"Updating item: {item}");
        // Logic to update item in the shopping cart
    }


    public void Checkout()
    {
        Console.WriteLine("Checkout");
        // Logic to complete checkout process
    }
}

public class ApplyingYagni
{
    public static void Build()
    {
        var cart = new ShoppingCart();

        cart.AddItem("ItemA");
        cart.UpdateItem("ItemB");
        cart.Checkout();
    }
}
