using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class CategoryBusinessUnitTests
    {
        [TestMethod]
        public void CategoryBusinessObjectCanBeCreatedSuccessfully()
        {
            // Arrange
            CategoryBusiness categoryBusiness;

            // Act
            categoryBusiness = new CategoryBusiness();

            // Assert
            Assert.IsNotNull(categoryBusiness, "Cannot instantiate an object of type CategoryBusiness");
        }

        [TestMethod]
        public void GetCategoryByIdSuccessfullyReturnsCategory()
        {
            // Arrange
            var categoryBusiness = new CategoryBusiness();
            string categoryName = "TestCategory";
            int categoryId = 1;
            categoryBusiness.Add(categoryName, categoryId);

            // Act
            Category category = categoryBusiness.Get(1);

            // Assert
            Assert.AreEqual(categoryId, category.Id, "Id-s do not match.");
            Assert.AreEqual(categoryName, category.Name, "Categories do not match");

            categoryBusiness.Delete(1);
        }

        [TestMethod]
        public void GetAllReturnsAnEmptyListWhenThereAreNoItems()
        {
            // Arrange 
            var categoryBusiness = new CategoryBusiness();

            // Act
            List<Category> allCategories = categoryBusiness.GetAll();

            // Arrange
            Assert.AreEqual(0, allCategories.Count, "Incorrect list of categories was returned");
        }

        [TestMethod]
        public void GetAllReturnsCorrectItems()
        {
            // Arrange
            var categoryBusiness = new CategoryBusiness();
            categoryBusiness.Add("TestCategory1", 1);
            categoryBusiness.Add("TestCategory2", 2);

            // Act
            List<Category> allCategories = categoryBusiness.GetAll();

            //Assert
            Assert.AreEqual(1, allCategories[0].Id, "Elements from list do not match actual values.");
            Assert.AreEqual("TestCategory1", allCategories[0].Name, "Elements from list do not match actual values.");
            Assert.AreEqual(2, allCategories[1].Id, "Elements from list do not match actual values.");
            Assert.AreEqual("TestCategory2", allCategories[1].Name, "Elements from list do not match actual values.");

            categoryBusiness.Delete(1);
            categoryBusiness.Delete(2);
        }

        [TestMethod]
        public void GetAllNamesReturnsCorrectListOfCategoryNames()
        {
            // Arrange
            var categoryBusiness = new CategoryBusiness();
            categoryBusiness.Add("TestCategory1", 1);
            categoryBusiness.Add("TestCategory2", 2);

            // Act
            List<string> allCategories = categoryBusiness.GetAllNames();

            // Assert
            Assert.AreEqual("TestCategory1", allCategories[0], "Names do not match");
            Assert.AreEqual("TestCategory2", allCategories[1], "Names do not match");

            categoryBusiness.Delete(1);
            categoryBusiness.Delete(2);
        }

        [TestMethod]
        public void AddAddsCategorySuccessfullyWithCorrectValues()
        {
            // Arrange
            var categoryBusiness = new CategoryBusiness();
            string categoryName = "TestCategory1";
            int categoryId = 1;

            // Act
            categoryBusiness.Add(categoryName, categoryId);

            // Assert
            Category category = categoryBusiness.Get(1);
            Assert.AreEqual(categoryId, category.Id, "Ids do not match.");
            Assert.AreEqual(categoryName, category.Name, "Names do not match.");

            categoryBusiness.Delete(categoryId);
        }

        [TestMethod]
        public void AddThrowsArgumentExceptionWhenIdIsInvalid()
        {
            // Arrange
            var categoryBusiness = new CategoryBusiness();
            string categoryName = "TestCategory1";
            int categoryId = 1;
            categoryBusiness.Add(categoryName, categoryId);

            // Act & Assert
            try
            {
                categoryBusiness.Add(categoryName, categoryId);
            }
            catch(ArgumentException exc)
            {
                Assert.AreEqual("Category with ID 1 already exists.", exc.Message);
            }

            categoryBusiness.Delete(1);
        }

        [TestMethod]
        public void UpdateUpdatesCategorySuccessfully()
        {
            // Arrange
            var categoryBusiness = new CategoryBusiness();
            string categoryName = "TestCategory1";
            int categoryId = 1;
            categoryBusiness.Add(categoryName, categoryId);

            // Act
            string newCategoryName = "TestCategory1Update";
            categoryBusiness.Update(newCategoryName, categoryId);

            // Assert
            Category updatedCategory = categoryBusiness.Get(categoryId);
            Assert.AreEqual(newCategoryName, updatedCategory.Name, "Update is not working properly");

            categoryBusiness.Delete(1);
        }

        [TestMethod]
        public void DeleteWorksSuccessfullyWhenThereAreNoProducts()
        {
            // Arrange
            var categoryBusiness = new CategoryBusiness();
            string categoryName = "TestCategory1";
            int categoryId = 1;
            categoryBusiness.Add(categoryName, categoryId);

            // Act
            categoryBusiness.Delete(categoryId);

            // Assert
            var category = categoryBusiness.Get(categoryId);
            Assert.IsNull(category, "Category was not deleted successfully.");
        }

        [TestMethod]
        public void DeleteWorksSuccessfullyWhenNoProductsAreRelatedToTheCategory()
        {
            // Arrange
            var unitBusiness = new UnitBusiness();
            unitBusiness.Add(1, "TestUnit", "TU");
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry", 1);
            var cityBusiness = new CityBusiness();
            cityBusiness.Add("TestCity", 1, "TestCountry");
            var supplierBusiness = new SupplierBusiness();
            supplierBusiness.Add("TestSupplier", 1, "TestCity", "TestCountry");
            var categoryBusiness = new CategoryBusiness();
            categoryBusiness.Add("TestCategory1", 1);
            var productBusiness = new ProductBusiness();
            productBusiness.Add("000001", "TestCategory1", "TestProduct", 1, "TestSupplier", 1, 1, "TestUnit");

            categoryBusiness.Add("TestCategory2", 2);

            // Act
            categoryBusiness.Delete(2);

            // Assert
            var category = categoryBusiness.Get(2);
            Assert.IsNull(category, "Category was not deleted successfully.");

            productBusiness.Delete("000001");
            supplierBusiness.Delete(1);
            cityBusiness.Delete(1);
            countryBusiness.Delete(1);
            categoryBusiness.Delete(1);

            // Remove the created unit.
            MySqlConnection connection =
               new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=eazycart");
            connection.Open();
            string deleteCommandString = "DELETE FROM units WHERE Id = 1";
            MySqlCommand deleteUnitCommand = new MySqlCommand(deleteCommandString, connection);
            deleteUnitCommand.ExecuteNonQuery();
            connection.Close();
        }

        [TestMethod]
        public void DeleteThrowsArgumentExceptionWhenProductsAreRelatedToTheCategory()
        {
            // Arrange
            var unitBusiness = new UnitBusiness();
            unitBusiness.Add(1, "TestUnit", "TU");
            var countryBusiness = new CountryBusiness();
            countryBusiness.Add("TestCountry", 1);
            var cityBusiness = new CityBusiness();
            cityBusiness.Add("TestCity", 1, "TestCountry");
            var supplierBusiness = new SupplierBusiness();
            supplierBusiness.Add("TestSupplier", 1, "TestCity", "TestCountry");
            var categoryBusiness = new CategoryBusiness();
            categoryBusiness.Add("TestCategory", 1);
            var productBusiness = new ProductBusiness();
            productBusiness.Add("000001", "TestCategory", "TestProduct", 1, "TestSupplier", 1, 1, "TestUnit");

            // Act & Assert
            try
            {
                categoryBusiness.Delete(1);
            }
            catch(ArgumentException exc)
            {
                Assert.AreEqual("One or more products are related to this category.", exc.Message,
                    "Delete does not throw out an argument exception when the requested for deletion category is related to a product.");
            }

            productBusiness.Delete("000001");
            supplierBusiness.Delete(1);
            cityBusiness.Delete(1);
            countryBusiness.Delete(1);
            categoryBusiness.Delete(1);

            // Remove the created unit.
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
