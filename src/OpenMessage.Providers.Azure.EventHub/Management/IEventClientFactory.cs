namespace OpenMessage.Providers.Azure.EventHub.Management
{
    internal interface IEventClientFactory<T>
    {
        IEventClient<T> Create();
    }
}
