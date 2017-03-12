using System;
using Microsoft.Extensions.DependencyInjection;

namespace OpenMessage.Providers.Azure.EventHub
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddOpenMessage(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            // TODO(Dan): Add required services here

            return services;
        }
    }
}
