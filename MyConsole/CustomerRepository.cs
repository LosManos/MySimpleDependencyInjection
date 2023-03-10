internal interface ICustomerRepository
{
}

internal class CustomerRepository : ICustomerRepository, IInjectable
{
    private ServiceDefinitions? serviceDefinitions;

    public void SetContext(ServiceDefinitions serviceDefinitions)
    {
        this.serviceDefinitions = serviceDefinitions;
    }

    internal void SaveEntity()
    {
        System.Console.WriteLine($"Saving in {nameof(CustomerRepository)}.{nameof(SaveEntity)}.");
    }
}

