var di = new MySimpleDependencyInjectionLib();
di.Register<ICustomerService, CustomerService>();
di.Register<ICustomerRepository, CustomerRepository>();

di.Run<Worker>();

class Worker : IStartClass
{
    private ServiceDefinitions? serviceDefinitions;

    public void SetContext(ServiceDefinitions serviceDefinitions)
    {
        this.serviceDefinitions = serviceDefinitions;
    }

    public void Start()
    {
        var customerService = serviceDefinitions!.Get<ICustomerService, CustomerService>();
        customerService.Save();
    }
}
