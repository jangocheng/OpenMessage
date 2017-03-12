namespace OpenMessage.Providers.Azure.EventHub.Configuration
{
    public class AzureEventHubProviderOptions
    {
        /// <summary>
        ///     The connection string to use when connection to the Azure Event Hub Namespace.
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        ///     The entity path to use when connection to the Azure Event Hub Namespace.
        /// </summary>
        public string EntityPath { get; set; }
    }
}
