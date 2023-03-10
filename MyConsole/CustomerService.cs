internal interface ICustomerService
{
}

internal class CustomerService : ICustomerService, IInjectable
{
    private ServiceDefinitions serviceDefinitions;

    public void SetContext(ServiceDefinitions serviceDefinitions)
    {
        this.serviceDefinitions = serviceDefinitions;
    }

    internal void Save()
    {
        var repo = serviceDefinitions.Get<ICustomerRepository, CustomerRepository>();
        repo.SaveEntity();
    }
}
