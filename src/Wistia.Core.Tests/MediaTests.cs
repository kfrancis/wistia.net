using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wistia.Core.Services.Data.Models;

namespace Wistia.Core.Services.Data.Tests
{
    [TestClass]
    public class MediaTests
    {
        private static WistiaDataClient _client;
        private static string _apiKey;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void MediaTestsInit(TestContext context)
        {
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
            _client = new WistiaDataClient(_apiKey);
        }

        [TestMethod]
        public async Task CanGetListOfMedia()
        {
            // Act
            var result = await _client.Media.All();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<Media>));
            Assert.IsTrue(result.Count > 0);    
        }
    }
}
