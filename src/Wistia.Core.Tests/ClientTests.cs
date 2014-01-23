using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wistia.Core.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void DoesBlankApiKeyThrowArgumentNullException()
        {
            try
            {
                Wistia.Core.WistiaClient client = new Wistia.Core.WistiaClient(apiKey: "");
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
