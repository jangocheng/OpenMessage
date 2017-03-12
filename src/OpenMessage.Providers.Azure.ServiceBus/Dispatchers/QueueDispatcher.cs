using OpenMessage.Providers.Azure.ServiceBus.Management;
using System;
using System.Threading.Tasks;

namespace OpenMessage.Providers.Azure.ServiceBus.Dispatchers
{
    internal sealed class QueueDispatcher<T> : IDispatcher<T>
    {
        private readonly IQueueClient<T> _client;

        public QueueDispatcher(IQueueFactory<T> queueFactory)
        {
            if (queueFactory == null)
                throw new ArgumentNullException(nameof(queueFactory));

            _client = queueFactory.Create();
        }

        public Task DispatchAsync(T entity, TimeSpan scheduleIn) => _client.SendAsync(entity, scheduleIn);
    }
}
