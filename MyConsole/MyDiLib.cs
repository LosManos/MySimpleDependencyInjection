class MyDiLib
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
        {
            TheInterfaceType = typeof(TInterface),
            TheClassType = typeof(TClass)
        });
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

    public override string ToString()
    {
        return string.Join(",", services.Select(s => s.ToString()));
    }
}

internal class ServiceDefinition
{
    public Type TheInterfaceType { get; internal init; }
    public Type TheClassType { get; internal set; }
}

internal interface IStartClass
{
    void Start();
    void SetContext(ServiceDefinitions serviceDefinitions);
}
