using Microsoft.ServiceBus.Messaging;

namespace OpenMessage.Providers.Azure.ServiceBus
{
    public interface IMessageExtension<in T>
    {
        void Extend(BrokeredMessage message);
    }
}
