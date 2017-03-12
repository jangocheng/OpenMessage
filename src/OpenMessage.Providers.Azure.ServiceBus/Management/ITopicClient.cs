using System;
using System.Threading.Tasks;

namespace OpenMessage.Providers.Azure.ServiceBus.Management
{
    internal interface ITopicClient<T> : IDisposable
    {
        Task SendAsync(T entity, TimeSpan scheduleIn);
    }
}
