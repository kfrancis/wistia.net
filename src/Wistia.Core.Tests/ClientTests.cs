using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wistia.Core.Services.Data.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void DoesBlankApiKeyThrowArgumentNullException()
        {
            try
            {
                Wistia.Core.WistiaDataClient client = new Wistia.Core.WistiaDataClient(apiKey: "");
                Assert.Fail("Expected an exception to be thrown for the blank api key");
            }
            catch (ArgumentNullException argNullEx)
            {
                Assert.IsNotNull(argNullEx);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected an ArgumentNullException");
            }
        }
    }
}
