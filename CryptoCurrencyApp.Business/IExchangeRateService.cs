using CryptoCurrencyApp.Model.Model;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Service
{
    public interface IExchangeRateService
    {
        /// <summary>
        /// Gets the Exchange rate.
        /// </summary>
        /// <param name="amount">The amount to be converted</param>
        /// <param name="fromCurrency">The currency from</param>
        /// <param name="toCurrency">The currency to</param>
        /// <returns></returns>
        Task<ExchangeRateModel> GetExchangeRate(double amount, string fromCurrency, string toCurrency);

        /// <summary>
        /// Gets the app specific available currency to be converted
        /// </summary>
        /// <param name="currenciesToExclude">The currencies to be excluded</param>
        /// <returns></returns>
        string[] GetAvailableConversionsExcluding(params string[] currenciesToExclude);
    }
}
