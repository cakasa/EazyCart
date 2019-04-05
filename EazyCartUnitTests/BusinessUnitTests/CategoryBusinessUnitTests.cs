using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Business.Controllers;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class CategoryBusinessUnitTests
    {
        [TestMethod]
        public void GetAllCategories_ReturnsACorrectListOfCategories()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);

            // Act
            var allCategories = categoryBusiness.GetAll();

            // Assert
            Assert.AreEqual(1, allCategories[0].Id, "First Ids do not match.");
            Assert.AreEqual(2, allCategories[1].Id, "Second Ids do not match.");
        }

        [TestMethod]
        public void GetCategory_ReturnsACorrectCategory()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);

            // Act
            int expectedId = 1;
            var category = categoryBusiness.Get(expectedId);

            // Assert
            Assert.AreEqual(expectedId, category.Id, "Ids do not match.");
        }

        [TestMethod]
        public void GetAllNamesCategories_ReturnsAsACorrectListOfAllCategoryNames()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);

            // Act
            string expectedFirstName = "TestCategory1";
            string expectedSecondName = "TestCategory2";
            var categoryNames = categoryBusiness.GetAllNames();

            // Assert
            Assert.AreEqual(expectedFirstName, categoryNames[0], "First category name does not match.");
            Assert.AreEqual(expectedSecondName, categoryNames[1], "First category name does not match.");
        }

        [TestMethod]
        public void Add_SuccessfullyAddsCategory_WhenIdIsNotDuplicate()
        {
            // Arrange
            var categories = new List<Category>().AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);

            // Act
            categoryBusiness.Add("TestCategory1", 1);

            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Category>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenCategoryWithGivenIdExists()
        {
            // Arrange
            int duplicateId = 1;
            var data = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);
            mockContext.Setup(c => c.SaveChanges()).Throws(new Exception());

            var categoryBusiness = new CategoryBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                categoryBusiness.Add("TestCategory1", duplicateId);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format($"Category with ID {duplicateId} already exists.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void Update_SuccessfullyUpdatesCategory()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var categorymockDbSet = new Mock<DbSet<Category>>();
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(categorymockDbSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);

            // Act
            categoryBusiness.Update("UpdatedCategory", 1);

            // Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Delete_SuccessfullyDeletesCategory_WhenNoProductsAreRelated()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product {Name = "TestProduct1", CategoryId = 1}
            }.AsQueryable();

            var categorymockDbSet = new Mock<DbSet<Category>>();
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var productmockDbSet = new Mock<DbSet<Product>>();
            productmockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productmockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productmockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productmockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(categorymockDbSet.Object);
            mockContext.Setup(c => c.Products).Returns(productmockDbSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);

            // Act
            int idToDelete = 2;
            categoryBusiness.Delete(idToDelete);

            // Assert
            categorymockDbSet.Verify(m => m.Remove(It.IsAny<Category>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Delete_ThrowsArgumentException_WhenProductsAreRelated()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product {Name = "TestProduct1", CategoryId = 1}
            }.AsQueryable();

            var categorymockDbSet = new Mock<DbSet<Category>>();
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categorymockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var productmockDbSet = new Mock<DbSet<Product>>();
            productmockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productmockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productmockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productmockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(categorymockDbSet.Object);
            mockContext.Setup(c => c.Products).Returns(productmockDbSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                int idToDelete = 1;
                categoryBusiness.Delete(idToDelete);
                Assert.Fail("No exception was thrown.");
            }
            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format("One or more products are related to this category.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }
    }
}
