using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class CountryBusinessUnitTests
    {
        // TODO: UPDATE TESTS WITH PROPER VALUES

        [TestMethod]
        public void GetCountry_ReturnsACountry_WhichIsNotNull()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country { Name = "TestCountry1", Id = 1 },
                new Country { Name = "TestCountry2", Id = 2},
                new Country { Name = "TestCountry3", Id = 3 },
            }.AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);

            var countryBusiness = new CountryBusiness(mockContext.Object);

            // Act
            int idToGet = 2;
            var country = countryBusiness.Get(idToGet);

            // Assert
            string expectedCountryName = "TestCountry2";
            Assert.IsNotNull(country, "Country could not be extracted.");
            Assert.AreEqual(expectedCountryName, country.Name, "Names do not match.");
        }

        [TestMethod]
        public void GetAll_ReturnsACorrectListOfCountries_WhenNotEmpty()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country { Name = "TestCountry1", Id = 1 },
                new Country { Name = "TestCountry2", Id = 2},
                new Country { Name = "TestCountry3", Id = 3 },
            }.AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);

            var countryBusiness = new CountryBusiness(mockContext.Object);

            // Act
            var allCountries = countryBusiness.GetAll();

            // Assert
            string expectedFirstCountryName = "TestCountry1";
            string expectedSecondCountryName = "TestCountry2";
            string expectedThirdCountryName = "TestCountry3";
            Assert.AreEqual(expectedFirstCountryName, allCountries[0].Name, "First names do not match.");
            Assert.AreEqual(expectedSecondCountryName, allCountries[1].Name, "Second names do not match.");
            Assert.AreEqual(expectedThirdCountryName, allCountries[2].Name, "Third names do not match");
        }

        [TestMethod]
        public void GetAll_ReturnsAnEmptyList_WhenThereAreNoCountries()
        {
            // Arrange
            var countries = new List<Country>().AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);

            var countryBusiness = new CountryBusiness(mockContext.Object);

            // Act
            var allCountries = countryBusiness.GetAll();

            // Assert
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, allCountries.Count, "List of all countries is not empty");
        }

        [TestMethod]
        public void GetAllNames_ReturnsACorrectListOfCountryNames_WhenNotEmpty()
        {
            var countries = new List<Country>
            {
                new Country { Name = "TestCountry1", Id = 1 },
                new Country { Name = "TestCountry2", Id = 2},
                new Country { Name = "TestCountry3", Id = 3 },
            }.AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);

            var countryBusiness = new CountryBusiness(mockContext.Object);

            // Act
            var allCountryNames = countryBusiness.GetAllNames();

            // Assert
            string expectedFirstCountryName = "TestCountry1";
            string expectedSecondCountryName = "TestCountry2";
            string expectedThirdCountryName = "TestCountry3";
            Assert.AreEqual(expectedFirstCountryName, allCountryNames[0], "First names do not match.");
            Assert.AreEqual(expectedSecondCountryName, allCountryNames[1], "Second names do not match.");
            Assert.AreEqual(expectedThirdCountryName, allCountryNames[2], "Third names do not match");
        }

        [TestMethod]
        public void GetAllNames_ReturnsAnEmptyList_WhenThereAreNoCountries()
        {
            // Arrange
            var countries = new List<Country>().AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);

            var countryBusiness = new CountryBusiness(mockContext.Object);

            // Act
            var allCountryNames = countryBusiness.GetAllNames();

            // Assert
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, allCountryNames.Count, "List of all country names is not empty");
        }

        [TestMethod]
        public void GetNameBySupplier()
        {
            // Arrange
            var countries = new List<Country>()
            {
                new Country() {Id = 1, Name = "TestCountry1"},
                new Country() {Id = 2, Name = "TestCountry2"},
            }.AsQueryable();

            var cities = new List<City>()
            {
                new City() {Id = 1, Name = "TestCity1", CountryId = 1},
                new City() {Id = 2, Name = "TestCity2", CountryId = 2},
            }.AsQueryable();

            var suppliers = new List<Supplier>()
            {
                new Supplier() {Id = 1, Name = "TestSupplier1", CityId = 1},
                new Supplier() {Id = 2, Name = "TestSupplier2", CityId = 2},
            }.AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var cityMockDbSet = new Mock<DbSet<City>>();
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);
            mockContext.Setup(c => c.Cities).Returns(cityMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);

            var countryBusiness = new CountryBusiness(mockContext.Object);

            // Act
            string supplierName = "TestSupplier1";
            string actualCountryName = countryBusiness.GetNameBySupplier(supplierName);

            // Assert
            string expectedCountryName = "TestCountry1";
            Assert.AreEqual(expectedCountryName, actualCountryName, "Country names do not match.");
        }

        [TestMethod]
        public void AddCountry_SuccessfullyAddsACountry_WhenAllValuesAreCorrect()
        {
            // Arrange
            var countries = new List<Country>().AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Countries).Returns(countryMockDbSet.Object);

            var countryBusiness = new CountryBusiness(mockContext.Object);
            

            // Act
            countryBusiness.Add("TestCountry", 1);

            // Assert
            countryMockDbSet.Verify(m => m.Add(It.IsAny<Country>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void AddCountry_ThrowsArgumentException_WhenIdIsADuplicate()
        {
            // Arrange
            int duplicateId = 1;
            var countries = new List<Country>
            {
                new Country { Name = "TestCountry1", Id = duplicateId},
            }.AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);
            mockContext.Setup(c => c.SaveChanges()).Throws(new Exception());
            var countryBusiness = new CountryBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                countryBusiness.Add("TestCountry1", duplicateId);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = string.Format("Country with ID {0} already exists.", duplicateId);
                Assert.AreEqual(expectedMessage, exc.Message, "Wrong exception is thrown");
            }
        }

        //[TestMethod]
        public void Update_SuccessfullyUpdatesAnExistingCountry()
        {
            // Arrange
            int id = 1;
            var countryToUpdate = new Country
            {
                Id = id,
                Name = "TestCountry1"
            };

            var countries = new List<Country>
            {
                countryToUpdate,
            }.AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);
            //mockContext.Setup(c => c.Entry(countryToUpdate)).Returns(entityEntry.);
            var countryBusiness = new CountryBusiness(mockContext.Object);

            string newCountryName = "NewTestCountry";

            // Act
            countryBusiness.Update(newCountryName, id);

            // Assert
            countryMockDbSet.Verify(x => x.Update(It.IsAny<Country>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Delete_DeletesCountriesSuccessfully_WhenNoCitiesAreRelatedToTheCountry()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country { Name = "TestCountry1", Id = 1},
                new Country { Name = "TestCountry2", Id = 2},
            }.AsQueryable();

            var cities = new List<City>
            {
                new City {Name = "TestCity", Id = 1, CountryId = 1}
            }.AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var cityMockDbSet = new Mock<DbSet<City>>();
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);
            mockContext.Setup(c => c.Cities).Returns(cityMockDbSet.Object);

            var countryBusiness = new CountryBusiness(mockContext.Object);

            // Act
            int idToDelete = 2;
            countryBusiness.Delete(idToDelete);

            // Assert
            countryMockDbSet.Verify(x => x.Remove(It.IsAny<Country>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Delete_ThrowsArgumentException_WhenCountryIsRelatedToCity()
        {// Arrange
            var countries = new List<Country>
            {
                new Country { Name = "TestCountry1", Id = 1},
            }.AsQueryable();

            var cities = new List<City>
            {
                new City {Name = "TestCity", Id = 1, CountryId = 1}
            }.AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var cityMockDbSet = new Mock<DbSet<City>>();
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            cityMockDbSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);
            mockContext.Setup(c => c.Cities).Returns(cityMockDbSet.Object);

            var countryBusiness = new CountryBusiness(mockContext.Object);

            // Act
            try
            {
                int idToDelete = 1;
                countryBusiness.Delete(idToDelete);
                Assert.Fail("No exception was thrown.");
            }
            catch(ArgumentException exc)
            {
                string expectedMessage = "One or more cities are related to this country.";
                Assert.AreEqual(expectedMessage, exc.Message, "Another exception was thrown.");
            }
        }

    }
}
