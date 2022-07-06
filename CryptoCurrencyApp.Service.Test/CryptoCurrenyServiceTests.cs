using CryptoCurrencyApp.Infrastructure.Logging;
using CryptoCurrencyApp.Model.Model;
using CryptoCurrencyApp.Service.Configuration;
using CryptoCurrencyApp.Service.WebClient;
using CryptoCurrencyApp.TestInfrastructure.TestFixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Service.Test
{
    [TestClass]
    public class CryptoCurrenyServiceTests
    {

        private Mock<ILogManager> _logger;
        private Mock<IWebClient> _webClient;
        private Mock<ICoinMarketCapConfiguration> _config;
        private Mock<IExchangeRateService> _exchangeRateService;

        private readonly string[] _currencies = new string[] { "USD", "EUR", "AUD", "GBP", "BRL" };

        [TestInitialize]
        public void TestInitialize()
        {
            _logger = new Mock<ILogManager>();
            _config = new Mock<ICoinMarketCapConfiguration>();
            _webClient = new Mock<IWebClient>();
            _exchangeRateService = new Mock<IExchangeRateService>();

            SetupConfigMock();
            SetupExchangeRateServiceMock();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetCryptoCurrency_When_External_Api_Call_Returns_ErrorCode_Throws_Exception()
        {
            //Arrange
            var cryptoCurrenyService = CreateExchangeRateServiceInstance();
            var cryptoCurrencyItemModel = CryptoCurrencyItemModel(10);
            SetupWebClientMock(cryptoCurrencyItemModel);

            //Act
            _ = await cryptoCurrenyService.GetCryptoCurrencyRate(new Dictionary<string, string>());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetCryptoCurrency_When_External_Api_Call_Returns_Null_Throws_Exception()
        {
            //Arrange
            var cryptoCurrenyService = CreateExchangeRateServiceInstance();
            SetupWebClientMock(null);

            //Act
            _ = await cryptoCurrenyService.GetCryptoCurrencyRate(new Dictionary<string, string>());
        }

        [TestMethod]
        public async Task GetCryptoCurrency_When_External_Api_Call_Succeed_Returns_Crypto_Currency_Data_With_All_ExchangeRates()
        {
            //Arrange
            var cryptoCurrenyService = CreateExchangeRateServiceInstance();
            var cryptoCurrencyItemModel = CryptoCurrencyItemModel(errorCode: 0);
            SetupWebClientMock(cryptoCurrencyItemModel);

            //Act
            var result = await cryptoCurrenyService.GetCryptoCurrencyRate(new Dictionary<string, string>());

            //Assert
            Assert.AreEqual(cryptoCurrencyItemModel.DataList.First().Value.Symbol, result.CryptoCurrencySymbol);
            foreach (var currency in _currencies)
            {
                Assert.IsTrue(result.ExchangeRates.Count(x => x.CurrencyId == currency) == 1);
            }
        }

        private CryptoCurrenyService CreateExchangeRateServiceInstance()
        {
            return new CryptoCurrenyService(_logger.Object, _webClient.Object, _exchangeRateService.Object, _config.Object);
        }
        private CoinMarketCapCryptoCurrencyItemData CryptoCurrencyItemModel(int errorCode)
        {
            CurrenyQuoteInfoModel currenyQuoteInfoModel = new();
            currenyQuoteInfoModel.Price = DoubleFixture.GetFixture();

            var cryptoCurrencyDataModel = new CryptoCurrencyDataModel();
            cryptoCurrencyDataModel.Id = "1";
            cryptoCurrencyDataModel.Name = "BitCoin";
            cryptoCurrencyDataModel.Symbol = "BTC";
            cryptoCurrencyDataModel.Quote = new Dictionary<string, CurrenyQuoteInfoModel>() { { _currencies[0], currenyQuoteInfoModel } };

            var coinMarketCapCryptoCurrencyItemData = new CoinMarketCapCryptoCurrencyItemData();
            coinMarketCapCryptoCurrencyItemData.Status = new StatusModel() { ErrorCode = errorCode };
            coinMarketCapCryptoCurrencyItemData.DataList = new Dictionary<string, CryptoCurrencyDataModel>();
            coinMarketCapCryptoCurrencyItemData.DataList.Add("BTC", cryptoCurrencyDataModel); ;
            return coinMarketCapCryptoCurrencyItemData;
        }

        private void SetupConfigMock()
        {
            _config.SetupGet(x => x.ApiQuotesUrl).Returns(StringFixture.GetFixture());
            _config.SetupGet(x => x.ApiRootUrl).Returns(StringFixture.GetFixture());
            _config.SetupGet(x => x.CurrencyConversions).Returns(_currencies[0]);
        }

        private void SetupWebClientMock(CoinMarketCapCryptoCurrencyItemData cryptoCurrencyModel)
        {
            _webClient.Setup(x => x.BuildUrl(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, string>>()))
                .Returns(new System.Uri(@"https://testuri.com"));

            _webClient.Setup(x => x.GetWebData<CoinMarketCapCryptoCurrencyItemData>(It.IsAny<System.Uri>(), It.IsAny<Dictionary<string, string>>()))
                .Returns(Task.FromResult(cryptoCurrencyModel));
        }

        private ExchangeRateModel CreateTestExchangeRateModel(string fromCurrency, string toCurrency)
        {
            var exchangeModel = new ExchangeRateModel();
            exchangeModel.Result = DoubleFixture.GetFixture();
            exchangeModel.Query = new ExchangeQuery()
            {
                FromCurrency = fromCurrency,
                Amount = DoubleFixture.GetFixture(),
                ToCurrency = toCurrency
            };
            return exchangeModel;
        }

        private void SetupExchangeRateServiceMock()
        {
            var currencyList = _currencies.ToList();
            currencyList.Remove(_currencies.Single(x => x == _currencies[0]));
            _exchangeRateService.Setup(x => x.GetAvailableConversionsExcluding(new string[] { It.IsAny<string>() })).Returns(currencyList.ToArray());

            _exchangeRateService.Setup(x => x.GetExchangeRate(It.IsAny<Double>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((double val, string from, string to) => Task.FromResult(CreateTestExchangeRateModel(from, to)));
        }

    }
}
