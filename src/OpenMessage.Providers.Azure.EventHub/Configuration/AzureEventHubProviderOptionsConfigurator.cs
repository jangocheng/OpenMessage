using Microsoft.Extensions.Options;
using System;

namespace OpenMessage.Providers.Azure.EventHub.Configuration
{
    internal sealed class AzureEventHubProviderOptionsConfigurator<T> : IConfigureOptions<AzureEventHubProviderOptions<T>>
    {
        private readonly AzureEventHubProviderOptions _defaultOptions;

        public AzureEventHubProviderOptionsConfigurator(IOptions<AzureEventHubProviderOptions> defaultOptions)
        {
            if (defaultOptions == null)
                throw new ArgumentNullException(nameof(defaultOptions));

            _defaultOptions = defaultOptions.Value;
        }

        public void Configure(AzureEventHubProviderOptions<T> options)
        {
            options.ConnectionString = _defaultOptions.ConnectionString;
        }
    }
}
