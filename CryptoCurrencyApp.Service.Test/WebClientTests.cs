using CryptoCurrencyApp.Infrastructure.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoCurrencyApp.Service.Test
{

    [TestClass]
    public class WebClientTests
    {
        private Mock<ILogManager> _logger;

        private readonly string RootUrl = @"https://testrandom.com";
        private readonly string PartUrl = @"/api/testapi";

        [TestInitialize]
        public void TestInitialize()
        {
            _logger = new Mock<ILogManager>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildUrl_When_Invoked_With_Null_RootURL_Throws_Exception()
        {
            //Arrange
            var webClient = CreateWebClient();

            //Act
            _ = webClient.BuildUrl(null, PartUrl, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildUrl_When_Invoked_With_Null_PartURL_Throws_Exception()
        {
            //Arrange
            var webClient = CreateWebClient();

            //Act
            _ = webClient.BuildUrl(RootUrl, null, null);
        }

        [TestMethod]
        public void BuildUrl_When_Invoked_With_RootUrl_And_PartUrl_Generates_Url()
        {
            //Arrange
            var webClient = CreateWebClient();

            //Act
            var result = webClient.BuildUrl(RootUrl, PartUrl, null);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual($@"{RootUrl}{PartUrl}", result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildUrl_When_Invoked_With_RootUrl_Ans_PartUrl_And_QueryParams_Generates_Url_WithQueryParams()
        {
            //Arrange
            var webClient = CreateWebClient();
            Dictionary<string, string> queryParams = new();
            queryParams.Add("testkey", "testvalue");
            queryParams.Add("anothertestkey", "anothertestvalue");

            //Act
            var result = webClient.BuildUrl(RootUrl, PartUrl, queryParams);

            //Assert
            var expectedUrl = @$"{RootUrl}{PartUrl}?{queryParams.ElementAt(0).Key}={queryParams.ElementAt(0).Value}&{queryParams.ElementAt(1).Key}={queryParams.ElementAt(1).Value}";
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUrl, result.AbsoluteUri);
        }

        private WebClient.WebClient CreateWebClient()
        {
            return new WebClient.WebClient(_logger.Object);
        }


    }
}
