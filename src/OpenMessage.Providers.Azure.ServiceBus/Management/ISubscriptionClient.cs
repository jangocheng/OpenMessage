using System;

namespace OpenMessage.Providers.Azure.ServiceBus.Management
{
    internal interface ISubscriptionClient<T> : IDisposable
    {
        void RegisterCallback(Action<T> callback);
    }
}
