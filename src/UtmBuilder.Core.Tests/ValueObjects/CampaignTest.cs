using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class CampaignTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCampaignException))]
        [DataRow("", "source", "medium")]
        [DataRow("name", "", "medium")]
        [DataRow("name", "source", "")]
        [DataRow("", "", "")]
        public void ShouldReturnExceptionWhenCampaignIsInvalid(string name, string source, string medium)
        {
            new Campaign(name, source, medium);
        }

        [TestMethod]
        public void ShouldNotReturnExceptionWhenCampaignIsValid()
        {
            new Campaign("name", "source", "medium");
            Assert.IsTrue(true);
        }
    }
}