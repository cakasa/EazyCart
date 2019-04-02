using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class CityBusinessUnitTests
    {
        [TestMethod]
        public void GetAllCities_ReturnsAsAList()
        {
            // Arrange
            var countryData = new List<Country>
            {
                new Country {Name = "Bulgaria", Id = 1},
                new Country {Name = "Romania", Id = 2}
            }.AsQueryable();

            var cityData = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1},
                new City {Name = "TestCity2", Id = 2,}
            }.AsQueryable();

            var supplierData = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countryData.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countryData.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countryData.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countryData.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cityData.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cityData.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cityData.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cityData.GetEnumerator());

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(supplierData.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(supplierData.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(supplierData.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(supplierData.GetEnumerator());


            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);

            // Act
            var cities = cityBusiness.GetAll();

            // Assert
            Assert.AreEqual(1, cities[0].Id, "Ids do not match.");
        }

        [TestMethod]
        public void GetOneCity_ReturnsACity()
        {
            // Arrange
            var countryData = new List<Country>
            {
                new Country {Name = "Bulgaria", Id = 1},
                new Country {Name = "Romania", Id = 2}
            }.AsQueryable();

            var cityData = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1},
                new City {Name = "TestCity2", Id = 2,}
            }.AsQueryable();

            var supplierData = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countryData.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countryData.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countryData.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countryData.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cityData.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cityData.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cityData.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cityData.GetEnumerator());

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(supplierData.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(supplierData.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(supplierData.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(supplierData.GetEnumerator());


            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);

            // Act
            var city = cityBusiness.Get(1);

            // Assert
            Assert.AreEqual(1, city.Id, "Ids do not match.");
        }

        [TestMethod]
        public void GetAllNamesCities_ReturnsAsAList()
        {
            // Arrange
            var countryData = new List<Country>
            {
                new Country {Name = "Bulgaria", Id = 1},
                new Country {Name = "Romania", Id = 2}
            }.AsQueryable();

            var cityData = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1},
                new City {Name = "TestCity2", Id = 2,}
            }.AsQueryable();

            var supplierData = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countryData.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countryData.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countryData.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countryData.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cityData.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cityData.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cityData.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cityData.GetEnumerator());

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(supplierData.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(supplierData.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(supplierData.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(supplierData.GetEnumerator());


            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);

            // Act
            string expectedName = "TestCity1";
            var cities = cityBusiness.GetAllNames();

            // Assert
            Assert.AreEqual(expectedName, cities[0], "Cities names do not match.");
        }

        [TestMethod]
        public void GetAllNamesCitiesFromACountry_ReturnsAsAList()
        {
            // Arrange
            var countryData = new List<Country>
            {
                new Country {Name = "Bulgaria", Id = 1},
                new Country {Name = "Romania", Id = 2}
            }.AsQueryable();

            var cityData = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1},
                new City {Name = "TestCity2", Id = 2,}
            }.AsQueryable();

            var supplierData = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countryData.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countryData.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countryData.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countryData.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cityData.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cityData.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cityData.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cityData.GetEnumerator());

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(supplierData.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(supplierData.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(supplierData.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(supplierData.GetEnumerator());


            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);

            // Act
            string expectedName = "TestCity1";
            var cities = cityBusiness.GetAllCityNamesFromCountry("Bulgaria");

            // Assert
            Assert.AreEqual(expectedName, cities[0], "Cities names do not match.");
        }

        [TestMethod]
        public void GetCityNameBySupplier_SuccessfullyReturnsACity()
        {
            // Arrange
            var cityData = new List<City>
            {
                new City {Name = "TestCity1", Id = 1},
                new City {Name = "TestCity2", Id = 2,}
            }.AsQueryable();

            var supplierData = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1}
            }.AsQueryable();

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cityData.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cityData.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cityData.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cityData.GetEnumerator());

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(supplierData.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(supplierData.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(supplierData.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(supplierData.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);

            // Act
            string expectedName = "TestCity1";
            string supplierName = "TestSupplier1";
            var cityName = cityBusiness.GetNameBySupplier(supplierName);

            // Assert
            Assert.AreEqual(expectedName, cityName, "Cities names do not match.");
        }

        [TestMethod]
        public void Add_SuccessfullyAddsCity_WhenIdDoesNotExist()
        {
            // Arrange
            var countryData = new List<Country>
            {
                new Country {Name = "TestCountry1", Id = 1}
            }.AsQueryable();

            var cityData = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countryData.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countryData.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countryData.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countryData.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cityData.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cityData.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cityData.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cityData.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);

            // Act
            cityBusiness.Add("TestCity1", 1, "TestCountry1");

            // Assert
            mockDbCitySet.Verify(m => m.Add(It.IsAny<City>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Add_ThrowsException_WhenCountryIdDoesNotExist()
        {
            // Arrange
            var countryData = new List<Country>
            {
                new Country {Name = "Bulgaria", Id = 1}
            }.AsQueryable();

            var cityData = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countryData.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countryData.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countryData.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countryData.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cityData.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cityData.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cityData.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cityData.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                cityBusiness.Add("TestCity1", 1, "TestCountry1");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format("Such country does not exist.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void Add_ThrowsException_WhenCityAlreadyExists()
        {
            // Arrange
            var countryData = new List<Country>
            {
                new Country {Name = "TestCountry1", Id = 1}
            }.AsQueryable();

            var cityData = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1},
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countryData.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countryData.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countryData.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countryData.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cityData.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cityData.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cityData.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cityData.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.SaveChanges()).Throws(new Exception());
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);
            int duplicateId = 1;

            // Act & Assert
            try
            {
                cityBusiness.Add("TestCity1", 1, "TestCountry1");
                cityBusiness.Add("TestCity2", 1, "TestCountry1");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format($"City with ID {duplicateId} already exists.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void Delete_SuccessfullyDeletesCity_WhenNoSuppliersAreRelated()
        {
            // Arrange
            var cities = new List<City>
            {
                new City {Name = "TestCity1", Id = 1},
                new City {Name = "TestCity2", Id = 2 }
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", CityId = 1}
            }.AsQueryable();

            var citymockDbSet = new Mock<DbSet<City>>();
            citymockDbSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            citymockDbSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            citymockDbSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            citymockDbSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var suppliermockDbSet = new Mock<DbSet<Supplier>>();
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(citymockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(suppliermockDbSet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);

            // Act
            int idToDelete = 2;
            cityBusiness.Delete(idToDelete);

            // Assert
            citymockDbSet.Verify(m => m.Remove(It.IsAny<City>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Delete_ThrowsException_WhenSuppliersAreRelated()
        {
            // Arrange
            var cities = new List<City>
            {
                new City {Name = "TestCategory1", Id = 1},
                new City {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", CityId = 1}
            }.AsQueryable();

            var citymockDbSet = new Mock<DbSet<City>>();
            citymockDbSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            citymockDbSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            citymockDbSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            citymockDbSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var suppliermockDbSet = new Mock<DbSet<Supplier>>();
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(citymockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(suppliermockDbSet.Object);

            var cityBusiness = new CityBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                int idToDelete = 1;
                cityBusiness.Delete(idToDelete);
                Assert.Fail("No exception was thrown.");
            }

            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format("One or more suppliers are related to this city.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }
    }
}
