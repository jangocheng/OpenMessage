namespace OpenMessage.Providers.Azure.ServiceBus.Management
{
    internal interface ISubscriptionFactory<T>
    {
        ISubscriptionClient<T> Create();
    }
}
