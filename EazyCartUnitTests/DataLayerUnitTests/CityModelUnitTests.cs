using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;

namespace EazyCartUnitTests.DataLayerUnitTests
{
    [TestClass]
    public class CityModelUnitTests
    {
        [TestMethod]
        public void CityConstructorTest()
        {
            // Arrange & Act
            var city = new City();

            // Assert
            Assert.IsNotNull(city, "City Constructor Not Working");
        }

        [TestMethod]
        public void CitySetIdTest()
        {
            // Arrange 
            var city = new City();

            // Act
            city.Id = 2;

            // Assert
            Assert.Equals(city.Id == 2, "City Id Not Set");
        }

        /*
            public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
         */
    }
}
