

using CryptoCurrencyApp.Infrastructure.Dto;
using CryptoCurrencyApp.Infrastructure.Logging;
using CryptoCurrencyApp.Model.Model;
using CryptoCurrencyApp.Service.Configuration;
using CryptoCurrencyApp.Service.DtoConverter;
using CryptoCurrencyApp.Service.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Service
{
    public class CryptoCurrenyService : ICryptoCurrenyService
    {
        private readonly ILogManager _logger;
        private readonly IExchangeRateService _exchangeRateService;
        private readonly IWebClient _webClient;
        private readonly ICoinMarketCapConfiguration _config;

        public CryptoCurrenyService(ILogManager logger, IWebClient webClient, IExchangeRateService exchangeRateService, ICoinMarketCapConfiguration config)
        {
            _logger = logger;
            _exchangeRateService = exchangeRateService;
            _webClient = webClient;
            _config = config;
        }

        public async Task<CrytoCurrencyRateDto> GetCryptoCurrencyRate(Dictionary<string, string> queryParams)
        {
            _logger.Information("Getting crypto currency.");

            var uri = _webClient.BuildUrl(_config.ApiRootUrl, _config.ApiQuotesUrl, queryParams);
            var result = await _webClient.GetWebData<CoinMarketCapCryptoCurrencyItemData>(uri, _config.CustomHeaders);

            if (result?.Status == null)
            {
                _logger.Error(@$"Error fetching data from crypto currency API | Invalid data received!");
                throw new InvalidOperationException();
            }
            else if (result.Status.ErrorCode != 0)
            {
                _logger.Error(@$"Error fetching data from crypto currency API | Error : {result.Status.ErrorCode} | Message : {result.Status.ErrorMessage}");
                throw new InvalidOperationException();
            }

            var cryptoCurrencyDto = await AddAllExchangeRates(result?.ConvertToCryptoCurrencyDto());
            return cryptoCurrencyDto;
        }

        private async Task<CrytoCurrencyRateDto> AddAllExchangeRates(CrytoCurrencyRateDto rateDto)
        {
            _logger.Information("Adding additional exchange rates.");

            if (rateDto?.ExchangeRates == null || !rateDto.ExchangeRates.Any())
            {
                return rateDto;
            }

            var rootCurrencyQuote = rateDto.ExchangeRates[0];
            var availableConversions = _exchangeRateService.GetAvailableConversionsExcluding(rootCurrencyQuote.CurrencyId)?.ToList();

            if (availableConversions != null && availableConversions.Any())
            {
                List<Task<ExchangeRateModel>> conversionTasks = new();
                availableConversions.ForEach(toCurrency =>
                {
                    conversionTasks.Add(_exchangeRateService.GetExchangeRate(rootCurrencyQuote.Rate, rootCurrencyQuote.CurrencyId, toCurrency));
                });

                try
                {

                    await Task.WhenAll(conversionTasks);
                }
                catch (AggregateException aggrEx)
                {
                    foreach (var ex in aggrEx.InnerExceptions)
                    {
                        _logger.Error(@$"Error getting the exchange rate {Environment.NewLine}{ex.InnerException}");
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(@$"Error getting the exchange rate {Environment.NewLine}{ex.InnerException}");
                    throw;
                }

                conversionTasks.ForEach(task=> rateDto.ExchangeRates.Add(new ExchangeRateDto(task.Result.Query.ToCurrency, task.Result.Result)));
            }
            return rateDto;
        }
    }
}
