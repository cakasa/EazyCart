using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ProductReceiptBusiness
    {
        private EazyCartContext eazyCartContext;

        /// <summary>
        /// Return all product receipts.
        /// </summary>
        /// <returns></returns>
        public List<ProductReceipt> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Productsreceipts.ToList();
            }
        }

        /// <summary>
        /// Return a certain product receipt.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductReceipt Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Productsreceipts.Find(id);
            }
        }

        /// <summary>
        /// Return the most recent product receipt.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Return the product receipts with a given receipt number.
        /// </summary>
        /// <param name="receiptNumber"></param>
        /// <returns></returns>
        public List<ProductReceipt> GetAllByReceipt(int receiptNumber)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productsReceipt = eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == receiptNumber).ToList();
                return productsReceipt;
            }
        }

        /// <summary>
        /// Add a new product receipt.
        /// </summary>
        /// <param name="receiptId"></param>
        /// <param name="productCode"></param>
        /// <param name="quantityString"></param>
        /// <param name="discountString"></param>
        public void Add(int receiptId, string productCode, string quantityString, string discountString)
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
                if (product.Quantity < quantity)
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

        /// <summary>
        /// Update certain product receipt's fields by a given parameter
        /// of ProductReceipt type.
        /// </summary>
        /// <param name="productReceipt"></param>
        public void Update(ProductReceipt productReceipt)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                // Find the needed product receipt.
                var productReceiptToUpdate = eazyCartContext.Productsreceipts.Find(productReceipt.Id);
                if (productReceiptToUpdate != null)
                {
                    // Set the updated product receipt's fields.
                    eazyCartContext.Entry(productReceiptToUpdate).CurrentValues.SetValues(productReceipt);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Update certain product receipt's fields using four parameters.
        /// </summary>
        /// <param name="productReceiptId"></param>
        /// <param name="productCode"></param>
        /// <param name="quantityString"></param>
        /// <param name="discountString"></param>
        public void Update(int productReceiptId, string productCode, string quantityString, string discountString)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                decimal quantity;
                bool canQuantityBeParsed = decimal.TryParse(quantityString, out quantity);
                int discountPercentage;
                bool canDiscountBeParsed = int.TryParse(discountString, out discountPercentage);

                // Validation for quanity and discount.
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

                // // Update the supplier's fields.
                ProductReceipt newProductReceipt = new ProductReceipt
                {
                    Id = productReceiptId,
                    Quantity = quantity,
                    DiscountPercentage = discountPercentage,
                    ProductCode = productCode,
                    ReceiptId = receipt.Id
                };

                var productReceiptToUpdate = eazyCartContext.Productsreceipts.First(x => x.Id == productReceiptId);

                // Set the updated supplier's fields.
                eazyCartContext.Entry(productReceiptToUpdate).CurrentValues.SetValues(newProductReceipt);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a certain product receipt.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productReceipt = eazyCartContext.Productsreceipts.Find(id);
                if (productReceipt != null)
                {
                    // Remove the chosen product receipt and save the changes in the context.
                    eazyCartContext.Productsreceipts.Remove(productReceipt);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
