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
            int id = 1;

            // Act
            Unit unit = unitBusiness.Get(id);

            // Assert
            Assert.IsTrue(unit.Id == id, "Unit could not be extracted succesfully");
            Assert.AreEqual(unit.Name , "Unit", "Unit could not be extracted succesfully");
            Assert.AreEqual(unit.Code, "UN", "Unit could not be extracted succesfully");
        }

        [TestMethod]
        public void GetNumberOfUnitsReturnsCorrectNumber()
        {
            // Arrange
            var unitBusiness = new UnitBusiness();
            bool isDataBaseEmpty = CheckIfDataBaseIsEmpty();          
            int expectedCount;

            // Act
            int actualCount = unitBusiness.GetNumberOfUnits();
            if (isDataBaseEmpty)
            {
                expectedCount = 0;
            }
            else expectedCount = 3;

            // Assert
            Assert.AreEqual(expectedCount, actualCount, "Count of units is not equal to the actual count.");
        }

        [TestMethod]
        public void AddUnitAddsAnEntryToTheDatabase()
        {
            // Arrange
            var unitBusiness = new UnitBusiness();
            int id = 4;
            string unitName = "TestUnit";
            string unitCode = "TCD";

            // Act
            unitBusiness.Add(id, unitName, unitCode);
            Unit unit = unitBusiness.Get(id);

            // Assert
            Assert.IsTrue(unit.Id == id, "Expected Id is different from the actual Id");
            Assert.AreEqual(unit.Name, unitName, "Expected Name is different from the actual Name");
            Assert.AreEqual(unit.Code, unitCode, "Expected Product Code is different from the actual Product Code");

            // Tear Down
            MySqlConnection connection = 
                new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=eazycart");
            connection.Open();
            string deleteCommandString = "DELETE FROM units WHERE Id = 4";
            MySqlCommand deleteUnitCommand = new MySqlCommand(deleteCommandString, connection);
            deleteUnitCommand.ExecuteNonQuery();
            connection.Close();
        }


        public bool CheckIfDataBaseIsEmpty()
        {
            var unitBusiness = new UnitBusiness();
            int actualNumberOfUnits = unitBusiness.GetNumberOfUnits();

            if (actualNumberOfUnits == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
