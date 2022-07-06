using CryptoCurrencyApp.Infrastructure;
using System.Collections.Generic;

namespace CryptoCurrencyApp.Service.Configuration
{
    public class CoinMarketCapConfiguration : ICoinMarketCapConfiguration
    {
        public string ApiRootUrl => Constants.CoinMarketCapApiPartUrl;

        public string ApiQuotesUrl => Constants.CoinMarketCapApiQuotesUrl;

        public string CurrencyConversions => Constants.CoinMarketCapApiConvert;

        public Dictionary<string, string> CustomHeaders => new Dictionary<string, string>() { { "X-CMC_PRO_API_KEY", Constants.CoinMarketCapApiKey }, { "Accepts", "application/json" } };

    }
}
