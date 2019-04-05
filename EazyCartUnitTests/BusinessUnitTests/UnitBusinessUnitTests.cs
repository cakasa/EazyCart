using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;
using Moq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Controllers;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class UnitBusinessUnitTests
    {       
        [TestMethod]
        public void GetUnit_ReturnsAProduct_WhichIsNotNull()
        {
            // Arrange
            var units = new List<Unit>
            {
                new Unit() {Name = "TestUnit1", Id = 1, Code = "TU1"},
                new Unit() {Name = "TestUnit2", Id = 2, Code = "TU2"},
            }.AsQueryable();

            var mockUnitDbSet = new Mock<DbSet<Unit>>();
            mockUnitDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            mockUnitDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            mockUnitDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            mockUnitDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(x => x.Units).Returns(mockUnitDbSet.Object);

            var unitBusiness = new UnitBusiness(mockContext.Object);

            // Act
            int idToGet = 1;
            string expectedUnitName = "TestUnit1";
            var unit = unitBusiness.Get(idToGet);
            Assert.IsNotNull(unit, "Unit could not be extracted");
            Assert.AreEqual(expectedUnitName, unit.Name, "Name is not the same.");
        }

        [TestMethod]
        public void GetNumberOfUnits_ReturnsACorrectNumberOfUnits()
        {
            var units = new List<Unit>
            {
                new Unit() {Name = "TestUnit1", Id = 1, Code = "TU1"},
                new Unit() {Name = "TestUnit2", Id = 2, Code = "TU2"},
            }.AsQueryable();

            var mockUnitDbSet = new Mock<DbSet<Unit>>();
            mockUnitDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            mockUnitDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            mockUnitDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            mockUnitDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(x => x.Units).Returns(mockUnitDbSet.Object);

            var unitBusiness = new UnitBusiness(mockContext.Object);

            // Act
            int expectedCount = 2;
            int actualCount = unitBusiness.GetNumberOfUnits();
            Assert.AreEqual(expectedCount, actualCount, "Count is not the same.");
        }

        [TestMethod]
        public void Add_SuccessfullyAddsAnUnit()
        {
            var mockUnitDbSet = new Mock<DbSet<Unit>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Units).Returns(mockUnitDbSet.Object);

            var unitBusiness = new UnitBusiness(mockContext.Object);
            unitBusiness.Add(1, "TestUnit", "TU");

            mockUnitDbSet.Verify(m => m.Add(It.IsAny<Unit>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}