using Microsoft.Extensions.Logging;
using OpenMessage.Providers.Azure.ServiceBus.Management;
using System;

namespace OpenMessage.Providers.Azure.ServiceBus.Observables
{
    internal sealed class SubscriptionObservable<T> : ManagedObservable<T>
    {
        private readonly ISubscriptionClient<T> _subscriptionClient;

        public SubscriptionObservable(ILogger<ManagedObservable<T>> logger,
            ISubscriptionFactory<T> subscriptionFactory) : base(logger)
        {
            if (subscriptionFactory == null)
                throw new ArgumentNullException(nameof(subscriptionFactory));

            _subscriptionClient = subscriptionFactory.Create();
            _subscriptionClient.RegisterCallback(Notify);
        }

        public override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _subscriptionClient?.Dispose();
        }
    }
}
