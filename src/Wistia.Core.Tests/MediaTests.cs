using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wistia.Core.Services.Data.Models;
using Wistia.Core.Services.Stats.Models;

namespace Wistia.Core.Services.Data.Tests
{
    [TestClass]
    public class MediaTests
    {
        private static WistiaDataClient _dataClient;
        private static WistiaStatsClient _statsClient;
        private static string _apiKey;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void MediaTestsInit(TestContext context)
        {
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
            _dataClient = new WistiaDataClient(_apiKey);
            _statsClient = new WistiaStatsClient(_apiKey);
        }

        [TestMethod]
        public async Task CanGetListOfMedia()
        {
            // Act
            var result = await _dataClient.Media.All();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<Media>));
            Assert.IsTrue(result.Count > 0);    
        }

        [TestMethod]
        public async Task CanGetSingleMediaStats()
        {
            // Arrange
            var media = await _dataClient.Media.All();
            var firstMedia = media.FirstOrDefault();

            // Act
            var result = await _statsClient.Media.Get(firstMedia.id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(MediaStats));
            Assert.IsTrue(result.hours_watched > 0);
            Assert.IsTrue(result.load_count > 0);
            Assert.IsTrue(result.play_count > 0);
            Assert.IsTrue(result.engagement > 0);
            Assert.IsTrue(result.visitors > 0);
            Assert.IsTrue(result.play_rate > 0);
        }
    }
}
