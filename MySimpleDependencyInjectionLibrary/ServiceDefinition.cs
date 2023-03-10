public record ServiceDefinition
{
    public Type TheInterfaceType { get; private init; }
    public Type TheClassType { get; private init; }

    public ServiceDefinition(Type theInterfaceType, Type theClassType)
    {
        TheInterfaceType = theInterfaceType;
        TheClassType = theClassType;
    }
}
