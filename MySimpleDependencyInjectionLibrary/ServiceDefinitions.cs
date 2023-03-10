public class ServiceDefinitions
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

    public TClass Get<TInterface, TClass>()
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
