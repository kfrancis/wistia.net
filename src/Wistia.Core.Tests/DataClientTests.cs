using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wistia.Core.Data;

namespace Wistia.Core.Tests
{
    [TestClass]
    public class DataClientTests
    {
        private static IWistiaDataClient _client;
        private static string _apiKey;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void WistiaDataClientTests(TestContext context)
        {
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
            _client = new WistiaDataClient(_apiKey);
        }

        [TestMethod]
        public async Task CanGetAccountDetails()
        {
            // Act
            var result = await _client.GetAccount();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Account));
            Assert.IsTrue(result.id > 0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.name));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.url));
        }
    }
}
