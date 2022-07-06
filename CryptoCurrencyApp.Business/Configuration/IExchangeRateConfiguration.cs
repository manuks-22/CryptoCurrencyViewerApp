
namespace CryptoCurrencyApp.Service.Configuration
{
    public interface IExchangeRateConfiguration : IRestClientConfiguration
    {
        public string[] AvailableCurrencyConversions { get; }
    }
}
