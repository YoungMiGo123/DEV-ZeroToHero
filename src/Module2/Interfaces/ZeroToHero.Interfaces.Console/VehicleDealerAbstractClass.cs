namespace ZeroToHero.Interfaces.Console
{
    using System;

    public class VehicleDealerAbstractClass
    {
        public abstract class VehicleDealer
        {
            public string DealerName { get; set; }
            public string VehicleType { get; set; }

            public abstract void SellVehicle(string model);
            public void Advertise()
            {
                // Common advertising strategy for the dealership
                Console.WriteLine($"Visit {DealerName} for the latest {VehicleType} vehicles!");
            }
        }
        public class CarDealer : VehicleDealer
        {
            public override void SellVehicle(string model)
            {
                // Implement logic to sell a car
                Console.WriteLine($"Selling {model} at {DealerName}");
            }
        }

        public class MotorcycleDealer : VehicleDealer
        {
            public override void SellVehicle(string model)
            {
                // Implement logic to sell a motorcycle
                Console.WriteLine($"Selling {model} at {DealerName}");
            }
        }
        public static void BuildVehicleDealerExample()
        {
            VehicleDealer dealer = new CarDealer
            {
                DealerName = "Car Dealer",
                VehicleType = "Car"
            };
            dealer.Advertise();
            dealer.SellVehicle("Ford Mustang");

            dealer = new MotorcycleDealer
            {
                DealerName = "Motorcycle Dealer",
                VehicleType = "Motorcycle"
            };
            dealer.Advertise();
            dealer.SellVehicle("Harley Davidson");
        }
    }
}
