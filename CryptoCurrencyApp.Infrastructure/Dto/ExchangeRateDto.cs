
namespace CryptoCurrencyApp.Infrastructure.Dto
{
    public class ExchangeRateDto
    {
        /// <summary>
        /// Get the CurrencyId property.
        /// </summary>
        public string CurrencyId { get; init; }

        /// <summary>
        /// Get the Rate property.
        /// </summary>
        public double Rate { get; init; }

        public ExchangeRateDto(string currencyId, double rate)
        {
            CurrencyId = currencyId;
            Rate = rate;
        }

    }

}
