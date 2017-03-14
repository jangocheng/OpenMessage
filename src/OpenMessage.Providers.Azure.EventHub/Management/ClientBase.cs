using System;
using System.Collections.Generic;
using Microsoft.Azure.EventHubs;
using Microsoft.Extensions.Logging;
using OpenMessage.Providers.Azure.EventHub.Serialization;

namespace OpenMessage.Providers.Azure.EventHub.Management
{
    internal abstract class ClientBase<T> : IDisposable
    {
        private readonly List<Action<T>> _callbacks = new List<Action<T>>();
        private readonly ISerializationProvider _provider;

        protected int CallbackCount => _callbacks.Count;
        protected ILogger<ClientBase<T>> Logger { get; }
        protected string TypeName { get; } = typeof(T).GetFriendlyName();

        protected ClientBase(ISerializationProvider provider,
            ILogger<ClientBase<T>> logger)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _provider = provider;
            Logger = logger;
        }
        ~ClientBase()
        {
            Dispose(false);
        }

        protected void AddCallback(Action<T> callback)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));
           
            _callbacks.Add(callback);
        }

        protected void OnMessage(EventData message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            try
            {
                var entity = _provider.Deserialize<T>(message);
                foreach (var callback in _callbacks)
                    callback(entity);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }

        protected EventData Serialize(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return _provider.Serialize(entity);
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
        }
    }
}
