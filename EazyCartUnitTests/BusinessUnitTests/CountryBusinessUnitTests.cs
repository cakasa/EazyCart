using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class CountryBusinessUnitTests
    {
        // Get(int) : Country                 | COVERED
        // GetAll() : List<Country>           | COVERED
        // GetAllNames() : List<string>       | COVERED
        // GetNameBySupplier(string) : string | COVERED
        // Add(string, int)                   | COVERED
        // Update(string, int)                | COVERED
        // Delete(int)                        | NOT COVERED

        [TestMethod] 
        public void CountryBusinessObjectCanBeCreatedSuccessfully()
        {
            // Arrange
            CountryBusiness countryBusiness;

            // Act
            countryBusiness = new CountryBusiness();

            // Assert
            Assert.IsNotNull(countryBusiness, "Country object could not be instantiated");
        }

        [TestMethod]
        public void GetReturnsACountryWithCorrectValues()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();
            string countryName = "TestCountry";
            int countryId = 1;
            countryBusiness.Add(countryName, countryId);

            // Act
            var country = countryBusiness.Get(countryId);

            // Assert
            Assert.AreEqual(countryId, country.Id, "Ids do not match");
            Assert.AreEqual(countryName, country.Name, "Names do not match.");

            countryBusiness.Delete(countryId);
        }

        [TestMethod]
        public void GetAllReturnsACorrectListOfCountries()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry1", 1);
            countryBusiness.Add("TestCountry2", 2);

            // Act
            var allCountries = countryBusiness.GetAll();

            // Assert
            Assert.AreEqual(1, allCountries[0].Id, "GetAll() passes wrong List of countries");
            Assert.AreEqual("TestCountry1", allCountries[0].Name, "GetAll() passes wrong List of countries");
            Assert.AreEqual(2, allCountries[1].Id, "GetAll() passes wrong List of countries");
            Assert.AreEqual("TestCountry2", allCountries[1].Name, "GetAll() passes wrong List of countries");

            countryBusiness.Delete(1);
            countryBusiness.Delete(2);
        }

        [TestMethod]
        public void GetAllReturnsAnEmptyListIfNoCountriesExist()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();

            // Act
            var allCountries = countryBusiness.GetAll();

            // Assert
            Assert.AreEqual(0, allCountries.Count, "GetAll() does returns a wrong List");
        }

        [TestMethod]
        public void GetAllNamesReturnsACorrectListOfCountryNames()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry1", 1);
            countryBusiness.Add("TestCountry2", 2);

            // Act
            var allCountryNames = countryBusiness.GetAllNames();

            // Assert
            Assert.AreEqual("TestCountry1", allCountryNames[0], "The List of names is not correct");
            Assert.AreEqual("TestCountry2", allCountryNames[1], "The List of names is not correct");

            countryBusiness.Delete(1);
            countryBusiness.Delete(2);
        }

        [TestMethod]
        public void GetNameBySupplierReturnsACorrectNameOfCountry()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry1", 1);
            countryBusiness.Add("TestCountry2", 2);
            var cityBusiness = new CityBusiness();
            cityBusiness.Add("TestCity1", 1, "TestCountry1");
            cityBusiness.Add("TestCity2", 2, "TestCountry2");
            var supplierBusiness = new SupplierBusiness();
            string supplierName = "TestSupplier";
            supplierBusiness.Add(supplierName, 1, "TestCity1", "TestCountry1");

            // Act
            string countryName = countryBusiness.GetNameBySupplier(supplierName);

            // Assert
            Assert.AreEqual(countryName, "TestCountry1", "GetNameBySupplier() does not work properly.");

            supplierBusiness.Delete(1);
            cityBusiness.Delete(1);
            cityBusiness.Delete(2);
            countryBusiness.Delete(1);
            countryBusiness.Delete(2);
        }

        [TestMethod]
        public void AddSuccesfullyAddsACountryWhenValuesAreCorrect()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();
            string countryName = "TestCountry";
            int countryId = 1;

            // Act
            countryBusiness.Add(countryName, countryId);

            // Assert
            var country = countryBusiness.Get(countryId);
            Assert.AreEqual(countryId, country.Id, "Country Ids do not match.");
            Assert.AreEqual(countryName, country.Name, "Country names do not match.");

            countryBusiness.Delete(countryId);
        }

        [TestMethod]
        public void AddThrowsArgumentExceptionIfCountryWithGivenIdExists()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();
            string countryName = "TestCountry1";
            int countryId = 1;
            countryBusiness.Add(countryName, countryId);

            // Act & Assert
            string newCountryName = "TestCountry2";
            int newCountryId = 1;
            try
            {
                countryBusiness.Add(newCountryName, newCountryId);
            }
            catch(ArgumentException exc)
            {
                Assert.AreEqual("Country with ID 1 already exists.", exc.Message,
                    "Adding a country with invalid Id does not throw exception.");
            }

            countryBusiness.Delete(countryId);
        }

        [TestMethod]
        public void UpdateSuccesfullyUpdatesACountryWithGivenValues()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();
            string originalCountryName = "TestCountry1";
            int countryId = 1;
            countryBusiness.Add(originalCountryName, 1);

            // Act
            string newCountryName = "TestCountry2";
            countryBusiness.Update(newCountryName, countryId);

            // Assert
            var updatedCountry = countryBusiness.Get(countryId);
            Assert.AreEqual(newCountryName, updatedCountry.Name, "Country was not updated successfully.");

            countryBusiness.Delete(1);
        }

        [TestMethod]
        public void DeleteCountryIsSuccessfulWhenNoCitiesAreRelatedToIt()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry1", 1);
            countryBusiness.Add("TestCountry2", 2);
            var cityBusiness = new CityBusiness();
            cityBusiness.Add("TestCity", 1, "TestCountry1");

            // Act
            countryBusiness.Delete(2);

            // Assert
            var country = countryBusiness.Get(2);
            Assert.IsNull(country, "Country was not deleted successfully.");

            cityBusiness.Delete(1);
            countryBusiness.Delete(1);
        }

        [TestMethod]
        public void DeleteCountryThrowsArgumentExceptionIfACityIsRelatedToIt()
        {
            // Arrange
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry", 1);
            var cityBusiness = new CityBusiness();
            cityBusiness.Add("TestCity", 1, "TestCountry");

            // Act & Assert
            try
            {
                countryBusiness.Delete(1);
            }
            catch(ArgumentException exc)
            {
                Assert.AreEqual("One or more cities are related to this country.", exc.Message,
                    "Delete() fails to show exception if values are incorrect");
            }

            cityBusiness.Delete(1);
            countryBusiness.Delete(1);
        }
    }
}
