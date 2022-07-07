using System.Collections.Generic;
using System.Linq;

namespace CryptoCurrencyApp.Infrastructure.Dto
{
    public record CrytoCurrencyRateDto
    {
        /// <summary>
        /// Get the CryptoCurrencyId property.
        /// </summary>
        public string CryptoCurrencyId { get; init; }

        /// <summary>
        /// Get the CryptoCurrencySymbol property.
        /// </summary>
        public string CryptoCurrencySymbol { get; init; }

        /// <summary>
        /// Get the CryptoCurrencyName property.
        /// </summary>
        public string CryptoCurrencyName { get; init; }

        /// <summary>
        /// Get the ExchangeRates property.
        /// </summary>
        public List<ExchangeRateDto> ExchangeRates { get; init; }

        /// <summary>
        /// Gets the status
        /// </summary>
        public StatusDto Status { get; init; }

        public CrytoCurrencyRateDto(string cryptoCurrencyId, string cryptoCurrencySymbol, string cryptoCurrencyName, IEnumerable<ExchangeRateDto> exchangeRates)
        {
            CryptoCurrencyId = cryptoCurrencyId;
            CryptoCurrencySymbol = cryptoCurrencySymbol;
            CryptoCurrencyName = cryptoCurrencyName;
            if (exchangeRates != null)
                ExchangeRates = exchangeRates.ToList();

            var hasError = CryptoCurrencyId == null;
            var errorMessage = hasError ? "Invalid currency symbol" : string.Empty;
            Status = new StatusDto(hasError, errorMessage);
        }


    }


}
