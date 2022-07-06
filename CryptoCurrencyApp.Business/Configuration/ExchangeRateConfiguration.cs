using CryptoCurrencyApp.Infrastructure;
using System.Collections.Generic;

namespace CryptoCurrencyApp.Service.Configuration
{
    public class ExchangeRateConfiguration : IExchangeRateConfiguration
    {
        public string[] AvailableCurrencyConversions => Constants.CurrencyExchangeConverts;

        public string ApiRootUrl => Constants.CurrencyExchangeApiPartUrl;

        public string ApiQuotesUrl => Constants.CurrencyExchangeApiQuotesUrl;

        public Dictionary<string, string> CustomHeaders => new Dictionary<string, string>() { { "apikey", Constants.CurrencyExchangeApiKey }, { "Accepts", "application/json" } };
    }
}
