using CryptoCurrencyApp.Infrastructure.Dto;
using CryptoCurrencyApp.Infrastructure.Guard;
using CryptoCurrencyApp.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace CryptoCurrencyApp.Service.DtoConverter
{
    public static class CryptoCurrencyItemDataToCryptoCurrencyDtoConverter
    {
        /// <summary>
        /// Extension method to convert <see cref="CoinMarketCapCryptoCurrencyItemData"/> to <see cref="CrytoCurrencyRateDto"/>.
        /// </summary>
        /// <param name="coinMarketCapCryptoCurrencyItemData">CoinMarketCapCryptoCurrencyItemData</param>
        /// <returns></returns>
        public static CrytoCurrencyRateDto ConvertToCryptoCurrencyDto(this CoinMarketCapCryptoCurrencyItemData coinMarketCapCryptoCurrencyItemData)
        {
            Guard.AgainstNull(coinMarketCapCryptoCurrencyItemData, nameof(coinMarketCapCryptoCurrencyItemData));
            Guard.AgainstNull(coinMarketCapCryptoCurrencyItemData.DataList, nameof(coinMarketCapCryptoCurrencyItemData.DataList));

            var cryptoCurrentData = coinMarketCapCryptoCurrencyItemData.DataList.FirstOrDefault().Value;
            var rootCurrencyRate = coinMarketCapCryptoCurrencyItemData.DataList.FirstOrDefault().Value?.Quote.First();

            List<ExchangeRateDto> exchangeRates = new();
            if (rootCurrencyRate != null)
            {
                exchangeRates.Add(new ExchangeRateDto(rootCurrencyRate.Value.Key, rootCurrencyRate.Value.Value.Price));
            }

            return new CrytoCurrencyRateDto(cryptoCurrentData?.Id, cryptoCurrentData?.Symbol, cryptoCurrentData?.Name, exchangeRates);

        }

    }
}
