
namespace CryptoCurrencyApp.Service.Configuration
{
    public interface ICoinMarketCapConfiguration : IRestClientConfiguration
    {
        public string CurrencyConversions { get; }
    }
}
