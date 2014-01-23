using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wistia.Core.Models;

namespace Wistia.Core.Tests
{
    [TestClass]
    public class AccountTests
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
        public async Task CanGetAccountDetails()
        {
            // Act
            var result = await _client.Account.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Account));
            Assert.IsTrue(result.id > 0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.name));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.url));
        }
    }
}
