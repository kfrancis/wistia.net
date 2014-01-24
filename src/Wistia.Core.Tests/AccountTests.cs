using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wistia.Core.Services.Data.Models;
using Wistia.Core.Services.Stats.Models;

namespace Wistia.Core.Services.Data.Tests
{
    [TestClass]
    public class AccountTests
    {
        private static WistiaDataClient _dataClient;
        private static WistiaStatsClient _statsClient;
        private static string _apiKey;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void AccountTestsInit(TestContext context)
        {
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
            _dataClient = new WistiaDataClient(_apiKey);
            _statsClient = new WistiaStatsClient(_apiKey);
        }

        [TestMethod]
        public async Task CanGetAccountDetails()
        {
            // Act
            var result = await _dataClient.Account.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Account));
            Assert.IsTrue(result.id > 0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.name));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.url));
        }

        [TestMethod]
        public async Task CanGetAccountStats()
        {
            // Act
            var result = await _statsClient.Account.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AccountStats));
            Assert.IsTrue(result.load_count > 0);
            Assert.IsTrue(result.play_count > 0);
            Assert.IsTrue(result.hours_watched > 0);
        }
    }
}
