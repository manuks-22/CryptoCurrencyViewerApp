using System.Collections.Generic;

namespace CryptoCurrencyApp.Service.Configuration
{
    /// <summary>
    /// Rest client configuration details for the services.
    /// </summary>
    public interface IRestClientConfiguration
    {
        /// <summary>
        /// The root url of the API.
        /// </summary>
        string ApiRootUrl { get; }

        /// <summary>
        /// The part url of the API for which the service is invoked.
        /// </summary>
        string ApiQuotesUrl { get; }

        /// <summary>
        /// The custom headers to be added to the web request.
        /// </summary>
        Dictionary<string, string> CustomHeaders { get; }
    }
}
