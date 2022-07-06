
namespace CryptoCurrencyApp.Service.Configuration
{
    public interface IExchangeRateConfiguration : IRestClientConfiguration
    {
        /// <summary>
        /// Gets all the available currency conversions.
        /// </summary>
        public string[] AvailableCurrencyConversions { get; }
    }
}
