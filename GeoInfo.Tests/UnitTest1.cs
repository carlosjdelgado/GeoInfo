using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoInfo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private GeoInfo geoInfo;

        [TestInitialize]
        public void Initialize()
        {
            geoInfo = new GeoInfo();
        }

        [TestMethod]
        public void TestMethod1()
        {
            geoInfo = new GeoInfo();
            var euro = geoInfo.Currencies.GetByCode("EUR");
            var pound = geoInfo.Currencies.GetByCode("GBP");
            var dollar = geoInfo.Currencies.GetByCode("USD");

            Assert.AreEqual("Euro", euro.Name);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var spain = geoInfo.Countries.GetByName("España");
            var madrid = geoInfo.Cities.GetByNameAndCountryCode("Madrid","ES");
            var countryOfMadrid = madrid.Country;
            Assert.IsTrue(true);
        }

    }
}
