using System;
using System.Threading.Tasks;
using OpenMessage.Providers.Azure.EventHub.Management;

namespace OpenMessage.Providers.Azure.EventHub.Dispatchers
{
    internal class EventDispatcher<T> : IDispatcher<T>
    {
        private readonly IEventClient<T> _client;

        public EventDispatcher(IEventClientFactory<T> eventFactory)
        {
            if (eventFactory == null)
                throw new ArgumentNullException(nameof(eventFactory));

            _client = eventFactory.Create();
        }

        public Task DispatchAsync(T entity, TimeSpan scheduleIn) => _client.SendAsync(entity, scheduleIn);
    }
}
