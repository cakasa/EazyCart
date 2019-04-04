using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;
using Moq;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class ProductReceiptBusinessUnitTests
    {
        // TODO: UPDATE TESTS WITH PROPER VALUES

        [TestMethod]
        public void GetProductReceipt_ReturnsACountry_WhichIsNotNull()
        {
            // Arrange
            var productReceipts = new List<ProductReceipt>
            {
                new ProductReceipt { Id = 1, ReceiptId = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0},
            }.AsQueryable();

            var productReceiptMockSet = new Mock<DbSet<ProductReceipt>>();
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Provider).Returns(productReceipts.Provider);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Expression).Returns(productReceipts.Expression);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.ElementType).Returns(productReceipts.ElementType);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.GetEnumerator()).Returns(productReceipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act
            int idToGet = 1;
            var productReceipt = productReceiptBusiness.Get(idToGet);

            // Assert
            Assert.IsNotNull(productReceipt, "ProductReceipt could not be extracted succesfully");
        }

        [TestMethod]
        public void GetHighestId_ReturnsBiggestId_WhenThereAreProductReceipts()
        {
            // Arrange
            var productReceipts = new List<ProductReceipt>
            {
                new ProductReceipt { Id = 1, ReceiptId = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0},
                new ProductReceipt { Id = 2, ReceiptId = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0},
                new ProductReceipt { Id = 3, ReceiptId = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0},
                new ProductReceipt { Id = 4, ReceiptId = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0},
                new ProductReceipt { Id = 5, ReceiptId = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0}
            }.AsQueryable();

            var productReceiptMockSet = new Mock<DbSet<ProductReceipt>>();
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Provider).Returns(productReceipts.Provider);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Expression).Returns(productReceipts.Expression);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.ElementType).Returns(productReceipts.ElementType);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.GetEnumerator()).Returns(productReceipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act
            int actualHighestId = productReceiptBusiness.GetHighestId();

            // Assert
            int expectedHighestId = 5;
            Assert.AreEqual(expectedHighestId, actualHighestId, "Highest Ids do not match");
        }

        [TestMethod]
        public void GetHighestid_ReturnsZero_WhenThereAreNoProductReceipts()
        {
            // Arrange
            var productReceipts = new List<ProductReceipt>().AsQueryable();

            var productReceiptMockSet = new Mock<DbSet<ProductReceipt>>();
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Provider).Returns(productReceipts.Provider);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Expression).Returns(productReceipts.Expression);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.ElementType).Returns(productReceipts.ElementType);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.GetEnumerator()).Returns(productReceipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act
            int actualHighestId = productReceiptBusiness.GetHighestId();

            // Assert
            int expectedHighestId = 0;
            Assert.AreEqual(expectedHighestId, actualHighestId, "Highest Ids do not match");
        }

        [TestMethod]
        public void GetAllByReceiptId_ReturnsCorrectCountOfItems()
        {
            var productReceipts = new List<ProductReceipt>
            {
                new ProductReceipt { Id = 1, ReceiptId = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0},
                new ProductReceipt { Id = 2, ReceiptId = 1, ProductCode = "000002", Quantity = 1, DiscountPercentage = 0},
                new ProductReceipt { Id = 3, ReceiptId = 2, ProductCode = "000003", Quantity = 1, DiscountPercentage = 0},
                new ProductReceipt { Id = 4, ReceiptId = 2, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0},
                new ProductReceipt { Id = 5, ReceiptId = 2, ProductCode = "000002", Quantity = 1, DiscountPercentage = 0}
            }.AsQueryable();

            var productReceiptMockSet = new Mock<DbSet<ProductReceipt>>();
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Provider).Returns(productReceipts.Provider);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Expression).Returns(productReceipts.Expression);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.ElementType).Returns(productReceipts.ElementType);
            productReceiptMockSet.As<IQueryable<ProductReceipt>>().Setup(m => m.GetEnumerator()).Returns(productReceipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act
            int searchedReceiptId = 1;
            var productsReceiptsWithGivenId = productReceiptBusiness.GetAllByReceiptId(searchedReceiptId);

            // Assert
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, productsReceiptsWithGivenId.Count, "Count of productReceipts does not match.");
        }

        [TestMethod]
        public void Add_SuccessfullyAddsProducts_WhenDataIsCorrect()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() {Code = "000001", CategoryId = 1, SupplierId = 1, Quantity = 1,
                  DeliveryPrice = 1, SellingPrice = 1, Name = "TestProduct", UnitId = 1}
            }.AsQueryable();

            var receiptDateTime = DateTime.Parse("2009/02/26 18:37:58");
            var receipts = new List<Receipt>()
            {
                new Receipt() {Id = 1, GrandTotal = 0, TimeOfPurchase = receiptDateTime},
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>().AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Provider).Returns(productReceipts.Provider);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Expression).Returns(productReceipts.Expression);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.ElementType).Returns(productReceipts.ElementType);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.GetEnumerator()).Returns(productReceipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);
            mockContext.Setup(m => m.Receipts).Returns(receiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act
            productReceiptBusiness.Add(1, "000001", "1", "0");

            // Assert
            productReceiptMockDbSet.Verify(m => m.Add(It.IsAny<ProductReceipt>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenQuantityCannotBeParsed()
        {
            // Arrange
            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Add(1, "000001", "Quantity", "0");
                Assert.Fail("No exception was thrown");
            }
            catch(ArgumentException exc)
            {
                string expectedMessage = "Wrong values for quantity/discount";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenDiscountPercentageCannotBeParsed()
        {
            // Arrange
            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Add(1, "000001", "1", "Discount Percentage");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Wrong values for quantity/discount";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenQuantityIsNotPositive()
        {
            // Arrange
            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Add(1, "000001", "-1", "0");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Quantity must be positive.";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenDiscountPercentageIsNegative()
        {
            // Arrange
            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Add(1, "000001", "1", "-1");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Discount must NOT be negative.";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenRequiredQuantityIsMoreThanAvailableQuantity()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() {Code = "000001", CategoryId = 1, SupplierId = 1, Quantity = 0,
                  DeliveryPrice = 1, SellingPrice = 1, Name = "TestProduct", UnitId = 1}
            }.AsQueryable();   

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();
            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Add(1, "000001", "1", "0");
                Assert.Fail("No exception is thrown");
            }
            catch(ArgumentException exc)
            {
                var expectedMessage = "Insufficient quantity";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenAFloatingPointNumberIsEntered_WhenItShouldBeAWholeNumber()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() {Code = "000001", CategoryId = 1, SupplierId = 1, Quantity = 2,
                  DeliveryPrice = 1, SellingPrice = 1, Name = "TestProduct", UnitId = 1}
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();
            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Add(1, "000001", "1.22", "0");
                Assert.Fail("No exception is thrown");
            }
            catch (ArgumentException exc)
            {
                var expectedMessage = "Quantity must be a whole number";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Add_ThrowsArgumentException_WhenSuchProductReceiptAlreadyExists()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() {Code = "000001", CategoryId = 1, SupplierId = 1, Quantity = 1,
                  DeliveryPrice = 1, SellingPrice = 1, Name = "TestProduct", UnitId = 1}
            }.AsQueryable();

            var receiptDateTime = DateTime.Parse("2009/02/26 18:37:58");
            var receipts = new List<Receipt>()
            {
                new Receipt() {Id = 1, GrandTotal = 0, TimeOfPurchase = receiptDateTime},
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>
            {
                new ProductReceipt {Id = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0 },
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Provider).Returns(productReceipts.Provider);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Expression).Returns(productReceipts.Expression);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.ElementType).Returns(productReceipts.ElementType);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.GetEnumerator()).Returns(productReceipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);
            mockContext.Setup(m => m.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Throws(new ArgumentException());

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Add(1, "000001", "1", "0");
                Assert.Fail("No exception was thrown");
            }
            catch(ArgumentException exc)
            {
                var expectedMessage = "Such productReceipt is already added.";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception is thrown.");
            }
        }

        [TestMethod]
        public void Update_SuccessfullyUpdatesProductReceipt_WhenValuesAreCorrect()
        {
            var products = new List<Product>()
            {
                new Product() {Code = "000001", CategoryId = 1, SupplierId = 1, Quantity = 2,
                  DeliveryPrice = 1, SellingPrice = 1, Name = "TestProduct", UnitId = 1}
            }.AsQueryable();

            var receiptDateTime = DateTime.Parse("2009/02/26 18:37:58");
            var receipts = new List<Receipt>()
            {
                new Receipt() {Id = 1, GrandTotal = 0, TimeOfPurchase = receiptDateTime},
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>
            {
                new ProductReceipt {Id = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0 },
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Provider).Returns(productReceipts.Provider);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Expression).Returns(productReceipts.Expression);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.ElementType).Returns(productReceipts.ElementType);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.GetEnumerator()).Returns(productReceipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);
            mockContext.Setup(m => m.Receipts).Returns(receiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act
            productReceiptBusiness.Update(1, "000001", "1", "0");

            // Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Update_ThrowsArgumentException_WhenQuantityCannotBeParsed()
        {
            // Arrange
            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Update(1, "000001", "Quantity", "0");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Wrong values for quantity/discount";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Update_ThrowsArgumentException_WhenDiscountPercentageCannotBeParsed()
        {
            // Arrange
            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Update(1, "000001", "1", "Discount Percentage");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Wrong values for quantity/discount";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }
        [TestMethod]
        public void Update_ThrowsArgumentException_WhenQuantityIsNotPositive()
        {
            // Arrange
            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Update(1, "000001", "-1", "0");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Quantity must be positive.";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Update_ThrowsArgumentException_WhenDiscountPercentageIsNegative()
        {
            // Arrange
            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Update(1, "000001", "1", "-1");
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException exc)
            {
                string expectedMessage = "Discount must NOT be negative.";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Update_ThrowsArgumentException_WhenRequiredQuantityIsMoreThanAvailableQuantity()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() {Code = "000001", CategoryId = 1, SupplierId = 1, Quantity = 0,
                  DeliveryPrice = 1, SellingPrice = 1, Name = "TestProduct", UnitId = 1}
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();
            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Update(1, "000001", "1", "0");
                Assert.Fail("No exception is thrown");
            }
            catch (ArgumentException exc)
            {
                var expectedMessage = "Insufficient quantity";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Update_ThrowsArgumentException_WhenAFloatingPointNumberIsEntered_WhenItShouldBeAWholeNumber()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() {Code = "000001", CategoryId = 1, SupplierId = 1, Quantity = 2,
                  DeliveryPrice = 1, SellingPrice = 1, Name = "TestProduct", UnitId = 1}
            }.AsQueryable();

            var productMockDbSet = new Mock<DbSet<Product>>();
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productMockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();
            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Products).Returns(productMockDbSet.Object);
            mockContext.Setup(m => m.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                productReceiptBusiness.Update(1, "000001", "1.22", "0");
                Assert.Fail("No exception is thrown");
            }
            catch (ArgumentException exc)
            {
                var expectedMessage = "Quantity must be a whole number";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Delete_DeletesProductReceiptSuccessfully_WhenIdIsCorrect()
        {
            // Arrange
            var productReceipts = new List<ProductReceipt>()
            {
                new ProductReceipt() {Id = 1, ReceiptId = 1, ProductCode = "000001", Quantity = 1, DiscountPercentage = 0},
            }.AsQueryable();

            var productReceiptMockDbSet = new Mock<DbSet<ProductReceipt>>();
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Provider).Returns(productReceipts.Provider);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.Expression).Returns(productReceipts.Expression);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.ElementType).Returns(productReceipts.ElementType);
            productReceiptMockDbSet.As<IQueryable<ProductReceipt>>().Setup(m => m.GetEnumerator()).Returns(productReceipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(x => x.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var productReceiptBusiness = new ProductReceiptBusiness(mockContext.Object);

            // Act
            int idToDelete = 1;
            productReceiptBusiness.Delete(idToDelete);

            // Assert
            productReceiptMockDbSet.Verify(x => x.Remove(It.IsAny<ProductReceipt>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
