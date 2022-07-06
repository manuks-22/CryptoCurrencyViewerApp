
namespace CryptoCurrencyApp.Service.Configuration
{
    public interface ICoinMarketCapConfiguration : IRestClientConfiguration
    {
        /// <summary>
        /// Gets the currency coversion factor
        /// </summary>
        public string CurrencyConversions { get; }
    }
}
