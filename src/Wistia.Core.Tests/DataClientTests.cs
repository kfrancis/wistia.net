using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wistia.Core.Data;

namespace Wistia.Core.Tests
{
    [TestClass]
    public class DataClientTests
    {
        private static WistiaDataClient _client;
        private static string _apiKey;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void WistiaDataClientTests(TestContext context)
        {
            _apiKey = "AvJQsrmfwSe4_eSLugsqhHL9F7NdEAyEm8J7Vi4FSYbcdVGAk0T9kM3UtyElbcLf";
            _client = new WistiaDataClient(_apiKey);

        }

        [TestMethod]
        public async Task CanConnect()
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
