using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OpenMessage.Providers.Azure.ServiceBus;
using OpenMessage.Providers.Azure.ServiceBus.Serialization;
using Xunit;

namespace OpenMessage.Providers.Azure.Tests
{
    public class ServiceExtensionTests
    {
        public class AddOpenMessage
        {
            [Fact]
            public void GivenAServiceCollectionThenAddsSerializationProvider()
            {
                var services = new ServiceCollection().AddOpenMessage();

                services.Any(service => service.ServiceType == typeof(ISerializationProvider)).Should().BeTrue();
            }
        }
    }
}
