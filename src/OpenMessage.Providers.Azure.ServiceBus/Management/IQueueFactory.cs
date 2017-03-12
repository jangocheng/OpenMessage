namespace OpenMessage.Providers.Azure.ServiceBus.Management
{
    internal interface IQueueFactory<T>
    {
        IQueueClient<T> Create();
    }
}
