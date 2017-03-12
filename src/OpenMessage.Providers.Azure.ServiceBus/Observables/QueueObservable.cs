using Microsoft.Extensions.Logging;
using OpenMessage.Providers.Azure.ServiceBus.Management;
using System;

namespace OpenMessage.Providers.Azure.ServiceBus.Observables
{
    internal sealed class QueueObservable<T> : ManagedObservable<T>
    {
        private readonly IQueueClient<T> _queueClient;

        public QueueObservable(ILogger<ManagedObservable<T>> logger,
            IQueueFactory<T> queueFactory) : base(logger)
        {
            if (queueFactory == null)
                throw new ArgumentNullException(nameof(queueFactory));

            _queueClient = queueFactory.Create();
            _queueClient.RegisterCallback(Notify);
        }

        public override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _queueClient?.Dispose();
        }
    }
}
