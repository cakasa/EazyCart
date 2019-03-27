using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ProductReceiptBusiness
    {
        private EazyCartContext eazyCartContext;

        public List<ProductReceipt> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Productsreceipts.ToList();
            }
        }

        public ProductReceipt Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Productsreceipts.Find(id);
            }
        }

        public void Update(ProductReceipt productReceipt)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productReceiptToUpdate = eazyCartContext.Productsreceipts.Find(productReceipt.Id);
                if (productReceiptToUpdate != null)
                {
                    eazyCartContext.Entry(productReceiptToUpdate).CurrentValues.SetValues(productReceipt);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public int GetHighestId()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                if (eazyCartContext.Productsreceipts.Count() > 0)
                {
                    return eazyCartContext.Productsreceipts.Max(x => x.Id);
                }
                else return 0;
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productReceipt = eazyCartContext.Productsreceipts.Find(id);
                if (productReceipt != null)
                {
                    eazyCartContext.Productsreceipts.Remove(productReceipt);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public List<ProductReceipt> GetAllByReceipt(int receiptNumber)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productsReceipt = eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == receiptNumber).ToList();
                return productsReceipt;
            }
        }

        public void Add(int receiptId, string productCode, string quantityString, string discountString)
        {
            using(eazyCartContext = new EazyCartContext())
            {
                decimal quantity;
                bool canQuantityBeParsed = decimal.TryParse(quantityString, out quantity);
                int discountPercentage;
                bool canDiscountBeParsed = int.TryParse(discountString, out discountPercentage);

                if(!canQuantityBeParsed || !canDiscountBeParsed)
                {
                    throw new ArgumentException("Wrong values for quantity/discount");
                }
                var product = eazyCartContext.Products.First(x=>x.Code == productCode);
                if(product.Quantity < quantity)
                {
                    throw new ArgumentException("Insufficient quantity");
                }
                Receipt receipt = eazyCartContext.Receipts.Last();
                ProductReceipt productReceipt = new ProductReceipt
                {
                    Id = receiptId,
                    Quantity = quantity,
                    DiscountPercentage = discountPercentage,
                    ProductCode = productCode,
                    ReceiptId = receipt.Id
                };

                eazyCartContext.Productsreceipts.Add(productReceipt);
                try
                {
                    eazyCartContext.SaveChanges();
                }
                catch
                {
                    throw new ArgumentException("This product is already added.");
                }
            }
        }

        public void Update(int productReceiptId, string productCode, string quantityString, string discountString)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                decimal quantity;
                bool canQuantityBeParsed = decimal.TryParse(quantityString, out quantity);
                int discountPercentage;
                bool canDiscountBeParsed = int.TryParse(discountString, out discountPercentage);

                if (!canQuantityBeParsed || !canDiscountBeParsed)
                {
                    throw new ArgumentException("Wrong values for quantity/discount");
                }
                var product = eazyCartContext.Products.First(x => x.Code == productCode);

                if (quantity > product.Quantity)
                {
                    throw new ArgumentException("Insufficient quantity");
                }

                Receipt receipt = eazyCartContext.Receipts.Last();
                ProductReceipt newProductReceipt = new ProductReceipt
                {
                    Id = productReceiptId,
                    Quantity = quantity,
                    DiscountPercentage = discountPercentage,
                    ProductCode = productCode,
                    ReceiptId = receipt.Id
                };

                var productReceiptToUpdate = eazyCartContext.Productsreceipts.First(x => x.Id == productReceiptId);
                eazyCartContext.Entry(productReceiptToUpdate).CurrentValues.SetValues(newProductReceipt);
                eazyCartContext.SaveChanges();
            }
        }
    }
}
