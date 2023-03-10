var di = new MyDiLib();
di.Register<ICustomerService, CustomerService>();
di.Register<ICustomerRepository, CustomerRepository>();

di.Run<Worker>();

class Worker : IStartClass
{
    private ServiceDefinitions serviceDefiniations;

    public void SetContext(ServiceDefinitions serviceDefinitions)
    {
        this.serviceDefiniations = serviceDefinitions;
    }

    public void Start()
    {
        var customerService = serviceDefiniations.Get<ICustomerService, CustomerService>();
        customerService.Save();
    }
}