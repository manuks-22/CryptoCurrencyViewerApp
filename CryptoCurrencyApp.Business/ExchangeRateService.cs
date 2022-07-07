using CryptoCurrencyApp.Infrastructure.Guard;
using CryptoCurrencyApp.Infrastructure.Logging;
using CryptoCurrencyApp.Model.Model;
using CryptoCurrencyApp.Service.Configuration;
using CryptoCurrencyApp.Service.WebClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Service
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly ILogManager _logger;
        private readonly IExchangeRateConfiguration _config;
        private readonly IWebClient _webClient; 

        public ExchangeRateService(ILogManager logger, IExchangeRateConfiguration config, IWebClient webClient)
        {
            _logger = logger;
            _webClient = webClient;
            _config = config;
        }

        public string[] GetAvailableConversionsExcluding(params string[] currenciesToExclude)
        {
            var excludedConverts = currenciesToExclude.ToArray();
            var availableCoverts = _config.AvailableCurrencyConversions;
            return availableCoverts.Except(excludedConverts).ToArray();
        }

        public async Task<ExchangeRateModel> GetExchangeRate(double amount, string fromCurrency, string toCurrency)
        {
            _logger.Information(@$"Executing method GetExchangeRate of service {nameof(ExchangeRateService)}");

            Guard.AgainstNullOrEmpty(fromCurrency, nameof(fromCurrency));
            Guard.AgainstNullOrEmpty(toCurrency, nameof(toCurrency));

            Dictionary<string, string> queryParameters = new()
            {
                {
                    "amount",
                    amount.ToString()
                },
                {
                    "from",
                    fromCurrency
                },
                {
                    "to",
                    toCurrency
                }
            };

            var uri = _webClient.BuildUrl(_config.ApiRootUrl, _config.ApiQuotesUrl, queryParameters);
            var result = await _webClient.GetWebData<ExchangeRateModel>(uri, _config.CustomHeaders);

            return result;
        }


    }

}
