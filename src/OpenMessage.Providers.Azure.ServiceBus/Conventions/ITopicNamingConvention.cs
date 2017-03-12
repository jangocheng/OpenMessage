namespace OpenMessage.Providers.Azure.ServiceBus.Conventions
{
    public interface ITopicNamingConvention
    {
        string GenerateName<T>();
    }
}
