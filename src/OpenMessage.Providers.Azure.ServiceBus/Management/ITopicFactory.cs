namespace OpenMessage.Providers.Azure.ServiceBus.Management
{
    internal interface ITopicFactory<T>
    {
        ITopicClient<T> Create();
    }
}
