using CryptoCurrencyApp.Model.Model;
using CryptoCurrencyApp.Service.DtoConverter;
using CryptoCurrencyApp.TestInfrastructure.TestFixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoCurrencyApp.Service.Test
{
    [TestClass]
    public class CryptoCurrencyItemDataToCryptoCurrencyDtoConverterTests
    {
        [TestMethod]
        public void CryptoItemDataModel_When_Converted_To_Dto_Returns_CryptoCurrencyDto()
        {
            //Arrange
            var cryptoCurrencyDataModel = CryptoCurrencyItemModel();

            //Act
            var cryptoCurrencyDto = cryptoCurrencyDataModel.ConvertToCryptoCurrencyDto();

            //Assert
            Assert.IsNotNull(cryptoCurrencyDto);
            Assert.AreEqual(cryptoCurrencyDataModel.DataList.ElementAt(0).Value.Symbol, cryptoCurrencyDto.CryptoCurrencySymbol);
            Assert.AreEqual(cryptoCurrencyDataModel.DataList.ElementAt(0).Value.Id, cryptoCurrencyDto.CryptoCurrencyId);
            Assert.AreEqual(cryptoCurrencyDataModel.DataList.ElementAt(0).Value.Name, cryptoCurrencyDto.CryptoCurrencyName);
            Assert.AreEqual(cryptoCurrencyDataModel.DataList.ElementAt(0).Value.Quote.ElementAt(0).Key, cryptoCurrencyDto.ExchangeRates[0].CurrencyId);
            Assert.AreEqual(cryptoCurrencyDataModel.DataList.ElementAt(0).Value.Quote.ElementAt(0).Value.Price, cryptoCurrencyDto.ExchangeRates[0].Rate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CryptoItemDataModel_With_Null_DataList_When_Converted_To_Dto_Throws_Exception()
        {
            //Arrange
            var cryptoCurrencyDataModel = CryptoCurrencyItemModel();
            cryptoCurrencyDataModel.DataList = null;

            //Act
            _ = cryptoCurrencyDataModel.ConvertToCryptoCurrencyDto();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CryptoItemDataModel_With_Null_Quote_When_Converted_To_Dto_Throws_Exception()
        {
            //Arrange
            var cryptoCurrencyDataModel = CryptoCurrencyItemModel();
            cryptoCurrencyDataModel.DataList.First().Value.Quote = null;

            //Act
            _ = cryptoCurrencyDataModel.ConvertToCryptoCurrencyDto();

        } 

        private CoinMarketCapCryptoCurrencyItemData CryptoCurrencyItemModel()
        {
            CurrenyQuoteInfoModel currenyQuoteInfoModel = new();
            currenyQuoteInfoModel.Price = DoubleFixture.GetFixture();

            var cryptoCurrencyDataModel = new CryptoCurrencyDataModel();
            cryptoCurrencyDataModel.Id = "1";
            cryptoCurrencyDataModel.Name = "BitCoin";
            cryptoCurrencyDataModel.Symbol = "BTC";
            cryptoCurrencyDataModel.Quote = new Dictionary<string, CurrenyQuoteInfoModel>() { { "0", currenyQuoteInfoModel } };

            var coinMarketCapCryptoCurrencyItemData = new CoinMarketCapCryptoCurrencyItemData();
            coinMarketCapCryptoCurrencyItemData.Status = new StatusModel() { ErrorCode = 0 };
            coinMarketCapCryptoCurrencyItemData.DataList = new Dictionary<string, CryptoCurrencyDataModel>();
            coinMarketCapCryptoCurrencyItemData.DataList.Add("BTC", cryptoCurrencyDataModel); ;
            return coinMarketCapCryptoCurrencyItemData;
        }
    }
}
