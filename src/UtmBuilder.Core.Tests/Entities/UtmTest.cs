using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtmBuilder.Core.Tests.Entities
{
    [TestClass]
    public class UtmTest
    {

        private const string address = "https://example.com/test";
        private const string resultAddress = $"{address}?utm_source=source&utm_medium=medium&utm_campaign=name&utm_id=id&utm_term=term&utm_content=content";
        private readonly Url _url = new Url(address);
        private readonly Campaign _campaing = new Campaign("name", "source", "medium", "id", "term", "content");

        [TestMethod]
        public void ShouldReturnUrlFromUtm()
        {
            var utm = new Utm(_url, _campaing);
            Assert.AreEqual(resultAddress, (string)utm);
        }

        [TestMethod]
        public void ShouldReturnUtmFromUrl()
        {
            Utm utm = resultAddress;
            Assert.AreEqual(address, utm.Url.Address);
            Assert.AreEqual("name", utm.Campaign.Name);
            Assert.AreEqual("source", utm.Campaign.Source);
            Assert.AreEqual("medium", utm.Campaign.Medium);
            Assert.AreEqual("id", utm.Campaign.Id);
            Assert.AreEqual("term", utm.Campaign.Term);
            Assert.AreEqual("content", utm.Campaign.Content);
        }
    }
}