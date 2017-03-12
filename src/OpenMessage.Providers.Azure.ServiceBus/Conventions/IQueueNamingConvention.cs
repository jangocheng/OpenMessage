namespace OpenMessage.Providers.Azure.ServiceBus.Conventions
{
    public interface IQueueNamingConvention
    {
        string GenerateName<T>();
    }
}
