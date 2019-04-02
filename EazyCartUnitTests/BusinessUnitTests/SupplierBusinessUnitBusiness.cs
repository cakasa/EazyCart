using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class SupplierBusinessUnitBusiness
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            switch (TestContext.TestName)
            {
                case "GetSupplierByIdSuccessfullyReturnsSupplier":
                case "AddSupplierWithCorrectValuesAddsSupplierSuccessfully":
                case "AddSupplierWithInvalidCountryThrowsArgumentException":
                case "AddSupplierWithInvalidCityThrowsArgumentException":
                case "AddSuppliersWithIdenticalIdThrowsArgumentException":
                case "DeleteSupplierNotRelatedToProductIsSuccessful":
                case "UpdateSupplierWithInvalidCityThrowsArgumentException":
                case "UpdateSupplierWithInvalidCountryThrowsArgumentException":
                case "UpdateSupplierWithCorrectValuesAddsSupplierSuccessfully":               
                    {
                        InitializeOnlyOneCountryAndOneCity();
                        break;
                    }
                case "GetAllSuppliersSuccessfullyReturnsAListOfAllSuppliers":
                case "GetAllSupplierNamesReturnsACorrectListOfSupplierNames":
                    {
                        InitializeMultipleCountriesAndCities();
                        break;
                    }
                case "DeleteSupplierRelatedToProductThrowsArgumentException":
                    {
                        InitializeProduct();
                        break;
                    }
            }
        }


        private void InitializeOnlyOneCountryAndOneCity()
        {
            var cityBusiness = new CityBusiness();
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry", 1);
            cityBusiness.Add("TestCity", 1, "TestCountry");          
        }

        private void InitializeMultipleCountriesAndCities()
        {
            var cityBusiness = new CityBusiness();
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry1", 1);
            countryBusiness.Add("TestCountry2", 2);
            cityBusiness.Add("TestCity1", 1, "TestCountry1");
            cityBusiness.Add("TestCity2", 2, "TestCountry2");
        }

        private void InitializeProduct()
        {
            var categoryBusiness = new CategoryBusiness();
            var unitBusiness = new UnitBusiness();
            var supplierBusiness = new SupplierBusiness();
            categoryBusiness.Add("TestCategory", 1);
            unitBusiness.Add(1, "TestUnit", "TU");
            var cityBusiness = new CityBusiness();
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry", 1);
            cityBusiness.Add("TestCity", 1, "TestCountry");
            supplierBusiness.Add("TestSupplier", 1, "TestCity", "TestCountry");

            var productBusiness = new ProductBusiness();
            productBusiness.Add("000001", "TestCategory", "TestProduct", 1, "TestSupplier", 1, 1, "TestUnit");
        }

        [TestMethod]
        public void SupplierBusinessCanBeCreatedSuccesfully()
        {
            // Arrange 
            SupplierBusiness supplierBusiness;

            // Act
            supplierBusiness = new SupplierBusiness();

            //Assert
            Assert.IsNotNull(supplierBusiness, "Supplier Business object was not created successfully");
        }

        [TestMethod]
        public void GetSupplierByIdSuccessfullyReturnsSupplier()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();
            supplierBusiness.Add("TestSupplier", 1, "TestCity", "TestCountry");

            // Act
            var supplier = supplierBusiness.Get(1);
            var cityBusiness = new CityBusiness();
            var countryBusiness = new CountryBusiness();
            var city = cityBusiness.Get(supplier.CityId);
            var country = countryBusiness.Get(city.Id);

            // Assert
            Assert.AreEqual("TestSupplier", supplier.Name, "Supplier name is not correct.");
            Assert.AreEqual(1, supplier.Id, "Supplier Id is not correct.");
            Assert.AreEqual("TestCity", city.Name, "City Id is not correct.");
            Assert.AreEqual("TestCountry", country.Name, "Country Id is not correct");

            supplierBusiness.Delete(1);
        }

        [TestMethod]
        public void GetAllSuppliersSuccessfullyReturnsAListOfAllSuppliers()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();
            supplierBusiness.Add("TestSupplier1", 1, "TestCity1", "TestCountry1");
            supplierBusiness.Add("TestSupplier2", 2, "TestCity2", "TestCountry2");

            // Act
            var suppliers = supplierBusiness.GetAll();

            // Assert
            Assert.AreEqual(2, suppliers.Count, "GetAll() does not get all suppliers");

            supplierBusiness.Delete(1);
            supplierBusiness.Delete(2);
        }

        [TestMethod]
        public void GetAllSupplierNamesReturnsACorrectListOfSupplierNames()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();
            supplierBusiness.Add("TestSupplier1", 1, "TestCity1", "TestCountry1");
            supplierBusiness.Add("TestSupplier2", 2, "TestCity2", "TestCountry2");

            // Act
            var supplierNames = supplierBusiness.GetAllNames();

            // Assert
            Assert.AreEqual(2, supplierNames.Count, "GetAllNames() does not get all supplier names.");
            Assert.AreEqual("TestSupplier1", supplierNames[0], "GetAllNames() does not get all supplier names.");
            Assert.AreEqual("TestSupplier2", supplierNames[1], "GetAllNames() does not get all supplier names.");

            supplierBusiness.Delete(1);
            supplierBusiness.Delete(2);
        }

        [TestMethod]
        public void AddSupplierWithCorrectValuesAddsSupplierSuccessfully()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();

            string supplierName = "TestSupplier";
            int supplierId = 1;
            string supplierCityName = "TestCity";
            string supplierCountryName = "TestCountry";

            // Act
            supplierBusiness.Add(supplierName, supplierId, supplierCityName, supplierCountryName);
            var addedSupplier = supplierBusiness.Get(supplierId);
            var cityBusiness = new CityBusiness();
            var countryBusiness = new CountryBusiness();
            var supplierCity = cityBusiness.Get(addedSupplier.CityId);
            var supplierCountry = countryBusiness.Get(supplierCity.CountryId);

            // Assert
            Assert.AreEqual(supplierName, addedSupplier.Name);
            Assert.AreEqual(supplierId, addedSupplier.Id);
            Assert.AreEqual(supplierCityName, "TestCity");
            Assert.AreEqual(supplierCountryName, "TestCountry");

            supplierBusiness.Delete(1);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException), 
            "Invalid values can be inserted into the database")]
        public void AddSupplierWithInvalidCountryThrowsArgumentException()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();

            string supplierName = "TestSupplier";
            int supplierId = 1;
            string countryName = "InvalidCountry";
            string cityName = "TestCity";

            // Act & Assert
            supplierBusiness.Add(supplierName, supplierId, cityName, countryName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Invalid values can be inserted into the database")]
        public void AddSupplierWithInvalidCityThrowsArgumentException()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();

            string supplierName = "TestSupplier";
            int supplierId = 1;
            string countryName = "TestCountry";
            string cityName = "InvalidCity";

            // Act & Assert
            supplierBusiness.Add(supplierName, supplierId, cityName, countryName);
        }

        [TestMethod]
        public void AddSuppliersWithIdenticalIdThrowsArgumentException()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();

            string supplierName = "TestSupplier";
            int supplierId = 1;
            string countryName = "TestCountry";
            string cityName = "TestCity";
            supplierBusiness.Add(supplierName, supplierId, cityName, countryName);

            // Act & Assert
            try
            {
                supplierBusiness.Add(supplierName, supplierId, cityName, countryName);

            }
            catch(ArgumentException exc)
            {
                Assert.AreEqual(exc.Message, "Supplier with ID 1 already exists.");
            }

            supplierBusiness.Delete(1);
        }

        [TestMethod]
        public void UpdateSupplierWithCorrectValuesAddsSupplierSuccessfully()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();

            string supplierName = "TestSupplier";
            int supplierId = 1;
            string supplierCityName = "TestCity";
            string supplierCountryName = "TestCountry";
            supplierBusiness.Add(supplierName, supplierId, supplierCityName, supplierCountryName);

            // Act
            supplierBusiness.Update(supplierName, supplierId, supplierCountryName, supplierCityName);
            var addedSupplier = supplierBusiness.Get(supplierId);
            var cityBusiness = new CityBusiness();
            var countryBusiness = new CityBusiness();
            var supplierCity = cityBusiness.Get(addedSupplier.CityId);
            var supplierCountry = countryBusiness.Get(supplierCity.CountryId);

            // Assert
            Assert.AreEqual(supplierName, addedSupplier.Name);
            Assert.AreEqual(supplierId, addedSupplier.Id);
            Assert.AreEqual(supplierCityName, "TestCity");
            Assert.AreEqual(supplierCountryName, "TestCountry");

            supplierBusiness.Delete(1);
        }

        [TestMethod]
        public void UpdateSupplierWithInvalidCountryThrowsArgumentException()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();
            
            string supplierName = "TestSupplier";
            int supplierId = 1;
            string countryName = "TestCountry";
            string cityName = "TestCity";
            supplierBusiness.Add(supplierName, supplierId, cityName, countryName);

            string invalidCountryName = "InvalidCountry";

            // Act & Assert
            try
            {
                supplierBusiness.Update(supplierName, supplierId, invalidCountryName, cityName);
            }
            catch(ArgumentException exc)
            {
                Assert.AreEqual(exc.Message, "No such country/city exists.", "Updating with invalid cities/countries does not throw exception.");
            }
            supplierBusiness.Delete(1);
        }

        [TestMethod]
        public void UpdateSupplierWithInvalidCityThrowsArgumentException()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();

            string supplierName = "TestSupplier";
            int supplierId = 1;
            string countryName = "TestCountry";
            string cityName = "TestCity";
            supplierBusiness.Add(supplierName, supplierId, cityName, countryName);

            string invalidCityName = "InvalidCity";

            // Act & Assert
            try
            {
                supplierBusiness.Update(supplierName, supplierId, countryName, invalidCityName);
            }
            catch (ArgumentException exc)
            {
                Assert.AreEqual(exc.Message, "No such country/city exists.", "Updating with invalid cities/countries does not throw exception.");
            }

            supplierBusiness.Delete(1);
        }

        [TestMethod]
        public void DeleteSupplierNotRelatedToProductIsSuccessful()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();

            string supplierName = "TestSupplier";
            int supplierId = 1;
            string countryName = "TestCountry";
            string cityName = "TestCity";
            supplierBusiness.Add(supplierName, supplierId, cityName, countryName);

            // Act
            supplierBusiness.Delete(1);

            // Assert
            Supplier supplier = supplierBusiness.Get(1);
            Assert.IsNull(supplier, "Delete does not work properly");
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException), 
            "Supplier deletion from city does not throw exception.")]
        public void DeleteSupplierRelatedToProductThrowsArgumentException()
        {
            // Arrange
            var supplierBusiness = new SupplierBusiness();

            // Act
            supplierBusiness.Delete(1);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            switch (TestContext.TestName)
            {
                case "GetSupplierByIdSuccessfullyReturnsSupplier":
                case "AddSupplierWithCorrectValuesAddsSupplierSuccessfully":
                case "AddSupplierWithInvalidCountryThrowsArgumentException":
                case "AddSupplierWithInvalidCityThrowsArgumentException":
                case "AddSuppliersWithIdenticalIdThrowsArgumentException":
                case "UpdateSupplierWithInvalidCityThrowsArgumentException":
                case "UpdateSupplierWithInvalidCountryThrowsArgumentException":
                case "UpdateSupplierWithCorrectValuesAddsSupplierSuccessfully":
                case "DeleteSupplierNotRelatedToProductIsSuccessful":
                    {
                        CleanupOnlyOneCountryAndOneCity();
                        break;
                    }
                case "GetAllSuppliersSuccessfullyReturnsAListOfAllSuppliers":
                case "GetAllSupplierNamesReturnsACorrectListOfSupplierNames":
                    {
                        CleanupMultipleCountriesAndCities();
                        break;
                    }
                case "DeleteSupplierRelatedToProductThrowsArgumentException":
                    {
                        CleanUpProduct();
                        break;
                    }
            }
        }

        private void CleanupOnlyOneCountryAndOneCity()
        {
            var cityBusiness = new CityBusiness();
            var countryBusiness = new CountryBusiness();
            cityBusiness.Delete(1);
            countryBusiness.Delete(1);
        }

        private void CleanupMultipleCountriesAndCities()
        {
            var cityBusiness = new CityBusiness();
            var countryBusiness = new CountryBusiness();
            cityBusiness.Delete(1);
            cityBusiness.Delete(2);
            countryBusiness.Delete(1);
            countryBusiness.Delete(2);
        }

        private void CleanUpProduct()
        {
            var productBusiness = new ProductBusiness();
            productBusiness.Delete("000001");
            var categoryBusiness = new CategoryBusiness();
            categoryBusiness.Delete(1);
            var supplierBusiness = new SupplierBusiness();
            supplierBusiness.Delete(1);
            var cityBusiness = new CityBusiness();
            var countryBusiness = new CountryBusiness();
            cityBusiness.Delete(1);
            countryBusiness.Delete(1);
          
            // Remove the created unit
            MySqlConnection connection =
               new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=eazycart");
            connection.Open();
            string deleteCommandString = "DELETE FROM units WHERE Id = 1";
            MySqlCommand deleteUnitCommand = new MySqlCommand(deleteCommandString, connection);
            deleteUnitCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
