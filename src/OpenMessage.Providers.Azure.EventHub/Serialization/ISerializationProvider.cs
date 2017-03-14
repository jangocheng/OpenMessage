using Microsoft.Azure.EventHubs;
using System.IO;

namespace OpenMessage.Providers.Azure.EventHub.Serialization
{
    internal interface ISerializationProvider
    {
        EventData Serialize<T>(T entity);
        T Deserialize<T>(EventData entity);
    }
}
