public class MySimpleDependencyInjectionLib
{
    private ServiceDefinitions services = new ServiceDefinitions();

    public void Register<TInterface, TClass>()
        where TInterface : class
        where TClass : class, IInjectionable
    {
        services.Add<TInterface, TClass>();
    }
    public void Run<TStartclasss>() where TStartclasss : class, IStartClass
    {
        var worker = Activator.CreateInstance<TStartclasss>();
        worker.SetContext(services);
        worker.Start();
    }
}
