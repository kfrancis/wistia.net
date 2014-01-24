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
    public class ProjectTests
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
        public async Task CanGetListOfProjects()
        {
            // Act
            var result = await _dataClient.Projects.All();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<Project>));
            Assert.IsTrue(result.Count > 0);            
        }

        [TestMethod]
        public async Task CanGetSingleProject()
        {
            // Arrange
            var projects = await _dataClient.Projects.All();
            var firstProject = projects.FirstOrDefault();

            // Act
            var result = await _dataClient.Projects.GetById(firstProject.hashedId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Project));
            Assert.AreEqual(firstProject.hashedId, result.hashedId);
        }

        [TestMethod]
        public async Task CanGetSingleProjectStats()
        {
            // Arrange
            var projects = await _dataClient.Projects.All();
            var firstProject = projects.FirstOrDefault();

            // Act
            var result = await _statsClient.Projects.Get(firstProject.id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ProjectStats));
            Assert.IsTrue(result.hours_watched >= 0);
            Assert.IsTrue(result.load_count >= 0);
            Assert.IsTrue(result.number_of_videos >= 0);
            Assert.IsTrue(result.play_count >= 0);
        }

        [TestMethod]
        public async Task CanGetSingleProjectStatsByDate()
        {
            // Arrange
            var projects = await _dataClient.Projects.All();
            var firstProject = projects.FirstOrDefault();

            // Act
            var result = await _statsClient.Projects.GetByDate(firstProject.id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<ProjectStats>));
            Assert.IsTrue(result.Count > 0);
        }
    }
}
