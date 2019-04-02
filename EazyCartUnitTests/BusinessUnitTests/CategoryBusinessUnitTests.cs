﻿using System;
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
    public class CategoryBusinessUnitTests
    {
        // Quary Mocking Tests

        // -----------------------------------------------------------------------------
        //[TestMethod]
        //public void GetAllBlogs_orders_by_name()
        //{
        //    var data = new List<Blog>
        //    {
        //        new Blog { Name = "BBB" },
        //        new Blog { Name = "ZZZ" },
        //        new Blog { Name = "AAA" },
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<Blog>>();
        //    mockSet.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(data.Provider);
        //    mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        //    var mockContext = new Mock<BloggingContext>();
        //    mockContext.Setup(c => c.Blogs).Returns(mockSet.Object);

        //    var service = new BlogService(mockContext.Object);
        //    var blogs = service.GetAllBlogs();

        //    Assert.AreEqual(3, blogs.Count);
        //    Assert.AreEqual("AAA", blogs[0].Name);
        //    Assert.AreEqual("BBB", blogs[1].Name);
        //    Assert.AreEqual("ZZZ", blogs[2].Name);
        //}

        [TestMethod]
        public void GetAllCategories_ReturnsAsAList()
        {
            // Arrange
            var data = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);
            data.ToList().ForEach(c => categoryBusiness.Add(c.Name, c.Id));

            // Act
            var categories = categoryBusiness.GetAll();

            // Assert
            Assert.AreEqual(1, categories[0].Id, "Ids do not match.");
        }

        [TestMethod]
        public void GetOneCategory_ReturnsACategory()
        {
            // Arrange
            var data = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);
            data.ToList().ForEach(c => categoryBusiness.Add(c.Name, c.Id));

            // Act
            int expectedId = 1;
            var category = categoryBusiness.Get(1);

            // Assert
            Assert.AreEqual(expectedId, category.Id, "Ids do not match.");
        }

        [TestMethod]
        public void GetAllNamesCategories_ReturnsAsAList()
        {
            // Arrange
            var data = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var categoryBusiness = new CategoryBusiness(mockContext.Object);
            data.ToList().ForEach(c => categoryBusiness.Add(c.Name, c.Id));

            // Act
            string expectedName = "TestCategory1";
            var category = categoryBusiness.GetAllNames();

            // Assert
            Assert.AreEqual(expectedName, category[0], "Category names do not match.");
        }

        [TestMethod]
        public void Add_SuccessfullyAddsCategory_WhenIdDoesNotExist()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Category>>();

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
        public void Add_ThrowsException_WhenIdAlreadyExists()
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
        public void Delete_ThrowsException_WhenProductsAreRelated()
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
