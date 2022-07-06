namespace CryptoCurrencyApp.Infrastructure
{
    public static class Constants
    {
        private const string coinMarketCapApiPartUrl = @"https://pro-api.coinmarketcap.com/v1/cryptocurrency/";
        private const string coinMarketCapApiQuotesUrl = @"quotes/latest";
        private const string coinMarketCapApiKey = @"e0040278-0335-4a25-8920-eaaxdc6b49394";
        private static string coinMarketCapApiConvert = "USD";

        private const string currencyExchangeApiPartUrl = @"https://api.apilayer.com/exchangerates_data/";
        private const string currencyExchangeApiQuotesUrl = @"convert";
        private const string currencyExchangeApiKey = @"BMnOPIQJkAPwhfVy12YRzk5Va1GAxY4q7";
        private static string[] currencyExchangeConverts = { "EUR", "BRL", "GBP", "AUD" };

        public static string CoinMarketCapApiPartUrl => coinMarketCapApiPartUrl;

        public static string CoinMarketCapApiQuotesUrl => coinMarketCapApiQuotesUrl;

        public static string CoinMarketCapApiKey => coinMarketCapApiKey;

        public static string CoinMarketCapApiConvert => coinMarketCapApiConvert;

        public static string CurrencyExchangeApiPartUrl => currencyExchangeApiPartUrl;

        public static string CurrencyExchangeApiQuotesUrl => currencyExchangeApiQuotesUrl;

        public static string CurrencyExchangeApiKey => currencyExchangeApiKey;

        public static string[] CurrencyExchangeConverts => currencyExchangeConverts;
    }
}
