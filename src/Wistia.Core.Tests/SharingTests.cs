using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wistia.Core.Services.Data.Models;

namespace Wistia.Core.Tests
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
            // Arrange
            var projects = await _client.Projects.All();
            var firstProject = projects.FirstOrDefault();
            Assert.IsNotNull(firstProject);

            // Act
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
            Assert.IsNotNull(firstProject);
            var projectSharings = await _client.Sharings.All(firstProject.hashedId);
            Assert.IsNotNull(projectSharings);
            var firstProjectSharings = projectSharings.FirstOrDefault();
            Assert.IsNotNull(firstProjectSharings);

            // Act
            var result = await _client.Sharings.GetById(firstProject.hashedId, firstProjectSharings.id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Sharing));
            Assert.AreEqual(firstProjectSharings.id, result.id);
        }
    }
}
