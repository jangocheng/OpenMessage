namespace OpenMessage.Providers.Azure.ServiceBus.Conventions
{
    public interface ISubscriptionNamingConvention
    {
        string GenerateName<T>();
    }
}
