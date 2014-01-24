using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wistia.Core.Services.Data.Models;

namespace Wistia.Core.Services.Data.Tests
{
    [TestClass]
    public class SharingTests
    {
        private static WistiaDataClient _client;
        private static string _apiKey;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void SharingTestsInit(TestContext context)
        {
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
            _client = new WistiaDataClient(_apiKey);
        }

        [TestMethod]
        public async Task CanGetListOfSharings()
        {
            // Act
            var projects = await _client.Projects.All();
            var firstProject = projects.FirstOrDefault();
            var result = await _client.Sharings.All(firstProject.hashedId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<Sharing>));
            Assert.IsTrue(result.Count > 0);            
        }

        [TestMethod]
        public async Task CanGetSingleSharing()
        {
            // Arrange
            var projects = await _client.Projects.All();
            var firstProject = projects.FirstOrDefault();
            var projectSharings = await _client.Sharings.All(firstProject.hashedId);

            // Act
            var result = await _client.Sharings.GetById(firstProject.hashedId, projectSharings.FirstOrDefault().id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Sharing));
            Assert.AreEqual(projectSharings.FirstOrDefault().id, result.id);
        }
    }
}
