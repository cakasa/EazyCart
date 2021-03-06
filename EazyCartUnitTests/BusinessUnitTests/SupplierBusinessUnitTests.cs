﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;
using Business.Controllers;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class SupplierBusinessUnitBusiness
    {
        [TestMethod]
        public void GetAll_ReturnsACorrectListOfSuppliers_WhenNotEmpty()
        {
            // Arrange
            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1},
                new Supplier { Name = "TestSupplier2", Id = 2 },
                new Supplier { Name = "TestSupplier3", Id = 3 }
            }.AsQueryable();

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act
            var allSuppliers = supplierBusiness.GetAll();

            // Assert
            string expectedFirstSupplierName = "TestSupplier1";
            string expectedSecondSupplierName = "TestSupplier2";
            string expectedThirdSupplierName = "TestSupplier3";
            Assert.AreEqual(expectedFirstSupplierName, allSuppliers[0].Name, "First names do not match.");
            Assert.AreEqual(expectedSecondSupplierName, allSuppliers[1].Name, "Second names do not match.");
            Assert.AreEqual(expectedThirdSupplierName, allSuppliers[2].Name, "Third names do not match");
        }

        [TestMethod]
        public void GetAll_ReturnsAnEmptyList_WhenThereAreNoSuppliers()
        {
            // Arrange
            var suppliers = new List<Supplier>().AsQueryable();

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act
            var allSuppliers = supplierBusiness.GetAll();

            // Assert
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, allSuppliers.Count, "List of all suppliers is not empty");
        }

        [TestMethod]
        public void GetSupplier_ReturnsACorrectSupplier()
        {
            // Arrange
            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1},
                new Supplier { Name = "TestSupplier2", Id = 2 },
                new Supplier { Name = "TestSupplier3", Id = 3 }
            }.AsQueryable();

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act
            int idToGet = 2;
            var supplier = supplierBusiness.Get(idToGet);

            // Assert
            string expectedSupplierName = "TestSupplier2";
            Assert.IsNotNull(supplier, "Supplier could not be extracted.");
            Assert.AreEqual(expectedSupplierName, supplier.Name, "Names do not match.");
        }

        [TestMethod]
        public void GetAllNames_ReturnsACorrectListOfSupplierNames_WhenNotEmpty()
        {
            // Arrange
            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1 },
                new Supplier { Name = "TestSupplier2", Id = 2},
                new Supplier { Name = "TestSupplier3", Id = 3 }
            }.AsQueryable();

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act
            var allSupplierNames = supplierBusiness.GetAllNames();

            // Assert
            string expectedFirstSupplierName = "TestSupplier1";
            string expectedSecondSupplierName = "TestSupplier2";
            string expectedThirdSupplierName = "TestSupplier3";
            Assert.AreEqual(expectedFirstSupplierName, allSupplierNames[0], "First names do not match.");
            Assert.AreEqual(expectedSecondSupplierName, allSupplierNames[1], "Second names do not match.");
            Assert.AreEqual(expectedThirdSupplierName, allSupplierNames[2], "Third names do not match");
        }

        [TestMethod]
        public void GetAllNames_ReturnsAnEmptyList_WhenThereAreNoSuppliers()
        {
            // Arrange
            var suppliers = new List<Supplier>().AsQueryable();

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act
            var allSuppliers = supplierBusiness.GetAllNames();

            // Assert
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, allSuppliers.Count, "List of all suppliers is not empty");
        }

        [TestMethod]
        public void Add_SuccessfullyAddsSupplier_WhenIdIsNotDuplicate()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country {Name = "TestCountry1", Id = 1}
            }.AsQueryable();

            var cities = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1}
            }.AsQueryable();

            var supplierData = new List<Supplier>().AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(supplierData.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(supplierData.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(supplierData.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(supplierData.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act
            supplierBusiness.Add("TestSupplier1", 1, "TestCity1", "TestCountry1");

            // Assert
            mockDbSupplierSet.Verify(m => m.Add(It.IsAny<Supplier>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenCountryIdOrCityDoesNotExist()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country {Name = "TestCountry1", Id = 1}
            }.AsQueryable();

            var cities = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                supplierBusiness.Add("TestSupplier1", 1, "InvalidCity", "InvalidCountry");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format("No such country/city exists");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenSupplierWithIdAlreadyExists()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country {Name = "TestCountry1", Id = 1}
            }.AsQueryable();

            var cities = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);
            mockContext.Setup(c => c.SaveChanges()).Throws(new Exception());

            var supplierBusiness = new SupplierBusiness(mockContext.Object);
            int duplicateId = 1;

            // Act & Assert
            try
            {
                supplierBusiness.Add("TestSupplier1", 1, "TestCity1", "TestCountry1");
                supplierBusiness.Add("TestSupplier2", 1, "TestCity1", "TestCountry1");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format($"Supplier with ID {duplicateId} already exists.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void Update_SuccessfullyUpdatesSupplier_WhenDataIsCorrect()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country {Name = "TestCountry1", Id = 1}
            }.AsQueryable();

            var cities = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var suppliermockDbSet = new Mock<DbSet<Supplier>>();
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            suppliermockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Suppliers).Returns(suppliermockDbSet.Object);
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act
            supplierBusiness.Update("TestSupplier2", 1, "TestCountry1", "TestCity1");

            // Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Update_ThrowsArgumentException_WhenInformationIsNotValid()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country {Name = "TestCountry1", Id = 1}
            }.AsQueryable();

            var cities = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1}
            }.AsQueryable();

            var mockDbCountrySet = new Mock<DbSet<Country>>();
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            mockDbCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var mockDbCitySet = new Mock<DbSet<City>>();
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cities.Provider);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cities.Expression);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cities.ElementType);
            mockDbCitySet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(cities.GetEnumerator());

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Cities).Returns(mockDbCitySet.Object);
            mockContext.Setup(c => c.Countries).Returns(mockDbCountrySet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);
            mockContext.Setup(c => c.SaveChanges()).Throws(new Exception());

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                supplierBusiness.Update("TestSupplier1", 1, "InvalidCountry", "InvalidCity");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                string expectedMessage = string.Format("No such country/city exists.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void Delete_SuccessfullyDeletesSupplier_WhenNoProductsAreRelatedToTheSupplier()
        {
            // Arrange
            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1},
                new Supplier {Name = "TestSupplier2", Id = 2, CityId = 1}
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product {Name = "TestProduct1", SupplierId = 1 }
            }.AsQueryable();

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockDbProductSet = new Mock<DbSet<Product>>();
            mockDbProductSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockDbProductSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockDbProductSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockDbProductSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);
            mockContext.Setup(c => c.Products).Returns(mockDbProductSet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act
            int idToDelete = 2;
            supplierBusiness.Delete(idToDelete);

            // Assert
            mockDbSupplierSet.Verify(m => m.Remove(It.IsAny<Supplier>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Delete_ThrowsArgumentException_WhenProductsAreRelatedToTheSupplier()
        {
            // Arrange
            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "TestSupplier1", Id = 1, CityId = 1},
                new Supplier {Name = "TestSupplier2", Id = 2 }
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product {Name = "TestProduct1", SupplierId = 1 }
            }.AsQueryable();

            var mockDbSupplierSet = new Mock<DbSet<Supplier>>();
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            mockDbSupplierSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var mockDbProductSet = new Mock<DbSet<Product>>();
            mockDbProductSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockDbProductSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockDbProductSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockDbProductSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Suppliers).Returns(mockDbSupplierSet.Object);
            mockContext.Setup(c => c.Products).Returns(mockDbProductSet.Object);

            var supplierBusiness = new SupplierBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                int idToDelete = 1;
                supplierBusiness.Delete(idToDelete);
                Assert.Fail("No exception was thrown.");
            }
            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format("One or more products are related to this supplier.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }
    }
}
