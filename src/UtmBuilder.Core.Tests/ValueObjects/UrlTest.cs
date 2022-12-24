using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidUrlException))]
        [DataRow("")]
        [DataRow("spider-man")]
        public void ShouldReturnExceptionWhenUrlIsInvalid(string address)
        {
            new Url(address);
        }

        [TestMethod]
        [DataRow("http://example.com/articles?sort=ASC&page=2")]
        [DataRow("https://example.com")]
        public void ShouldNotReturnExceptionWhenUrlIsValid(string address)
        {
            new Url(address);
            Assert.IsTrue(true);
        }
    }
}