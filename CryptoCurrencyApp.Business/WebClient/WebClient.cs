using CryptoCurrencyApp.Infrastructure.Guard;
using CryptoCurrencyApp.Infrastructure.Logging;
using CryptoCurrencyApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace CryptoCurrencyApp.Service.WebClient
{
    public class WebClient : IWebClient
    {
        private readonly ILogManager _logger;

        public WebClient(ILogManager logger)
        {
            _logger = logger;
        }

        public async Task<T> GetWebData<T>(Uri url, Dictionary<string, string> customHeaders) where T : IModel, new()
        {
            _logger.Information(@$"Getting data from Api {url}");
            var resultModel = default(T);

            using var client = new System.Net.WebClient();
            foreach (var item in customHeaders)
            {
                client.Headers.Add(item.Key, item.Value);
            }

            try
            {
                var resultJson = await client.DownloadStringTaskAsync(url);
                resultModel = DeserializeJsonResult<T>(resultJson);
            }
            catch (ArgumentNullException)
            {
                _logger.Error(@$"{nameof(WebClient)} - {nameof(GetWebData)}: The url is empty.");
                throw;
            }
            catch (System.Net.WebException ex)
            {
                _logger.Error(@$"{nameof(WebClient)} - {nameof(GetWebData)}: Error fetching data from API {Environment.NewLine}{ex.InnerException}");
                throw;
            }
            return resultModel;
        }

        public Uri BuildUrl(string rootUrl, string partUrl, Dictionary<string, string> queryStringParameters)
        {
            _logger.Information(@$"Building get url for Root Url :{rootUrl}, Part Url {partUrl}");

            Guard.AgainstNullOrEmpty(rootUrl, nameof(rootUrl));
            Guard.AgainstNullOrEmpty(partUrl, nameof(partUrl));

            var URL = BuildUrlBuilder(rootUrl, partUrl);

            URL.Query = GetQueryString(queryStringParameters);

            return URL.Uri;
        }

        private UriBuilder BuildUrlBuilder(string rootUrl, string partUrl)
        {
            return new UriBuilder(rootUrl + partUrl);
        }

        private string GetQueryString(Dictionary<string, string> queryStringParameters)
        {
            _logger.Information(@$"Adding query string parameters");
            string queryStringText = string.Empty;

            if (queryStringParameters != null)
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty);
                foreach (var item in queryStringParameters)
                {
                    queryString.Add(item.Key, item.Value);
                }
                queryStringText = queryString.ToString();
            }
            return queryStringText;
        }

        private T DeserializeJsonResult<T>(string jsonData)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            catch (JsonSerializationException ex)
            {
                _logger.Error(@$"{nameof(WebClient)} - {nameof(GetWebData)}: Error deserializing JSON data received from API {Environment.NewLine}{ex.InnerException}");
                throw;
            }
            catch (JsonSchemaException ex)
            {
                _logger.Error(@$"{nameof(WebClient)} - {nameof(GetWebData)}: Error in JSON  schema received  from API {Environment.NewLine}{ex.InnerException}");
                throw;
            }
        }
    }
}
