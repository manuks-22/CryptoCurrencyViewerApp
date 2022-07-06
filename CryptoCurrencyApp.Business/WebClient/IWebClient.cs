using CryptoCurrencyApp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Service.WebClient
{
    /// <summary>
    /// Web client wrapper to call the API.
    /// </summary>
    public interface IWebClient
    {
        /// <summary>
        /// Gets the data from the external API.
        /// </summary>
        /// <typeparam name="T">The return type</typeparam>
        /// <param name="url">The Uri</param>
        /// <param name="customHeaders">Custom headers to passed to the request.</param>
        /// <returns></returns>
        Task<T> GetWebData<T>(Uri url, Dictionary<string, string> customHeaders) where T : IModel, new();

        /// <summary>
        /// Build the url.
        /// </summary>
        /// <param name="rootUrl">The root url of the API.</param>
        /// <param name="partUrl">The part url of the API for which the service is invoked.</param>
        /// <param name="queryStringParameters">The query string parameters.</param>
        /// <returns></returns>
        Uri BuildUrl(string rootUrl, string partUrl, Dictionary<string, string> queryStringParameters);
    }
}
