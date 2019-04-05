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
    public class ReceiptBusinessUnitTests
    {
        [TestMethod]
        public void Get_ReturnsAReceipt_WhichIsNotNull()
        {
            // Arrange
            var testDateTime = DateTime.Now;
            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1, TimeOfPurchase = testDateTime},
                new Receipt() {Id = 2, GrandTotal = 10, TimeOfPurchase = testDateTime},
                new Receipt() {Id = 3, GrandTotal = 100, TimeOfPurchase = testDateTime}
            }.AsQueryable();

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int idToGet = 2;
            var receipt = receiptBusiness.Get(idToGet);

            // Assert
            Assert.IsNotNull(receipt, "Receipt could not be extracted");
        }

        [TestMethod]
        public void GetAll_SuccessfullyReturnsAListOfReceipts()
        {
            // Arrange
            var testDateTime = DateTime.Now;
            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1, TimeOfPurchase = testDateTime},
                new Receipt() {Id = 2, GrandTotal = 10, TimeOfPurchase = testDateTime},
                new Receipt() {Id = 3, GrandTotal = 100, TimeOfPurchase = testDateTime}
            }.AsQueryable();

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            var allReceipts = receiptBusiness.GetAll();

            // Assert
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, allReceipts.Count, "Counts are different");
        }

        [TestMethod]
        public void GetNextReceiptNumber_RetrievesTheNextNumberSuccessfully()
        {
            // Arrange
            var testDateTime = DateTime.Now;
            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1, TimeOfPurchase = testDateTime},
                new Receipt() {Id = 2, GrandTotal = 10, TimeOfPurchase = testDateTime},
                new Receipt() {Id = 3, GrandTotal = 100, TimeOfPurchase = testDateTime}
            }.AsQueryable();

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int actualNextReceiptNumber = receiptBusiness.GetNextReceiptNumber();

            // Assert
            int expectedNextReceiptNumber = 4;
            Assert.AreEqual(expectedNextReceiptNumber, actualNextReceiptNumber, "Next Receipt Numbers do not match");
        }

        [TestMethod]
        public void Add_CreatesAReceiptSuccessfully()
        {
            // Arrange
            var receiptMockDbSet = new Mock<DbSet<Receipt>>();

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(m => m.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int idToAdd = 1;
            receiptBusiness.Add(idToAdd);

            // Assert
            receiptMockDbSet.Verify(m => m.Add(It.IsAny<Receipt>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Update_SuccessfullyUpdatesReceipt_WhenValuesAreCorrect()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() {Code = "000001",  SupplierId = 1, Quantity = 2,
                  DeliveryPrice = 1, SellingPrice = 1, Name = "TestProduct", UnitId = 1}
            }.AsQueryable();

            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1, TimeOfPurchase = DateTime.Now}
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>()
            {
                new ProductReceipt() {Id = 1, ReceiptId = 1, ProductCode = "000001", DiscountPercentage = 0 }
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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);
            mockContext.Setup(c => c.Products).Returns(productMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int idToUpdate = 1;
            receiptBusiness.Update(idToUpdate);

            // Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Update_ThrowsArgumentException_WhenNoProductReceiptsAreRelatedToTheReceipt()
        {
            // Arrange
            var testDateTime = DateTime.Now;
            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1, TimeOfPurchase = testDateTime},
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>().AsQueryable();

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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act & Assert
            try
            {
                int idToUpdate = 1;
                receiptBusiness.Update(idToUpdate);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException exc)
            {
                var expectedMessage = "No products in this receipt";
                Assert.AreEqual(expectedMessage, exc.Message, "Different exception was thrown");
            }
        }

        [TestMethod]
        public void Delete_SuccessfullyDeletesTheReceipt()
        {
            // Arrange
            var testDateTime = DateTime.Now;
            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1, TimeOfPurchase = testDateTime},
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>().AsQueryable();

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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int idToDelete = 1;
            receiptBusiness.Delete(idToDelete);

            // Assert
            receiptMockDbSet.Verify(x => x.Remove(It.IsAny<Receipt>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DeleteLastReceiptIfEmpty_DeletesReceipt_WhenNoProductReceiptsAreRelatedToIt()
        {
            // Arrange
            var testDateTime = DateTime.Now;
            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1, TimeOfPurchase = testDateTime},
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>().AsQueryable();

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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            receiptBusiness.DeleteLastReceiptIfEmpty();

            // Assert
            receiptMockDbSet.Verify(x => x.Remove(It.IsAny<Receipt>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetYearlyOrders_ReturnsACorrectArrayOfNumberOfOrders()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/01/01 12:00:00");
            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/03/02 12:33:22") },
                new Receipt() {Id = 2, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/01/02 15:11:22") },
                new Receipt() {Id = 3, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/02/03 11:02:11") },
                new Receipt() {Id = 4, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/12/11 13:22:22") },
                new Receipt() {Id = 5, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/11/22 08:10:02") },
                new Receipt() {Id = 6, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/05/11 02:11:22") },
                new Receipt() {Id = 7, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/05/01 22:10:22") },
                new Receipt() { Id = 8, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/03/03 11:22:22") },
                new Receipt() { Id = 9, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/05/22 01:01:01") },
                new Receipt() {Id = 10, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/02/03 01:22:34") },

                // Last Empty Receipt
                new Receipt() {Id = 11, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/12/03 00:00:01") }, 
            }.AsQueryable();

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int[] numberOfYearlyOrders = receiptBusiness.GetYearlyOrders(testDateTime);

            // Assert
            int[] expectedValues = new int[] { 0, 2, 2, 0, 3, 0, 0, 0, 0, 0, 1, 0 };
            bool areValuesCorrect = true;
            for (int i = 0; i < numberOfYearlyOrders.Length; i++)
            {
                if (expectedValues[i] != numberOfYearlyOrders[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetMonthlyOrders_ReturnsACorrectArrayOfNumberOfOrders()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/04/01 12:00:00");
            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 12:33:22") },
                new Receipt() {Id = 2, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/02 15:11:22") },
                new Receipt() {Id = 3, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/03 11:02:11") },
                new Receipt() {Id = 4, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/04 13:22:22") },
                new Receipt() {Id = 5, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/12 08:10:02") },
                new Receipt() {Id = 6, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/15 02:11:22") },
                new Receipt() {Id = 7, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/17 22:10:22") },
                new Receipt() { Id = 8, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/18 11:22:22") },
                new Receipt() { Id = 9, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/21 01:01:01") },
                new Receipt() {Id = 10, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/30 01:22:34") },
                new Receipt() {Id = 11, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/04 06:19:12") },
                new Receipt() {Id = 12, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/05/01 13:16:44") },
                new Receipt() {Id = 13, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/04/01 16:18:11") },

                // Last Empty Receipt
                new Receipt() {Id = 14, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/03 00:00:01") },
            }.AsQueryable();

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int[] numberOfMonthlyOrders = receiptBusiness.GetMonthlyOrders(testDateTime);

            // Assert
            int[] expectedValues = new int[] { 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            bool areValuesCorrect = true;
            for (int i = 0; i < numberOfMonthlyOrders.Length; i++)
            {
                if (expectedValues[i] != numberOfMonthlyOrders[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetDailyOrders_ReturnsACorrectArrayOfNumberOfOrders()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/04/01 00:00:00");
            var receipts = new List<Receipt>
            {
                new Receipt() {Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 04:12:45") },
                new Receipt() {Id = 2, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 15:11:22") },
                new Receipt() {Id = 3, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 11:02:11") },
                new Receipt() {Id = 4, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 13:22:22") },
                new Receipt() {Id = 5, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 08:10:02") },
                new Receipt() {Id = 6, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:11:22") },
                new Receipt() {Id = 7, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 22:10:22") },
                new Receipt() { Id = 8, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 11:22:22") },
                new Receipt() { Id = 9, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 01:01:01") },
                new Receipt() {Id = 10, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 02:22:34") },
                new Receipt() {Id = 11, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 05:19:12") },
                new Receipt() {Id = 12, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 13:16:44") },
                new Receipt() {Id = 13, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 16:18:11") },
                new Receipt() {Id = 14, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 19:20:11") },
                new Receipt() {Id = 15, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 06:01:12") },
                new Receipt() {Id = 16, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 07:12:33") },
                new Receipt() {Id = 17, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 09:45:45") },
                new Receipt() {Id = 18, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 10:22:33") },
                new Receipt() {Id = 19, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/02 00:00:00") },
                new Receipt() {Id = 20, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/04/01 00:20:00") },

                // Last Empty Receipt
                new Receipt() {Id = 21, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:00:01") },
            }.AsQueryable();

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int[] NumberOfDailyOrders = receiptBusiness.GetDailyOrders(testDateTime);

            // Assert
            int[] expectedValues = new int[] { 3, 2, 3, 4, 2, 2, 1, 1 };
            bool areValuesCorrect = true;
            for (int i = 0; i < NumberOfDailyOrders.Length; i++)
            {
                if (expectedValues[i] != NumberOfDailyOrders[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }

            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetYearlyDiscountOrders_ReturnsACorrectArrayOfNumberOfDiscountReceipts()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/01/01 12:00:00");
            var receipts = new List<Receipt>
            {
                // Receipts withing year
                new Receipt() {Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/02/01 00:00:01") },
                new Receipt() {Id = 2, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/02/02 00:00:01") },
                new Receipt() {Id = 3, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/03/01 00:00:01") },
                new Receipt() {Id = 4, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:00:01") },
                new Receipt() {Id = 5, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/07/01 00:00:01") },
                new Receipt() {Id = 6, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/07/02 00:00:01") },
                new Receipt() {Id = 7, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/07/03 00:00:01") },
                new Receipt() { Id = 8, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/10/01 00:00:01") },
                new Receipt() { Id = 9, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/12/01 00:00:01") },
                new Receipt() { Id = 10, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/12/04 00:00:01") },
                
                // Receipts out of year
                new Receipt() {Id = 11, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/01/01 00:00:01") },
                new Receipt() {Id = 12, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2020/02/02 00:00:01") },
                new Receipt() {Id = 13, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2017/06/01 00:00:01") },

            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>
            {
                // Discount ProductReceipts
                new ProductReceipt() {Id = 1, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 2, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 3, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 4, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 5, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 6, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 7, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 8, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 9, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                 new ProductReceipt() {Id = 10, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 10},

                // Non-discount ProductReceipts
               
                new ProductReceipt() {Id = 11, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 3},
                new ProductReceipt() {Id = 12, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 13, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 14, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 15, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 16, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 17, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 18, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 19, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 20, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 10},
            }.AsQueryable();

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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int[] numberOfYearlyOrdersWithDiscount = receiptBusiness.GetYearlyDiscountOrders(testDateTime);

            // Assert
            int[] expectedValues = new int[] { 0, 2, 0, 0, 0, 0, 3, 0, 0, 1, 0, 1 };
            bool areValuesCorrect = true;
            for (int i = 0; i < numberOfYearlyOrdersWithDiscount.Length; i++)
            {
                if (expectedValues[i] != numberOfYearlyOrdersWithDiscount[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetMonthlyDiscountOrders_ReturnsACorrectArrayOfNumberOfDiscountReceipts()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/04/01 12:00:00");
            var receipts = new List<Receipt>
            {
                // Receipts withing month
                new Receipt() {Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:00:01") },
                new Receipt() {Id = 2, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/02 00:00:01") },
                new Receipt() {Id = 3, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/02 00:00:01") },
                new Receipt() {Id = 4, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/03 00:00:01") },
                new Receipt() {Id = 5, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/05 00:00:01") },
                new Receipt() {Id = 6, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/11 00:00:01") },
                new Receipt() {Id = 7, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/15 00:00:01") },
                new Receipt() { Id = 8, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/15 00:00:01") },
                new Receipt() { Id = 9, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/17 00:00:01") },
                new Receipt() { Id = 10, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/18 00:00:01") },
                new Receipt() { Id = 11, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/19 00:00:01") },
                new Receipt() { Id = 12, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/20 00:00:01") },
                new Receipt() { Id = 13, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/22 00:00:01") },
                new Receipt() { Id = 14, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/23 00:00:01") },
                new Receipt() { Id = 15, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/26 00:00:01") },
                new Receipt() { Id = 16, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/27 00:00:01") },
                new Receipt() { Id = 17, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/30 00:00:01") },
                new Receipt() { Id = 18, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/30 00:00:01") },
                new Receipt() { Id = 19, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/30 00:00:01") },

                // Receipts out of month
                new Receipt() {Id = 20, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/04/01 00:00:01") },
                new Receipt() {Id = 21, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/05/01 00:00:01") },
                new Receipt() {Id = 22, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/03/31 00:00:01") },

            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>
            {
                // Discount ProductReceipts
                new ProductReceipt() {Id = 1, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 2, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 3, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 3},
                new ProductReceipt() {Id = 4, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 5, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 6, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 7, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 11},
                new ProductReceipt() {Id = 8, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 15},
                new ProductReceipt() {Id = 9, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 17},
                new ProductReceipt() {Id = 10, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 11, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 19},
                new ProductReceipt() {Id = 12, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 20},
                new ProductReceipt() {Id = 13, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 21},
                new ProductReceipt() {Id = 14, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 22},

                // Non-discount ProductReceipts
               
                new ProductReceipt() {Id = 11, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 3},
                new ProductReceipt() {Id = 12, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 13, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 14, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 15, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 16, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 17, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 18, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 19, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 12},
                new ProductReceipt() {Id = 20, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 13},
                new ProductReceipt() {Id = 11, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 13},
                new ProductReceipt() {Id = 12, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 14},
                new ProductReceipt() {Id = 13, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 16},
                new ProductReceipt() {Id = 14, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 17},
                new ProductReceipt() {Id = 15, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 17},
                new ProductReceipt() {Id = 16, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 17, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 19},
                new ProductReceipt() {Id = 18, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 20},
                new ProductReceipt() {Id = 19, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 22},
                new ProductReceipt() {Id = 20, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 23},
            }.AsQueryable();

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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int[] numberOfMonthlyDiscountOrders = receiptBusiness.GetMonthlyDiscountOrders(testDateTime);

            // Assert
            int[] expectedValues = new int[] { 1, 2, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3 };
            bool areValuesCorrect = true;
            for (int i = 0; i < numberOfMonthlyDiscountOrders.Length; i++)
            {
                if (expectedValues[i] != numberOfMonthlyDiscountOrders[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetDailyDiscountOrders_ReturnsACorrectArrayOfNumberOfDiscountReceipts()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/04/01 00:00:01");
            var receipts = new List<Receipt>
            {
                // Receipts within day
                new Receipt() {Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:00:01") },
                new Receipt() {Id = 2, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 01:00:01") },
                new Receipt() {Id = 3, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 01:30:01") },
                new Receipt() {Id = 4, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 02:15:01") },
                new Receipt() {Id = 5, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 03:45:01") },
                new Receipt() {Id = 6, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 04:00:01") },
                new Receipt() {Id = 7, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 04:15:01") },
                new Receipt() { Id = 8, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 04:30:01") },
                new Receipt() { Id = 9, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 05:15:01") },
                new Receipt() { Id = 10, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 06:12:01") },
                new Receipt() { Id = 11, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 07:30:01") },
                new Receipt() { Id = 12, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 08:50:01") },
                new Receipt() { Id = 13, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 09:42:01") },
                new Receipt() { Id = 14, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 10:45:01") },
                new Receipt() { Id = 15, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 11:00:01") },
                new Receipt() { Id = 16, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 12:00:01") },
                new Receipt() { Id = 17, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 13:00:01") },
                new Receipt() { Id = 18, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 14:00:01") },
                new Receipt() { Id = 19, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 14:30:01") },
                new Receipt() { Id = 20, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 15:30:01") },
                new Receipt() { Id = 21, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 16:30:01") },
                new Receipt() { Id = 22, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 16:30:01") },
                new Receipt() { Id = 23, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 17:30:01") },
                new Receipt() { Id = 24, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 18:30:01") },
                new Receipt() { Id = 25, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 19:30:01") },
                new Receipt() { Id = 26, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 20:30:01") },
                new Receipt() { Id = 27, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 21:30:01") },
                new Receipt() { Id = 28, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 22:30:01") },
                new Receipt() { Id = 29, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 23:10:01") },
                new Receipt() { Id = 30, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 23:59:59") },

                // Receipts out of day
                new Receipt() {Id = 31, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/04/01 00:00:01") },
                new Receipt() {Id = 32, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/02 00:00:01") },
                new Receipt() {Id = 33, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/03/01 00:00:01") },
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>
            {
                // Discount ProductReceipts
                new ProductReceipt() {Id = 1, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 2, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 3, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 3},
                new ProductReceipt() {Id = 4, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 5, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 6, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 7, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 8, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 9, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 10, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 11},
                new ProductReceipt() {Id = 11, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 12},
                new ProductReceipt() {Id = 12, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 13},
                new ProductReceipt() {Id = 13, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 14},
                new ProductReceipt() {Id = 14, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 15},
                new ProductReceipt() {Id = 15, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 16},
                new ProductReceipt() {Id = 16, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 17, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 20},
                new ProductReceipt() {Id = 18, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 21},
                new ProductReceipt() {Id = 19, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 22},
                new ProductReceipt() {Id = 20, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 23},
                new ProductReceipt() {Id = 21, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 25},
                new ProductReceipt() {Id = 22, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 26},
                new ProductReceipt() {Id = 23, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 27},
                new ProductReceipt() {Id = 24, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 30},

                // Non-discount ProductReceipts
               
                new ProductReceipt() {Id = 25, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 26, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 27, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 28, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 29, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 30, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 31, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 32, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 33, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 11},
                new ProductReceipt() {Id = 34, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 13},
                new ProductReceipt() {Id = 35, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 15},
                new ProductReceipt() {Id = 36, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 17},
                new ProductReceipt() {Id = 37, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 38, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 39, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 20},
                new ProductReceipt() {Id = 40, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 23},
                new ProductReceipt() {Id = 41, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 23},
                new ProductReceipt() {Id = 42, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 27},
                new ProductReceipt() {Id = 43, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 29},
                new ProductReceipt() {Id = 44, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 30},
                new ProductReceipt() {Id = 45, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 31},
                new ProductReceipt() {Id = 46, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 33},
            }.AsQueryable();

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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            int[] numberOfDailyOrdersWithDiscount = receiptBusiness.GetDailyDiscountOrders(testDateTime);

            // Assert
            int[] expectedValues = new int[] { 4, 4, 3, 3, 2, 4, 2, 2 };
            bool areValuesCorrect = true;
            for (int i = 0; i < numberOfDailyOrdersWithDiscount.Length; i++)
            {
                if (expectedValues[i] != numberOfDailyOrdersWithDiscount[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetYearlyAverageAmountOfDifferentProducts_ReturnsACorrectArrayOfValues()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/01/01 12:00:00");
            var receipts = new List<Receipt>
            {
                // Receipts withing year
                new Receipt() {Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/02/01 00:00:01") },
                new Receipt() {Id = 2, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/02/02 00:00:01") },
                new Receipt() {Id = 3, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/03/01 00:00:01") },
                new Receipt() {Id = 4, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:00:01") },
                new Receipt() {Id = 5, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/07/01 00:00:01") },
                new Receipt() {Id = 6, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/07/02 00:00:01") },
                new Receipt() {Id = 7, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/07/03 00:00:01") },
                new Receipt() { Id = 8, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/10/01 00:00:01") },
                new Receipt() { Id = 9, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/12/01 00:00:01") },
                new Receipt() { Id = 10, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/12/04 00:00:01") },
                new Receipt() { Id = 11, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/12/10 00:00:01") },
                new Receipt() { Id = 12, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/12/15 00:00:01") },
                
                // Receipts out of year
                new Receipt() {Id = 13, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/01/01 00:00:01") },
                new Receipt() {Id = 14, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2020/02/02 00:00:01") },
                new Receipt() {Id = 15, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2017/06/01 00:00:01") },

                // Last Empty Receipt
                new Receipt() {Id = 16, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/12/16 00:00:01") },
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>
            {
                new ProductReceipt() {Id = 1, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 2, ProductCode = "000002", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 3, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 4, ProductCode = "000002", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 5, ProductCode = "000003", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 6, ProductCode = "000004", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 7, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 3},
                new ProductReceipt() {Id = 8, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 9, ProductCode = "000002", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 10, ProductCode = "000003", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 11, ProductCode = "000004", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 12, ProductCode = "000005", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 13, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 14, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 15, ProductCode = "000002", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 16, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 17, ProductCode = "000002", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 18, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 19, ProductCode = "000002", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 20, ProductCode = "000003", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 21, ProductCode = "000004", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 22, ProductCode = "000005", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 23, ProductCode = "000006", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 24, ProductCode = "000007", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 25, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 26, ProductCode = "000002", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 27, ProductCode = "000003", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 28, ProductCode = "000004", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 11},
                new ProductReceipt() {Id = 29, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 12},
                new ProductReceipt() {Id = 30, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 12},
            }.AsQueryable();

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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            decimal[] numberOfYearlyAverageNumberOfDifferentProducts =
                receiptBusiness.GetYearlyAverageAmountOfDifferentProducts(testDateTime);

            // Assert
            decimal[] expectedValues = new decimal[] { 0, 3, 1, 5, 0, 0, 5M / 3M, 0, 0, 2, 0, 2.75M };
            bool areValuesCorrect = true;
            for (int i = 0; i < numberOfYearlyAverageNumberOfDifferentProducts.Length; i++)
            {
                if (expectedValues[i] != numberOfYearlyAverageNumberOfDifferentProducts[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetMonthlyAverageAmountOfDifferentProducts_ReturnsACorrectArrayOfValues()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/04/01 12:00:00");
            var receipts = new List<Receipt>
            {
                // Receipts withing month
                new Receipt() {Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:00:01") },
                new Receipt() {Id = 2, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:00:01") },
                new Receipt() {Id = 3, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:00:01") },
                new Receipt() {Id = 4, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/02 00:00:01") },
                new Receipt() {Id = 5, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/03 00:00:01") },
                new Receipt() {Id = 6, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/03 00:00:01") },
                new Receipt() {Id = 7, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/03 00:00:01") },
                new Receipt() { Id = 8, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/03 00:00:01") },
                new Receipt() { Id = 9, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/04 00:00:01") },
                new Receipt() { Id = 10, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/05 00:00:01") },
                new Receipt() { Id = 11, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/06 00:00:01") },
                new Receipt() { Id = 12, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/07 00:00:01") },
                new Receipt() { Id = 13, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/07 00:00:01") },
                new Receipt() { Id = 14, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/11 00:00:01") },
                new Receipt() { Id = 15, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/13 00:00:01") },
                new Receipt() { Id = 16, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/15 00:00:01") },
                new Receipt() { Id = 17, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/15 00:00:01") },
                new Receipt() { Id = 18, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/15 00:00:01") },
                new Receipt() { Id = 19, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/17 00:00:01") },
                new Receipt() { Id = 20, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/20 00:00:01") },
                new Receipt() { Id = 21, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/20 00:00:01") },
                new Receipt() { Id = 22, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/21 00:00:01") },
                new Receipt() { Id = 23, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/22 00:00:01") },
                new Receipt() { Id = 24, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/22 00:00:01") },
                new Receipt() { Id = 25, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/23 00:00:01") },
                new Receipt() { Id = 26, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/26 00:00:01") },
                new Receipt() { Id = 27, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/26 00:00:01") },
                new Receipt() { Id = 28, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/28 00:00:01") },
                new Receipt() { Id = 29, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/30 00:00:01") },
                new Receipt() { Id = 30, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/30 00:00:01") },

                // Receipts out of month
                new Receipt() {Id = 31, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/04/01 00:00:01") },
                new Receipt() {Id = 32, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/05/01 00:00:01") },
                new Receipt() {Id = 33, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/03/31 00:00:01") },

                // Last Empty Receipt
                new Receipt() { Id= 34, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/30 00:00:01") },
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>
            {
                new ProductReceipt() {Id = 1, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 2, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 3, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 4, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 5, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 3},
                new ProductReceipt() {Id = 6, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 3},
                new ProductReceipt() {Id = 7, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 3},
                new ProductReceipt() {Id = 8, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 9, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 10, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 11, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 12, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 13, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 14, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 15, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 16, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 17, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 18, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 19, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 20, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 21, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 22, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 23, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 11},
                new ProductReceipt() {Id = 24, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 11},
                new ProductReceipt() {Id = 25, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 11},
                new ProductReceipt() {Id = 26, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 11},
                new ProductReceipt() {Id = 27, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 12},
                new ProductReceipt() {Id = 28, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 13},
                new ProductReceipt() {Id = 29, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 13},
                new ProductReceipt() {Id = 30, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 14},
                new ProductReceipt() {Id = 31, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 14},
                new ProductReceipt() {Id = 32, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 15},
                new ProductReceipt() {Id = 33, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 16},
                new ProductReceipt() {Id = 34, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 17},
                new ProductReceipt() {Id = 35, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 17},
                new ProductReceipt() {Id = 36, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 17},
                new ProductReceipt() {Id = 37, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 17},
                new ProductReceipt() {Id = 38, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 39, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 40, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 41, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 19},
                new ProductReceipt() {Id = 42, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 19},
                new ProductReceipt() {Id = 43, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 20},
                new ProductReceipt() {Id = 44, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 20},
                new ProductReceipt() {Id = 45, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 20},
                new ProductReceipt() {Id = 46, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 21},
                new ProductReceipt() {Id = 47, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 22},
                new ProductReceipt() {Id = 48, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 22},
                new ProductReceipt() {Id = 49, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 23},
                new ProductReceipt() {Id = 50, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 24},
                new ProductReceipt() {Id = 51, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 24},
                new ProductReceipt() {Id = 52, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 24},
                new ProductReceipt() {Id = 53, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 25},
                new ProductReceipt() {Id = 54, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 26},
                new ProductReceipt() {Id = 55, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 27},
                new ProductReceipt() {Id = 56, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 28},
                new ProductReceipt() {Id = 57, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 28},
                new ProductReceipt() {Id = 58, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 29},
                new ProductReceipt() {Id = 59, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 30},
                new ProductReceipt() {Id = 60, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 30},
                new ProductReceipt() {Id = 61, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 30},
                new ProductReceipt() {Id = 62, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 31},
                new ProductReceipt() {Id = 63, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 32},
                new ProductReceipt() {Id = 64, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 32},
                new ProductReceipt() {Id = 65, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 32},
            }.AsQueryable();

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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            decimal[] numberOfMonthlyAverageNumberOfDifferentProducts = receiptBusiness.GetMonthlyAverageAmountOfDifferentProducts(testDateTime);

            // Assert
            decimal[] expectedValues = new decimal[] { 7M / 3M, 4, 1.75M, 2, 2, 4, 1.5M, 0, 0, 0, 2, 0, 1, 0, 8M / 3M, 0, 2, 0, 0, 2, 2, 2, 1, 0, 0, 1, 0, 2, 0, 2 };
            bool areValuesCorrect = true;
            for (int i = 0; i < numberOfMonthlyAverageNumberOfDifferentProducts.Length; i++)
            {
                if (expectedValues[i] != numberOfMonthlyAverageNumberOfDifferentProducts[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetDailyAverageAmountOfDifferentProducts_ReturnsACorrectArrayOfValues()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/04/01 00:00:01");
            var receipts = new List<Receipt>
            {
                // Receipts within day
                new Receipt() {Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 00:00:01") },
                new Receipt() {Id = 2, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 01:00:01") },
                new Receipt() {Id = 3, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 01:30:01") },
                new Receipt() {Id = 4, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 02:15:01") },
                new Receipt() {Id = 5, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 03:45:01") },
                new Receipt() {Id = 6, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 04:00:01") },
                new Receipt() {Id = 7, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 06:12:01") },
                new Receipt() {Id = 8, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 07:30:01") },
                new Receipt() { Id = 9, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 08:50:01") },
                new Receipt() { Id = 10, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 09:42:01") },
                new Receipt() { Id = 11, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 10:45:01") },
                new Receipt() { Id = 12, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 11:00:01") },
                new Receipt() { Id = 13, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 12:00:01") },
                new Receipt() { Id = 14, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 13:00:01") },
                new Receipt() { Id = 15, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 14:00:01") },
                new Receipt() { Id = 16, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 14:30:01") },
                new Receipt() { Id = 17, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 15:30:01") },
                new Receipt() { Id = 18, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 16:30:01") },
                new Receipt() { Id = 19, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 16:30:01") },
                new Receipt() { Id = 20, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 17:30:01") },
                new Receipt() { Id = 21, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 18:30:01") },
                new Receipt() { Id = 22, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 19:30:01") },
                new Receipt() { Id = 23, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 20:30:01") },
                new Receipt() { Id = 24, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/01 21:30:01") },

                // Receipts out of day
                new Receipt() {Id = 25, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2018/04/01 00:00:01") },
                new Receipt() {Id = 26, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/04/02 00:00:01") },
                new Receipt() {Id = 27, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/03/01 00:00:01") },
            }.AsQueryable();

            var productReceipts = new List<ProductReceipt>
            {
                new ProductReceipt() {Id = 1, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 2, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 3, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 1},
                new ProductReceipt() {Id = 4, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 5, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 6, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 2},
                new ProductReceipt() {Id = 7, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 3},
                new ProductReceipt() {Id = 8, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 9, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 4},
                new ProductReceipt() {Id = 10, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 11, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 12, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 13, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 14, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 5},
                new ProductReceipt() {Id = 15, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 6},
                new ProductReceipt() {Id = 16, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 17, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 7},
                new ProductReceipt() {Id = 18, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 19, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 20, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 8},
                new ProductReceipt() {Id = 21, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 22, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 23, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 9},
                new ProductReceipt() {Id = 24, ProductCode = "000001", DiscountPercentage = 1, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 25, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 26, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 27, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 28, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 29, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 10},
                new ProductReceipt() {Id = 30, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 11},
                new ProductReceipt() {Id = 31, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 12},
                new ProductReceipt() {Id = 32, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 12},
                new ProductReceipt() {Id = 33, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 13},
                new ProductReceipt() {Id = 34, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 13},
                new ProductReceipt() {Id = 35, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 14},
                new ProductReceipt() {Id = 36, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 14},
                new ProductReceipt() {Id = 37, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 14},
                new ProductReceipt() {Id = 38, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 14},
                new ProductReceipt() {Id = 39, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 15},
                new ProductReceipt() {Id = 40, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 15},
                new ProductReceipt() {Id = 41, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 16},
                new ProductReceipt() {Id = 42, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 17},
                new ProductReceipt() {Id = 43, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 44, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 45, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 18},
                new ProductReceipt() {Id = 46, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 19},
                new ProductReceipt() {Id = 47, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 19},
                new ProductReceipt() {Id = 48, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 20},
                new ProductReceipt() {Id = 49, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 21},
                new ProductReceipt() {Id = 50, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 22},
                new ProductReceipt() {Id = 51, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 22},
                new ProductReceipt() {Id = 52, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 23},
                new ProductReceipt() {Id = 53, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 23},
                new ProductReceipt() {Id = 54, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 24},
                new ProductReceipt() {Id = 55, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 24},
                new ProductReceipt() {Id = 56, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 24},
                new ProductReceipt() {Id = 57, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 25},
                new ProductReceipt() {Id = 58, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 25},
                new ProductReceipt() {Id = 59, ProductCode = "000001", DiscountPercentage = 0, Quantity = 1,
                    ReceiptId = 26},
            }.AsQueryable();

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
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);
            mockContext.Setup(c => c.ProductsReceipts).Returns(productReceiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            decimal[] numberOfDailyAverageNumberOfDifferentProducts = receiptBusiness.GetDailyAverageAmountOfDifferentProducts(testDateTime);

            // Assert
            decimal[] expectedValues = new decimal[] { 2.25M, 3, 8M / 3M, 3, 2.25M, 1.75M, 5M / 3M, 0 };
            bool areValuesCorrect = true;
            for (int i = 0; i < numberOfDailyAverageNumberOfDifferentProducts.Length; i++)
            {
                if (expectedValues[i] != numberOfDailyAverageNumberOfDifferentProducts[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetYearlyRevenue_ReturnsCorrectArrayOfMonthlyRevenues()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/01/01 12:00:00");
            var receipts = new List<Receipt>
            {
                // Receipts within year.
                new Receipt() { Id = 1, GrandTotal = 11,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 00:00:01")},
                new Receipt() { Id = 2, GrandTotal = 12,
                    TimeOfPurchase = DateTime.Parse("2019/01/10 00:00:01")},
                new Receipt() { Id = 3, GrandTotal = 21,
                    TimeOfPurchase = DateTime.Parse("2019/02/16 00:00:01")},
                new Receipt() { Id = 4, GrandTotal = 31,
                    TimeOfPurchase = DateTime.Parse("2019/03/18 00:00:01")},
                new Receipt() { Id = 5, GrandTotal = 32,
                    TimeOfPurchase = DateTime.Parse("2019/03/03 00:00:01")},
                new Receipt() { Id = 6, GrandTotal = 33,
                    TimeOfPurchase = DateTime.Parse("2019/03/04 00:00:01")},
                new Receipt() { Id = 7, GrandTotal = 34,
                    TimeOfPurchase = DateTime.Parse("2019/03/15 00:00:01")},
                new Receipt() { Id = 8, GrandTotal = 41,
                    TimeOfPurchase = DateTime.Parse("2019/04/18 00:00:01")},
                new Receipt() { Id = 9, GrandTotal = 61,
                    TimeOfPurchase = DateTime.Parse("2019/06/19 00:00:01")},
                new Receipt() { Id = 10, GrandTotal = 62,
                    TimeOfPurchase = DateTime.Parse("2019/06/23 00:00:01")},
                new Receipt() { Id = 11, GrandTotal = 71,
                    TimeOfPurchase = DateTime.Parse("2019/07/02 00:00:01")},
                new Receipt() { Id = 12, GrandTotal = 72,
                    TimeOfPurchase = DateTime.Parse("2019/07/23 00:00:01")},
                new Receipt() { Id = 13, GrandTotal = 73,
                    TimeOfPurchase = DateTime.Parse("2019/07/01 00:00:01")},
                new Receipt() { Id = 14, GrandTotal = 91,
                    TimeOfPurchase = DateTime.Parse("2019/09/01 00:00:01")},
                new Receipt() { Id = 15, GrandTotal = 92,
                    TimeOfPurchase = DateTime.Parse("2019/09/15 00:00:01")},
                new Receipt() { Id = 16, GrandTotal = 93,
                    TimeOfPurchase = DateTime.Parse("2019/09/18 00:00:01")},
                new Receipt() { Id = 17, GrandTotal = 94,
                    TimeOfPurchase = DateTime.Parse("2019/09/19 00:00:01")},
                new Receipt() { Id = 18, GrandTotal = 95,
                    TimeOfPurchase = DateTime.Parse("2019/09/23 00:00:01")},
                new Receipt() { Id = 19, GrandTotal = 101,
                    TimeOfPurchase = DateTime.Parse("2019/10/02 00:00:01")},
                new Receipt() { Id = 20, GrandTotal = 102,
                    TimeOfPurchase = DateTime.Parse("2019/10/23 00:00:01")},
                new Receipt() { Id = 21, GrandTotal = 121,
                    TimeOfPurchase = DateTime.Parse("2019/12/01 00:00:01")},
                new Receipt() { Id = 22, GrandTotal = 122,
                    TimeOfPurchase = DateTime.Parse("2019/12/01 00:00:01")},

                // Receipts Out of year
                new Receipt() { Id = 20, GrandTotal = 10000,
                    TimeOfPurchase = DateTime.Parse("2017/10/23 00:00:01")},
                new Receipt() { Id = 21, GrandTotal = 20000,
                    TimeOfPurchase = DateTime.Parse("2017/12/31 00:00:01")},
                new Receipt() { Id = 22, GrandTotal = 30000,
                    TimeOfPurchase = DateTime.Parse("2020/01/01 00:00:01")},
            }.AsQueryable();

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            decimal[] yearlySalesReportValues = receiptBusiness.GetYearlyRevenue(testDateTime);

            // Assert
            decimal[] expectedValues = new decimal[] { 23, 21, 130, 41, 0, 123, 216, 0, 465, 203, 0, 243 };
            bool areValuesCorrect = true;
            for (int i = 0; i < yearlySalesReportValues.Length; i++)
            {
                if (expectedValues[i] != yearlySalesReportValues[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetMonthlyRevenue_ReturnsCorrectArrayOfDailyRevenues()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/01/01 12:00:00");
            var receipts = new List<Receipt>
            {
                // Receipts within month
                new Receipt() { Id = 1, GrandTotal = 11,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 00:00:01")},
                new Receipt() { Id = 2, GrandTotal = 12,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 00:00:01")},
                new Receipt() { Id = 3, GrandTotal = 21,
                    TimeOfPurchase = DateTime.Parse("2019/01/02 00:00:01")},
                new Receipt() { Id = 4, GrandTotal = 31,
                    TimeOfPurchase = DateTime.Parse("2019/01/03 00:00:01")},
                new Receipt() { Id = 5, GrandTotal = 32,
                    TimeOfPurchase = DateTime.Parse("2019/01/03 00:00:01")},
                new Receipt() { Id = 6, GrandTotal = 33,
                    TimeOfPurchase = DateTime.Parse("2019/01/03 00:00:01")},
                new Receipt() { Id = 7, GrandTotal = 34,
                    TimeOfPurchase = DateTime.Parse("2019/01/03 00:00:01")},
                new Receipt() { Id = 8, GrandTotal = 41,
                    TimeOfPurchase = DateTime.Parse("2019/01/04 00:00:01")},
                new Receipt() { Id = 9, GrandTotal = 61,
                    TimeOfPurchase = DateTime.Parse("2019/01/06 00:00:01")},
                new Receipt() { Id = 10, GrandTotal = 62,
                    TimeOfPurchase = DateTime.Parse("2019/01/06 00:00:01")},
                new Receipt() { Id = 11, GrandTotal = 71,
                    TimeOfPurchase = DateTime.Parse("2019/01/07 00:00:01")},
                new Receipt() { Id = 12, GrandTotal = 72,
                    TimeOfPurchase = DateTime.Parse("2019/01/07 00:00:01")},
                new Receipt() { Id = 13, GrandTotal = 73,
                    TimeOfPurchase = DateTime.Parse("2019/01/07 00:00:01")},
                new Receipt() { Id = 14, GrandTotal = 91,
                    TimeOfPurchase = DateTime.Parse("2019/01/09 00:00:01")},
                new Receipt() { Id = 15, GrandTotal = 92,
                    TimeOfPurchase = DateTime.Parse("2019/01/09 00:00:01")},
                new Receipt() { Id = 16, GrandTotal = 93,
                    TimeOfPurchase = DateTime.Parse("2019/01/09 00:00:01")},
                new Receipt() { Id = 17, GrandTotal = 94,
                    TimeOfPurchase = DateTime.Parse("2019/01/09 00:00:01")},
                new Receipt() { Id = 18, GrandTotal = 95,
                    TimeOfPurchase = DateTime.Parse("2019/01/09 00:00:01")},
                new Receipt() { Id = 19, GrandTotal = 101,
                    TimeOfPurchase = DateTime.Parse("2019/01/10 00:00:01")},
                new Receipt() { Id = 20, GrandTotal = 102,
                    TimeOfPurchase = DateTime.Parse("2019/01/10 00:00:01")},
                new Receipt() { Id = 21, GrandTotal = 121,
                    TimeOfPurchase = DateTime.Parse("2019/01/12 00:00:01")},
                new Receipt() { Id = 22, GrandTotal = 122,
                    TimeOfPurchase = DateTime.Parse("2019/01/12 00:00:01")},
                new Receipt() { Id = 23, GrandTotal = 131,
                    TimeOfPurchase = DateTime.Parse("2019/01/13 00:00:01")},
                new Receipt() { Id = 24, GrandTotal = 132,
                    TimeOfPurchase = DateTime.Parse("2019/01/13 00:00:01")},
                new Receipt() { Id = 25, GrandTotal = 161,
                    TimeOfPurchase = DateTime.Parse("2019/01/16 00:00:01")},
                new Receipt() { Id = 26, GrandTotal = 162,
                    TimeOfPurchase = DateTime.Parse("2019/01/16 00:00:01")},
                new Receipt() { Id = 27, GrandTotal = 163,
                    TimeOfPurchase = DateTime.Parse("2019/01/16 00:00:01")},
                new Receipt() { Id = 28, GrandTotal = 171,
                    TimeOfPurchase = DateTime.Parse("2019/01/17 00:00:01")},
                new Receipt() { Id = 29, GrandTotal = 181,
                    TimeOfPurchase = DateTime.Parse("2019/01/18 00:00:01")},
                new Receipt() { Id = 30, GrandTotal = 201,
                    TimeOfPurchase = DateTime.Parse("2019/01/20 00:00:01")},
                new Receipt() { Id = 31, GrandTotal = 202,
                    TimeOfPurchase = DateTime.Parse("2019/01/20 00:00:01")},
                new Receipt() { Id = 32, GrandTotal = 203,
                    TimeOfPurchase = DateTime.Parse("2019/01/20 00:00:01")},
                new Receipt() { Id = 33, GrandTotal = 204,
                    TimeOfPurchase = DateTime.Parse("2019/01/20 00:00:01")},
                new Receipt() { Id = 34, GrandTotal = 211,
                    TimeOfPurchase = DateTime.Parse("2019/01/21 00:00:01")},
                new Receipt() { Id = 35, GrandTotal = 221,
                    TimeOfPurchase = DateTime.Parse("2019/01/22 00:00:01")},
                new Receipt() { Id = 36, GrandTotal = 231,
                    TimeOfPurchase = DateTime.Parse("2019/01/23 00:00:01")},
                new Receipt() { Id = 37, GrandTotal = 232,
                    TimeOfPurchase = DateTime.Parse("2019/01/23 00:00:01")},
                new Receipt() { Id = 38, GrandTotal = 261,
                    TimeOfPurchase = DateTime.Parse("2019/01/26 00:00:01")},
                new Receipt() { Id = 39, GrandTotal = 262,
                    TimeOfPurchase = DateTime.Parse("2019/01/26 00:00:01")},
                new Receipt() { Id = 40, GrandTotal = 301,
                    TimeOfPurchase = DateTime.Parse("2019/01/30 00:00:01")},
                new Receipt() { Id = 41, GrandTotal = 31.31M,
                    TimeOfPurchase = DateTime.Parse("2019/01/31 00:00:01")},
                new Receipt() { Id = 42, GrandTotal = 32.32M,
                    TimeOfPurchase = DateTime.Parse("2019/01/31 00:00:01")},

                // Receipts out of month
                new Receipt() { Id = 43, GrandTotal = 10000,
                    TimeOfPurchase = DateTime.Parse("2019/02/01 00:00:01")},
                new Receipt() { Id = 44, GrandTotal = 20000,
                    TimeOfPurchase = DateTime.Parse("2018/12/31 23:59:59")},
                new Receipt() { Id = 45, GrandTotal = 30000,
                    TimeOfPurchase = DateTime.Parse("2018/01/05 00:00:01")},
            }.AsQueryable();

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            decimal[] monthlySalesReportValues = receiptBusiness.GetMonthlyRevenue(testDateTime);

            // Assert
            decimal[] expectedValues = new decimal[] { 23, 21, 130, 41, 0, 123, 216, 0, 465, 203, 0, 243, 263,
                                                            0, 0, 486, 171, 181, 0, 810, 211, 221, 463, 0, 0, 523, 0, 0, 0, 301, 63.63M};
            bool areValuesCorrect = true;
            for (int i = 0; i < monthlySalesReportValues.Length; i++)
            {
                if (expectedValues[i] != monthlySalesReportValues[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }

        [TestMethod]
        public void GetDailyRevenue_ReturnsCorrectArrayOfHourlyRevenues()
        {
            // Arrange
            var testDateTime = DateTime.Parse("2019/01/01 12:00:00");
            var receipts = new List<Receipt>
            {
                // Receipts within day
                new Receipt() { Id = 1, GrandTotal = 1,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 00:00:01")},
                new Receipt() { Id = 2, GrandTotal = 11,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 01:00:01")},
                new Receipt() { Id = 3, GrandTotal = 21,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 02:00:01")},
                new Receipt() { Id = 4, GrandTotal = 31,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 03:00:01")},
                new Receipt() { Id = 5, GrandTotal = 41,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 04:00:01")},
                new Receipt() { Id = 6, GrandTotal = 61,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 06:00:01")},
                new Receipt() { Id = 7, GrandTotal = 71,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 07:00:01")},
                new Receipt() { Id = 8, GrandTotal = 81,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 08:00:01")},
                new Receipt() { Id = 9, GrandTotal = 83.10M,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 08:30:01")},
                new Receipt() { Id = 10, GrandTotal = 91,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 09:00:01")},
                new Receipt() { Id = 11, GrandTotal = 101,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 10:00:01")},
                new Receipt() { Id = 12, GrandTotal = 111,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 11:00:01")},
                new Receipt() { Id = 13, GrandTotal = 121,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 12:00:01")},
                new Receipt() { Id = 14, GrandTotal = 131.51M,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 13:15:01")},
                new Receipt() { Id = 15, GrandTotal = 134.51M,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 13:45:01")},
                new Receipt() { Id = 16, GrandTotal = 141,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 14:00:01")},
                new Receipt() { Id = 17, GrandTotal = 151,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 15:00:01")},
                new Receipt() { Id = 18, GrandTotal = 161,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 16:00:01")},
                new Receipt() { Id = 19, GrandTotal = 171,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 17:00:01")},
                new Receipt() { Id = 20, GrandTotal = 181,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 18:00:01")},
                new Receipt() { Id = 21, GrandTotal = 191,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 19:00:01")},
                new Receipt() { Id = 22, GrandTotal = 201,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 20:00:01")},
                new Receipt() { Id = 23, GrandTotal = 211,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 21:00:01")},
                new Receipt() { Id = 24, GrandTotal = 221,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 22:00:01")},
                new Receipt() { Id = 25, GrandTotal = 231,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 23:00:01")},
                new Receipt() { Id = 26, GrandTotal = 23.31M,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 23:30:01")},
                new Receipt() { Id = 27, GrandTotal = 235.959M,
                    TimeOfPurchase = DateTime.Parse("2019/01/01 23:59:59")},
                
                // Receipts out of month
                new Receipt() { Id = 28, GrandTotal = 10000,
                    TimeOfPurchase = DateTime.Parse("2019/01/02 00:00:01")},
                new Receipt() { Id = 29, GrandTotal = 20000,
                    TimeOfPurchase = DateTime.Parse("2018/12/31 00:00:01")},
                new Receipt() { Id = 30, GrandTotal = 30000,
                    TimeOfPurchase = DateTime.Parse("2018/01/01 00:00:01")},
            }.AsQueryable();

            var receiptMockDbSet = new Mock<DbSet<Receipt>>();
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(receipts.Provider);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(receipts.Expression);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(receipts.ElementType);
            receiptMockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(receipts.GetEnumerator());

            var mockContext = new Mock<EazyCartContext>();
            mockContext.Setup(c => c.Receipts).Returns(receiptMockDbSet.Object);

            var receiptBusiness = new ReceiptBusiness(mockContext.Object);

            // Act
            decimal[] dailySalesReportValues = receiptBusiness.GetDailyRevenue(testDateTime);

            // Assert
            decimal[] expectedValues = new decimal[] { 33, 72, 296.10M, 303, 528.02M, 483, 573, 922.269M };
            bool areValuesCorrect = true;
            for (int i = 0; i < dailySalesReportValues.Length; i++)
            {
                if (expectedValues[i] != dailySalesReportValues[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
        }
    }
}