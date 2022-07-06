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
    public class ExchangeRateServiceTests
    {
        private Mock<ILogManager> _logger;
        private Mock<IExchangeRateConfiguration> _config;
        private Mock<IWebClient> _webClient;

        private readonly string[] _currencies = new string[] { "USD", "EUR", "AUD", "GBP", "BRL" };
        private readonly double _inputRate = DoubleFixture.GetFixture();

        [TestInitialize]
        public void TestInitialize()
        {
            _logger = new Mock<ILogManager>();
            _config = new Mock<IExchangeRateConfiguration>();
            _webClient = new Mock<IWebClient>();

            SetupConfigMock();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetExchangeRate_When_Invoked_With_Null_FromCurrency_Throws_Exception()
        {
            //Arrange
            var exchangeService = CreateExchangeRateServiceInstance();

            //Act
            _ = await exchangeService.GetExchangeRate(_inputRate, null, _currencies[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetExchangeRate_When_Invoked_With_Null_ToCurrency_Throws_Exception()
        {
            //Arrange
            var exchangeService = CreateExchangeRateServiceInstance();

            //Act
            _ = await exchangeService.GetExchangeRate(_inputRate, _currencies[0], null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetExchangeRate_When_Invoked_With_Empty_FromCurrency_Throws_Exception()
        {
            //Arrange
            var exchangeService = CreateExchangeRateServiceInstance();

            //Act
            _ = await exchangeService.GetExchangeRate(_inputRate, string.Empty, _currencies[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetExchangeRate_When_Invoked_With_Empty_ToCurrency_Throws_Exception()
        {
            //Arrange
            var exchangeService = CreateExchangeRateServiceInstance();

            //Act
            _ = await exchangeService.GetExchangeRate(_inputRate, _currencies[0], string.Empty);
        }

        [TestMethod]
        public async Task GetExchangeRate_When_Invoked_With_ValidValue_Returns_ExchangeRate()
        {
            //Arrange
            var exchangeService = CreateExchangeRateServiceInstance();
            var expectedExchangeRateModel = CreateTestExchangeRateModel();
            SetupWebClientMock(expectedExchangeRateModel);

            //Act
            var result = await exchangeService.GetExchangeRate(_inputRate, _currencies[0], _currencies[0]);

            //Assert
            var areModelEqual = expectedExchangeRateModel.Equals(result);
            Assert.IsTrue(areModelEqual);
        }

        [DataTestMethod]
        [DataRow("USD", null, null)]
        [DataRow("USD", "EUR", null)]
        [DataRow("USD", "EUR", "GBP")]
        public void TestMethod1(string value1, string value2, string value3)
        {
            //Arrange
            var exchangeService = CreateExchangeRateServiceInstance();

            //Act 
            var result = exchangeService.GetAvailableConversionsExcluding(value1, value2, value3);

            //Assert
            int excludeCouter = 0;
            _ = (value1 == null ? 0 : ++excludeCouter) + (value2 == null ? 0 : ++excludeCouter) + (value3 == null ? 0 : ++excludeCouter);
            int expectedCount = _currencies.Length - excludeCouter;

            Assert.AreEqual(expectedCount, result.Length);
            Assert.IsTrue(!result.Contains(value1));
            Assert.IsTrue(!result.Contains(value2));
            Assert.IsTrue(!result.Contains(value3));
        }

        private ExchangeRateService CreateExchangeRateServiceInstance()
        {
            return new ExchangeRateService(_logger.Object, _config.Object, _webClient.Object);
        }

        private ExchangeRateModel CreateTestExchangeRateModel()
        {
            var exchangeModel = new ExchangeRateModel();
            exchangeModel.Result = DoubleFixture.GetFixture();
            exchangeModel.Query = new ExchangeQuery()
            {
                FromCurrency = _currencies[0],
                Amount = DoubleFixture.GetFixture(),
                ToCurrency = _currencies[1]
            };
            return exchangeModel;
        }

        private void SetupWebClientMock(ExchangeRateModel exchangeRateModel)
        {
            _webClient.Setup(x => x.BuildUrl(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, string>>()))
                .Returns(new System.Uri(@"https://testuri.com"));

            _webClient.Setup(x => x.GetWebData<ExchangeRateModel>(It.IsAny<System.Uri>(), It.IsAny<Dictionary<string, string>>()))
                .Returns(Task.FromResult(exchangeRateModel));
        }

        private void SetupConfigMock()
        {
            _config.SetupGet(x => x.ApiQuotesUrl).Returns(StringFixture.GetFixture());
            _config.SetupGet(x => x.ApiRootUrl).Returns(StringFixture.GetFixture());
            _config.SetupGet(x => x.AvailableCurrencyConversions).Returns(_currencies);
        }
    }
}
