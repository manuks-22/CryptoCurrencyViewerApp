
namespace CryptoCurrencyApp.Infrastructure.Dto
{
    public class ExchangeRateDto
    {
        private string _currencyId;
        private double _rate;

        public ExchangeRateDto(string currencyId, double rate)
        {
            _currencyId = currencyId;
            _rate = rate;
        }

        /// <summary>
        /// Get the CurrencyId property.
        /// </summary>
        public string CurrencyId => _currencyId;

        /// <summary>
        /// Get the Rate property.
        /// </summary>
        public double Rate => _rate;
    }

}
