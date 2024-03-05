namespace ZeroToHero.DI.Console.Services.CustomerService;
// Service that needs data access functionality
public class CustomerService : ICustomerService
{
    private readonly IDataAccess _dataAccess;

    public CustomerService(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public void AddCustomer(string name)
    {
        _dataAccess.SaveData($"New customer added: {name}");
        // Code to add customer to database
    }
}
