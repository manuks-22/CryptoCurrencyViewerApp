using CryptoCurrencyApp.Extension;
using CryptoCurrencyApp.Infrastructure.Dto;
using CryptoCurrencyApp.Infrastructure.Logging;
using CryptoCurrencyApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CryptoCurrencyViewApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoinMarketCapCryptoCurrencyController : ControllerBase
    {
        private readonly ICryptoCurrenyService _cryptoCurrenyService;
        private readonly ILogManager _logger;

        public CoinMarketCapCryptoCurrencyController(ILogManager logger,
            ICryptoCurrenyService cryptoCurrenyService)
        {
            _logger = logger;
            _cryptoCurrenyService = cryptoCurrenyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CrytoCurrencyRateDto>> GetQuotes()
        {
            _logger.Information("Executing method GetQuotes");

            var queryPairs = Request.Query.ToParamDictionary();
            if (queryPairs.Count == 0)
            {
                return BadRequest();
            }

            return await _cryptoCurrenyService.GetCryptoCurrencyRate(queryPairs);
        }
    }
}
