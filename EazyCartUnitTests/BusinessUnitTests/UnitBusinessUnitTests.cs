using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class UnitBusinessUnitTests
    {
        [TestMethod]
        public void UnitBusinessIsCreatedSuccessfully()
        {
            // Arrange
            UnitBusiness unitBusiness;

            // Act
            unitBusiness = new UnitBusiness();

            // Assert
            Assert.IsNotNull(unitBusiness, "UnitBusiness object did not create successfully");
        }

        [TestMethod]
        public void GetMethodReturnsUnitById()
        {
            // Arrange
            var unitBusiness = new UnitBusiness();
            unitBusiness.Add(1, "TestUnit1", "TU1");
            int id = 1;

            // Act
            Unit unit = unitBusiness.Get(id);

            // Assert
            Assert.IsTrue(unit.Id == id, "Unit could not be extracted succesfully");
            Assert.AreEqual(unit.Name , "TestUnit1", "Unit could not be extracted succesfully");
            Assert.AreEqual(unit.Code, "TU1", "Unit could not be extracted succesfully");

            RevertChanges();
        }

        [TestMethod]
        public void GetNumberOfUnitsReturnsZeroWhenNoUnitsHaveBeenInserted()
        {
            // Arrange
            var unitBusiness = new UnitBusiness();     
            int expectedCount = 0;

            // Act
            var actualCount = unitBusiness.GetNumberOfUnits();

            // Assert
            Assert.AreEqual(expectedCount, actualCount, "Count of units is not equal to the actual count.");
        }

        [TestMethod]
        public void GetNumberOfUnitsReturnsOneWhenOnlyOneUnitHasBeenInserted()
        {
            // Arrange
            var unitBusiness = new UnitBusiness();
            unitBusiness.Add(1, "TestUnit1", "TU1");
            int expectedCount = 1;

            // Act
            var actualCount = unitBusiness.GetNumberOfUnits();

            // Assert
            Assert.AreEqual(expectedCount, actualCount, "Count of units is not equal to the actual count.");

            RevertChanges();
        }

        [TestMethod]
        public void AddUnitAddsAnEntryToTheDatabase()
        {
            // Arrange
            var unitBusiness = new UnitBusiness();
            int id = 1;
            string unitName = "TestUnit1";
            string unitCode = "TU1";

            // Act
            unitBusiness.Add(id, unitName, unitCode);
            Unit unit = unitBusiness.Get(id);

            // Assert
            Assert.IsTrue(unit.Id == id, "Expected Id is different from the actual Id");
            Assert.AreEqual(unit.Name, unitName, "Expected Name is different from the actual Name");
            Assert.AreEqual(unit.Code, unitCode, "Expected Product Code is different from the actual Product Code");

            RevertChanges();
        }

        public void RevertChanges()
        {
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
