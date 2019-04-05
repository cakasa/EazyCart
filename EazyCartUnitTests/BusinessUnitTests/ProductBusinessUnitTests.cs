using System;
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
    public class ProductBusinessUnitTests
    {
        [TestMethod]
        public void GetAll_ReturnsACorrectListOfSuppliers_WhenNotEmpty()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1"},
                new Product { Name = "TestProduct2"},
                new Product { Name = "TestProduct3"}
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var allProducts = productBusiness.GetAll();

            // Assert
            string expectedFirstProductName = "TestProduct1";
            string expectedSecondProductName = "TestProduct2";
            string expectedThirdProductName = "TestProduct3";
            Assert.AreEqual(expectedFirstProductName, allProducts[0].Name, "First names do not match.");
            Assert.AreEqual(expectedSecondProductName, allProducts[1].Name, "Second names do not match.");
            Assert.AreEqual(expectedThirdProductName, allProducts[2].Name, "Third names do not match");
        }

        [TestMethod]
        public void GetAll_ReturnsAnEmptyList_WhenThereAreNoProducts()
        {
            // Arrange
            var products = new List<Product>().AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var allProducts = productBusiness.GetAll();

            // Assert
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, allProducts.Count, "List of all products is not empty");
        }

        [TestMethod]
        public void GetProduct_ReturnsACorrectProduct()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000" },
                new Product { Name = "TestProduct2", Code = "000001" },
                new Product { Name = "TestProduct3", Code = "000002" }
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var product = productBusiness.Get("000001");

            // Assert
            string expectedProductName = "TestProduct2";
            Assert.IsNotNull(product, "Supplier could not be extracted.");
            Assert.AreEqual(expectedProductName, product.Name, "Names do not match.");
        }

        [TestMethod]
        public void GetAllNames_ReturnsACorrectListOfProductNames_WhenNotEmpty()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000" },
                new Product { Name = "TestProduct2", Code = "000001" },
                new Product { Name = "TestProduct3", Code = "000002" }
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var allProductNames = productBusiness.GetAllNames();

            // Assert
            string expectedFirstProductName = "TestProduct1";
            string expectedSecondProductName = "TestProduct2";
            string expectedThirdProductName = "TestProduct3";
            Assert.AreEqual(expectedFirstProductName, allProductNames[0], "First names do not match.");
            Assert.AreEqual(expectedSecondProductName, allProductNames[1], "Second names do not match.");
            Assert.AreEqual(expectedThirdProductName, allProductNames[2], "Third names do not match");
        }

        [TestMethod]
        public void GetAllNames_ReturnsAnEmptyList_WhenThereAreNoProducts()
        {
            // Arrange
            var products = new List<Product>().AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var allProductNames = productBusiness.GetAllNames();

            // Assert
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, allProductNames.Count, "List of all suppliers is not empty");
        }

        [TestMethod]
        public void GetCountOfProductsByCategory_ReturnsACorrectDictionary()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var productCountByCategory = productBusiness.GetCountOfProductsByCategory();

            // Assert
            int expectedCountForFirstCategoryType = 2;
            int expectedCountForSecondCategoryType = 1;
            int firstCount = productCountByCategory["TestCategory1"];
            int secondCount = productCountByCategory["TestCategory2"];
            Assert.AreEqual(expectedCountForFirstCategoryType, firstCount);
            Assert.AreEqual(expectedCountForSecondCategoryType, secondCount);
        }

        [TestMethod]
        public void GetCountOfProductsByCountry_ReturnsACorrectDictionary()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country {Name = "TestCountry1", Id = 1},
                new Country {Name = "TestCountry2", Id = 2}
            }.AsQueryable();

            var cities = new List<City>
            {
                new City {Name = "TestCity1", Id = 1, CountryId = 1},
                new City {Name = "TestCity2", Id = 2, CountryId = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1, CityId = 1},
                new Supplier { Name = "TestSupplier2", Id = 2, CityId = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", SupplierId = 1},
                new Product { Name = "TestProduct2", Code = "000001", SupplierId = 1},
                new Product { Name = "TestProduct3", Code = "000002", SupplierId = 2}
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

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);
            mockContext.Setup(c => c.Cities).Returns(cityMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var productCountByCategory = productBusiness.GetCountOfProductsByCountry();

            // Assert
            int expectedCountForProductsFromFirstCountry = 2;
            int expectedCountForProductsFromSecondCountry = 1;
            int firstCount = productCountByCategory["TestCountry1"];
            int secondCount = productCountByCategory["TestCountry2"];
            Assert.AreEqual(expectedCountForProductsFromFirstCountry, firstCount);
            Assert.AreEqual(expectedCountForProductsFromSecondCountry, secondCount);
        }

        [TestMethod]
        public void GetCountOfProductsBySupplier_ReturnsACorrectDictionary()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country {Name = "TestCountry1", Id = 1},
                new Country {Name = "TestCountry2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1, CityId = 1},
                new Supplier { Name = "TestSupplier2", Id = 2, CityId = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", SupplierId = 1},
                new Product { Name = "TestProduct2", Code = "000001", SupplierId = 1},
                new Product { Name = "TestProduct3", Code = "000002", SupplierId = 2}
            }.AsQueryable();

            var countryMockDbSet = new Mock<DbSet<Country>>();
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countries.Provider);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countries.Expression);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countries.ElementType);
            countryMockDbSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(countries.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Countries).Returns(countryMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var productCountBySupplier = productBusiness.GetCountOfProductsBySuppliers();

            // Assert
            int expectedCountForProductsFromFirstCountry = 2;
            int expectedCountForProductsFromSecondCountry = 1;
            int firstCount = productCountBySupplier["TestSupplier1"];
            int secondCount = productCountBySupplier["TestSupplier2"];
            Assert.AreEqual(expectedCountForProductsFromFirstCountry, firstCount);
            Assert.AreEqual(expectedCountForProductsFromSecondCountry, secondCount);
        }

        [TestMethod]
        public void GetAllQuantities_ReturnsACorrectDictionaryOfQuantities()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Quantity = 5, Code = "000000", SupplierId = 1},
                new Product { Name = "TestProduct2", Quantity = 5, Code = "000001", SupplierId = 1},
                new Product { Name = "TestProduct3", Quantity = 5, Code = "000002", SupplierId = 2}
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var productCount = productBusiness.GetAllQuantities();

            // Assert
            decimal expectedCount = 15;
            decimal actualCount = productCount["TestProduct1"] + productCount["TestProduct2"] + productCount["TestProduct3"];
            Assert.AreEqual(expectedCount, actualCount, "Count is not the same.");
        }

        [TestMethod]
        public void GetNetProfitByProduct_SuccessfullyReturnsADictionaryOfNetProfitsAndProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Quantity = 5, Code = "000000", SupplierId = 1, DeliveryPrice = 10, SellingPrice = 20},
                new Product { Name = "TestProduct2", Quantity = 5, Code = "000001", SupplierId = 1, DeliveryPrice = 10, SellingPrice = 20},
                new Product { Name = "TestProduct3", Quantity = 5, Code = "000002", SupplierId = 2, DeliveryPrice = 10, SellingPrice = 20}
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            var productNetProfit = productBusiness.GetNetProfitByProduct();

            // Assert
            decimal expectedProfit = 30;
            decimal actualProfit = productNetProfit["TestProduct1"] + productNetProfit["TestProduct2"] + productNetProfit["TestProduct3"];
            Assert.AreEqual(expectedProfit, actualProfit, "Profit is not the same.");
        }

        [TestMethod]
        public void MakeDelivery_SuccessfullyUpdatesProduct_WhenValuesAreCorrect()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1, Quantity = 4 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            int expectedQuantity = 11;
            productBusiness.MakeDelivery("TestProduct1", 7);
            var updatedProduct = productBusiness.Get("000000");

            // Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedQuantity, updatedProduct.Quantity);
        }

        [TestMethod]
        public void MakeDelivery_ThrowsArgumentException_WhenSuchProductDoesNotExist()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Quantity = 5, Code = "000000", SupplierId = 1, DeliveryPrice = 10, SellingPrice = 20, UnitId = 1},
                new Product { Name = "TestProduct2", Quantity = 5, Code = "000001", SupplierId = 1, DeliveryPrice = 10, SellingPrice = 20, UnitId = 1},
                new Product { Name = "TestProduct3", Quantity = 5, Code = "000002", SupplierId = 2, DeliveryPrice = 10, SellingPrice = 20, UnitId = 1}
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                decimal quantityToDeliver = 10;
                productBusiness.MakeDelivery("InvalidProduct", quantityToDeliver);
                Assert.Fail("No exception was thrown.");
            }

            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format("Such product does not exist!");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void MakeDelivery_ThrowsArgumentException_WhenQuantityIsNotWholeAndUnitIdIsOne()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Quantity = 5, Code = "000000", SupplierId = 1, DeliveryPrice = 10, SellingPrice = 20, UnitId = 1},
                new Product { Name = "TestProduct2", Quantity = 5, Code = "000001", SupplierId = 1, DeliveryPrice = 10, SellingPrice = 20, UnitId = 1},
                new Product { Name = "TestProduct3", Quantity = 5, Code = "000002", SupplierId = 2, DeliveryPrice = 10, SellingPrice = 20, UnitId = 1}
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act & Assert
            decimal deliveryQuantity = 0.1M;
            try
            {
                productBusiness.MakeDelivery("TestProduct1", deliveryQuantity);
                Assert.Fail("No exception was thrown.");
            }

            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format("Quantity must be a whole number.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void MakeDelivery_ThrowsArgumentException_WhenQuantityIsNotPositive()
        {
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Quantity = 5, Code = "000000", SupplierId = 1, DeliveryPrice = 10, SellingPrice = 20},
                new Product { Name = "TestProduct2", Quantity = 5, Code = "000001", SupplierId = 1, DeliveryPrice = 10, SellingPrice = 20},
                new Product { Name = "TestProduct3", Quantity = 5, Code = "000002", SupplierId = 2, DeliveryPrice = 10, SellingPrice = 20}
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act & Assert
            decimal deliveryQuantity = -1;
            try
            {
                productBusiness.MakeDelivery("TestProduct1", deliveryQuantity);
                Assert.Fail("No exception was thrown.");
            }

            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format("Quantity must be positive.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void GetAllByCategoryAndNameOrId_ReturnsACorrectListOfSuppliers_WhenNotEmpty()
        {
            // Assert
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            string categoryName = "TestCategory1";
            string searchPhrase = "Test";
            var allProducts = productBusiness.GetAllByCategoryAndNameOrId(categoryName, searchPhrase);

            // Assert
            string expectedFirstProductName = "TestProduct1";
            string expectedSecondProductName = "TestProduct2";
            Assert.AreEqual(expectedFirstProductName, allProducts[0].Name, "Product Names do not match.");
            Assert.AreEqual(expectedSecondProductName, allProducts[1].Name, "Product Names do not match.");
        }

        [TestMethod]
        public void GetAllByCategory_ReturnsACorrectListOfSuppliers_WhenNotEmpty()
        {
            // Assert
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            string categoryName = "TestCategory2";
            var allProducts = productBusiness.GetAllByCategory(categoryName);

            // Assert
            string expectedProductName = "TestProduct3";
            Assert.AreEqual(expectedProductName, allProducts[0].Name, "Product Names do not match.");
        }

        [TestMethod]
        public void GetAllByNameOrId_ReturnsACorrectListOfSuppliers_WhenNotEmpty()
        {
            // Assert
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            string searchPhrase = "3";
            var allProducts = productBusiness.GetAllByNameOrId(searchPhrase);

            // Assert
            string expectedProductName = "TestProduct3";
            Assert.AreEqual(expectedProductName, allProducts[0].Name, "Product Names do not match.");
        }

        [TestMethod]
        public void Add_SuccessfullyAddsProduct_WhenIdDoesNotExist()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            productBusiness.Add("000003", "TestCategory1", "TestProduct1", 4, "TestSupplier1", 15, 17, "TestUnit1");

            // Assert
            productMockDbSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Add_ThrowsException_WhenQuantityIsAFloatingPointNumber_AndItIsRequiredToBeAWholeNumber()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productBusiness.Add("000000", "TestCategory1", "TestProduct1", 10.5M, "TestSupplier1", 15, 17, "TestUnit1");
                Assert.Fail("No exception is thrown");
            }
            catch(ArgumentException exc)
            {
                string expectedMessage = "Quantity must be a whole number.";
                Assert.AreEqual(expectedMessage, exc.Message, "A different exception was thrown");
            }
        }

        [TestMethod]
        public void Add_ThrowsException_WhenQuantityNotPositive()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productBusiness.Add("000000", "TestCategory1", "TestProduct1", -2, "TestSupplier1", 15, 17, "TestUnit1");
                Assert.Fail("No exception is thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Quantity must be positive.";
                Assert.AreEqual(expectedMessage, exc.Message, "A different exception was thrown");
            }
        }

        [TestMethod]
        public void Add_ThrowsException_WhenCategorydOrSupplierDoesNotExist()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productBusiness.Add("000000", "InvalidCategory", "TestProduct1", 4, "InvalidSupplier", 15, 17, "TestUnit1");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format("Invalid category/supplier information.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void Add_ThrowsException_WhenProductIdIsDuplicate()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);
            mockContext.Setup(c => c.SaveChanges()).Throws(new Exception());

            var productBusiness = new ProductBusiness(mockContext.Object);
            string duplicateCode = "000000";

            // Act & Assert
            try
            {
                productBusiness.Add("000000", "TestCategory1", "TestProduct1", 4, "TestSupplier1", 15, 17, "TestUnit1");
                productBusiness.Add("000000", "TestCategory2", "TestProduct2", 5, "TestSupplier2", 15, 17, "TestUnit1");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                string expectedMessage = string.Format($"Product with code {duplicateCode} already exists.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void Update_SuccessfullyUpdatesProduct()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            productBusiness.Update("000000", "TestCategory1", "UpdatedProduct1", 3, "TestSupplier1", 14, 17, "TestUnit1");

            // Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Update_ThrowsExceptionWhenInformationIsNotValid()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productBusiness.Update("000000", "TestCategory3", "TestProduct1", 5, "TestSupplier3", 13, 16, "TestUnit1");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                string expectedMessage = string.Format("Invalid information about category/supplier.");
                Assert.AreEqual(expectedMessage, ex.Message, "Wrong exception was thrown.");
            }
        }

        [TestMethod]
        public void Update_ThrowsException_WhenQuantityIsAFloatingPointNumber_AndItIsRequiredToBeAWholeNumber()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productBusiness.Update("000000", "TestCategory1", "TestProduct1", 10.5M, "TestSupplier1", 15, 17, "TestUnit1");
                Assert.Fail("No exception is thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Quantity must be a whole number.";
                Assert.AreEqual(expectedMessage, exc.Message, "A different exception was thrown");
            }
        }

        [TestMethod]
        public void Update_ThrowsException_WhenQuantityNotPositive()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category {Name = "TestCategory1", Id = 1},
                new Category {Name = "TestCategory2", Id = 2}
            }.AsQueryable();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "TestSupplier1", Id = 1,},
                new Supplier { Name = "TestSupplier2", Id = 2},
            }.AsQueryable();

            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 },
                new Product { Name = "TestProduct3", Code = "000002", CategoryId = 2 }
            }.AsQueryable();

            var units = new List<Unit>
            {
                new Unit {Name = "TestUnit1", Id = 1}
            }.AsQueryable();

            var categoryMockDbSet = new Mock<DbSet<Category>>();
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            categoryMockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var supplierMockDbSet = new Mock<DbSet<Supplier>>();
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Provider).Returns(suppliers.Provider);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.Expression).Returns(suppliers.Expression);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.ElementType).Returns(suppliers.ElementType);
            supplierMockDbSet.As<IQueryable<Supplier>>().Setup(m => m.GetEnumerator()).Returns(suppliers.GetEnumerator());

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var unitMockDbSet = new Mock<DbSet<Unit>>();
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(units.Provider);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(units.Expression);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(units.ElementType);
            unitMockDbSet.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(units.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.Categories).Returns(categoryMockDbSet.Object);
            mockContext.Setup(c => c.Suppliers).Returns(supplierMockDbSet.Object);
            mockContext.Setup(c => c.Units).Returns(unitMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productBusiness.Update("000000", "TestCategory1", "TestProduct1", -2, "TestSupplier1", 15, 17, "TestUnit1");
                Assert.Fail("No exception is thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Quantity must be positive.";
                Assert.AreEqual(expectedMessage, exc.Message, "A different exception was thrown");
            }
        }

        [TestMethod]
        public void Delete_SuccessfullyDeletesProduct()
        {
            // Assert
            var products = new List<Product>
            {
                new Product { Name = "TestProduct1", Code = "000000", CategoryId = 1 },
                new Product { Name = "TestProduct2", Code = "000001", CategoryId = 1 }
            }.AsQueryable();

            var productsReceipts = new List<ProductReceipt>()
            {
                new ProductReceipt { Id = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0 },
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());
            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();

            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Provider).Returns(productsReceipts.Provider);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Expression).Returns(productsReceipts.Expression);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.ElementType).Returns(productsReceipts.ElementType);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.GetEnumerator()).Returns(productsReceipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productBusiness = new ProductBusiness(mockContext.Object);

            // Act
            string codeToDelete = "000001";
            productBusiness.Delete(codeToDelete);

            // Assert
            productMockDbSet.Verify(m => m.Remove(It.IsAny<Product>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
