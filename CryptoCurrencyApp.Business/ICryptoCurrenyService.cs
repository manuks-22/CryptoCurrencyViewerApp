using CryptoCurrencyApp.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Service
{
    public interface ICryptoCurrenyService
    {
        /// <summary>
        /// Gets the cryto currency value with all the App specified exchange rates.
        /// </summary>
        /// <param name="queryParams">The query parameters.</param>
        /// <returns></returns>
        Task<CrytoCurrencyRateDto> GetCryptoCurrencyRate(Dictionary<string, string> queryParams);
    }
}
