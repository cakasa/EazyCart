using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace EazyCartUnitTests.BusinessUnitTests
{
    [TestClass]
    public class ReceiptBusinessUnitTests
    {
        //    public void CreateBlog_saves_a_blog_via_context()
        //    {
        //        var mockSet = new Mock<DbSet<Blog>>();

        //        var mockContext = new Mock<BloggingContext>();
        //        mockContext.Setup(m => m.Blogs).Returns(mockSet.Object);

        //        var service = new BlogService(mockContext.Object);
        //        service.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet");

        //        mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
        //        mockContext.Verify(m => m.SaveChanges(), Times.Once());
        //    }


        //public void GetAllBlogs_orders_by_name()
        //{
        //    var data = new List<Blog>
        //    {
        //        new Blog { Name = "BBB" },
        //        new Blog { Name = "ZZZ" },
        //        new Blog { Name = "AAA" },
        //    }.AsQueryable();

        //var mockSet = new Mock<DbSet<Blog>>();
        //mockSet.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(data.Provider);
        //mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
        //mockSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        //var mockContext = new Mock<BloggingContext>();
        //mockContext.Setup(c => c.Blogs).Returns(mockSet.Object);

        //var service = new BlogService(mockContext.Object);
        //var blogs = service.GetAllBlogs();

        //Assert.AreEqual(3, blogs.Count);
        //    Assert.AreEqual("AAA", blogs[0].Name);
        //    Assert.AreEqual("BBB", blogs[1].Name);
        //    Assert.AreEqual("ZZZ", blogs[2].Name);
        //}

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
        public void GetAll_ReturnsSuccessfullyReturnsAListOfReceipts()
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
            receiptBusiness.Add(1);

            // Assert
            receiptMockDbSet.Verify(m => m.Add(It.IsAny<Receipt>()), Times.Once());
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
            var testDateTime = DateTime.Now;
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
                    TimeOfPurchase = DateTime.Parse("2019/02/03 01:22:34") }
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
                if(expectedValues[i] != numberOfYearlyOrders[i])
                {
                    areValuesCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(areValuesCorrect, "Values are not correct");
          
        }
    }
}