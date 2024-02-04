namespace ZeroToHero.Collections.Console.Queue
{
    public class Order
    {
        public string OrderId { get; }
        public string Product { get; }

        public Order(string orderId, string product)
        {
            OrderId = orderId;
            Product = product;
        }
    }
}
