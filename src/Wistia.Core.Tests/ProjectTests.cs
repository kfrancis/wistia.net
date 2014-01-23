using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wistia.Core.Models;
using System.Linq;

namespace Wistia.Core.Tests
{
    [TestClass]
    public class ProjectTests
    {
        private static WistiaClient _client;
        private static string _apiKey;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void AccountTestsInit(TestContext context)
        {
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
            _client = new WistiaClient(_apiKey);
        }

        [TestMethod]
        public async Task CanGetListOfProjects()
        {
            // Act
            var result = await _client.Projects.All();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<Project>));
            Assert.IsTrue(result.Count > 0);            
        }

        [TestMethod]
        public async Task CanGetSingleProject()
        {
            // Arrange
            var projects = await _client.Projects.All();
            var firstProject = projects.FirstOrDefault();

            // Act
            var result = await _client.Projects.GetById(firstProject.hashedId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Project));
            Assert.AreEqual(firstProject.hashedId, result.hashedId);
        }
    }
}
