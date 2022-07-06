using System.Collections.Generic;
using System.Linq;

namespace CryptoCurrencyApp.Infrastructure.Dto
{
    public class CrytoCurrencyRateDto
    {
        private readonly string _cryptoCurrencyId;
        private readonly string _cryptoCurrencySymbol;
        private readonly string _cryptoCurrencyName;
        private readonly List<ExchangeRateDto> _exchangeRates;
        private StatusDto _status;

        public CrytoCurrencyRateDto(string cryptoCurrencyId, string cryptoCurrencySymbol, string cryptoCurrencyName, IEnumerable<ExchangeRateDto> exchangeRates)
        {
            _cryptoCurrencyId = cryptoCurrencyId;
            _cryptoCurrencySymbol = cryptoCurrencySymbol;
            _cryptoCurrencyName = cryptoCurrencyName;
            if (exchangeRates != null)
                _exchangeRates = exchangeRates.ToList();
            SetStatus();
        }

        private void SetStatus()
        {
            var hasError = _cryptoCurrencyId == null;
            var errorMessage = hasError ? "Invalid currency symbol" : string.Empty;
            _status = new StatusDto(hasError, errorMessage);
        }

        /// <summary>
        /// Get the CryptoCurrencyId property.
        /// </summary>
        public string CryptoCurrencyId => _cryptoCurrencyId;

        /// <summary>
        /// Get the CryptoCurrencySymbol property.
        /// </summary>
        public string CryptoCurrencySymbol => _cryptoCurrencySymbol;

        /// <summary>
        /// Get the CryptoCurrencyName property.
        /// </summary>
        public string CryptoCurrencyName => _cryptoCurrencyName;

        /// <summary>
        /// Get the ExchangeRates property.
        /// </summary>
        public List<ExchangeRateDto> ExchangeRates => _exchangeRates;

        /// <summary>
        /// Gets the status
        /// </summary>
        public StatusDto Status => _status;
    }


}
