using System;
using System.Threading.Tasks;

namespace OpenMessage.Providers.Azure.EventHub
{
    internal interface IEventClient<T>
    {
        void RegisterCallback(Action<T> callback);
        Task SendAsync(T entity, TimeSpan scheduleIn);
    }
}
