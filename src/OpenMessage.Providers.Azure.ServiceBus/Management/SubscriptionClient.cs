using Microsoft.Extensions.Logging;
using OpenMessage.Providers.Azure.ServiceBus.Serialization;
using System;
using System.Threading.Tasks;
using AzureClient = Microsoft.ServiceBus.Messaging.SubscriptionClient;
using OpenMessage.Providers.Azure.Management;

namespace OpenMessage.Providers.Azure.ServiceBus.Management
{
    internal sealed class SubscriptionClient<T> : ClientBase<T>, ISubscriptionClient<T>
    {
        private AwaitableLazy<AzureClient> _client;

        public SubscriptionClient(INamespaceManager<T> namespaceManager,
            ISerializationProvider serializationProvider,
            ILogger<ClientBase<T>> logger)
            : base(serializationProvider, logger)
        {
            if (namespaceManager == null)
                throw new ArgumentNullException(nameof(namespaceManager));

            _client = new AwaitableLazy<AzureClient>(async () =>
            {
                await namespaceManager.ProvisionSubscriptionAsync();
                return namespaceManager.CreateSubscriptionClient();
            });
        }

        public void RegisterCallback(Action<T> callback)
        {
            Task.Run(() => {
                lock (_client)
                    if (CallbackCount == 0)
                        _client.Value.OnMessage(OnMessage);

                AddCallback(callback);
            });
        }

        public override void Dispose(bool disposing)
        {
            if (_client.IsValueCreated)
                _client.Value?.Close();
        }
    }
}
