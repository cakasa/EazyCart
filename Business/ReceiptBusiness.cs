using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ReceiptBusiness
    {
        private EazyCartContext eazyCartContext;
        private ProductReceiptBusiness productReceiptBusiness = new ProductReceiptBusiness();

        public int GetNextReceiptNumber()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Receipts.Count() + 1;
            }
        }

        public List<Receipt> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Receipts.ToList();
            }
        }

        public Receipt Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Receipts.Find(id);
            }
        }

        public void Add(Receipt receipt)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Receipts.Add(receipt);
                eazyCartContext.SaveChanges();
            }
        }

        public void DeleteLastReceiptIfEmpty()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                if (eazyCartContext.Receipts.Count() > 0)
                {
                    var lastReceipt = eazyCartContext.Receipts.Last();
                    var productReceipts = eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == lastReceipt.Id);
                    if (productReceipts.Count() == 0)
                    {
                        Delete(lastReceipt.Id);
                    }
                }
            }
        }

        public void Update(int receiptId)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var receiptToUpdate = eazyCartContext.Receipts.Find(receiptId);
                var allProductReceipts = eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == receiptId);

                if (allProductReceipts.Count() == 0)
                {
                    throw new ArgumentException("No products in this receipt");
                }

                decimal grandTotal = 0;
                foreach (var productReceipt in allProductReceipts)
                {
                    var product = eazyCartContext.Products.First(x => x.Code == productReceipt.ProductCode);
                    product.Quantity -= productReceipt.Quantity;
                    grandTotal += (product.SellingPrice * productReceipt.Quantity) * (1 - 0.01M * (decimal)productReceipt.DiscountPercentage);
                }
                var newReceipt = new Receipt()
                {
                    Id = receiptId,
                    TimeOfPurchase = DateTime.Now,
                    GrandTotal = grandTotal
                };

                eazyCartContext.Entry(receiptToUpdate).CurrentValues.SetValues(newReceipt);
                eazyCartContext.SaveChanges();
            }
        }

        public void AddNewReceipt(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                Receipt receipt = new Receipt
                {
                    Id = id,
                    TimeOfPurchase = DateTime.Now,
                    GrandTotal = 0
                };

                eazyCartContext.Receipts.Add(receipt);
                eazyCartContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var receipt = eazyCartContext.Receipts.Find(id);
                var productReceipts = eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == id);
                eazyCartContext.Productsreceipts.RemoveRange(productReceipts);

                eazyCartContext.Receipts.Remove(receipt);
                eazyCartContext.SaveChanges();
            }
        }


    }
}
