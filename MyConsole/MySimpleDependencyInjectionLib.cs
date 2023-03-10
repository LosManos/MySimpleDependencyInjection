class MySimpleDependencyInjectionLib
{
    private ServiceDefinitions services = new ServiceDefinitions();

    internal void Register<TInterface, TClass>()
        where TInterface : class
        where TClass : class, IInjectable
    {
        services.Add<TInterface, TClass>();
    }
    internal void Run<TStartclasss>() where TStartclasss : class, IStartClass
    {
        var worker = Activator.CreateInstance<TStartclasss>();
        worker.SetContext(services);
        worker.Start();
    }
}

internal class ServiceDefinitions
{
    private List<ServiceDefinition> services = new List<ServiceDefinition>();

    internal void Add<TInterface, TClass>()
        where TInterface : class
        where TClass : class, IInjectable
    {
        services.Add(new ServiceDefinition
        (
            typeof(TInterface),
            typeof(TClass)
        ));
    }

    internal TClass Get<TInterface, TClass>()
        where TInterface : class
        where TClass : class, IInjectable
    {
        var service = services.SingleOrDefault(s => s.TheInterfaceType == typeof(TInterface))
            ?? throw new Exception($"Interface {typeof(TInterface)} was not found.");
        var res = Activator.CreateInstance<TClass>();
        res.SetContext(this);
        return res;
    }
}

internal record ServiceDefinition
{
    public Type TheInterfaceType { get; private init; }
    public Type TheClassType { get; private init; }

    public ServiceDefinition(Type theInterfaceType, Type theClassType)
    {
        TheInterfaceType = theInterfaceType;
        TheClassType = theClassType;
    }
}

internal interface IStartClass
{
    void Start();
    void SetContext(ServiceDefinitions serviceDefinitions);
}
