using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    /// <summary>
    /// This business logic class is responsible for managing the
    /// separate products in a receipt from the database.
    /// </summary>
    public class ProductReceiptBusiness
    {
        private EazyCartContext eazyCartContext;

        public ProductReceiptBusiness(EazyCartContext eazyCartContext)
        {
            this.eazyCartContext = eazyCartContext;
        }

        /// <summary>
        /// Get a certain product receipt by a given id.
        /// </summary>
        /// <param name="id">The Id of the ProductReceipt to return.</param>
        /// <returns>Return a ProductReceipt object, corresponding to the given Id.</returns>
        public ProductReceipt Get(int id)
        {
            return eazyCartContext.ProductsReceipts.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the most recent product receipt.
        /// </summary>
        /// <returns>Return the Id of the most recently created ProductBusiness entry.</returns>
        public int GetHighestId()
        {
            if (eazyCartContext.ProductsReceipts.Count() > 0)
            {
                return eazyCartContext.ProductsReceipts.Max(x => x.Id);
            }
            else return 0;
        }

        /// <summary>
        /// Get the productReceipts of a given order.
        /// </summary>
        /// <param name="receiptId">The Id of the receipt, all productReceipts are
        /// a part of.</param>
        /// <returns>A List of ProductReceipt with objects, corresponding to the
        /// receipt number.</returns>
        public List<ProductReceipt> GetAllByReceiptId(int receiptId)
        {
            var productsReceipt =
                eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == receiptId).ToList();
            return productsReceipt;
        }

        /// <summary>
        /// Add a new product receipt by given parameters.
        /// </summary>
        /// <param name="receiptId">Give the id of the receipt to add.</param>
        /// <param name="productCode">Give the code of the product to add.</param>
        /// <param name="quantityString">Give the quantity of the product to add.</param>
        /// <param name="discountString">Give the discount of the product to add
        /// if it has been given.</param>
        public void Add(int receiptId, string productCode, string quantityString, string discountString)
        {
            decimal quantity;
            bool canQuantityBeParsed = decimal.TryParse(quantityString, out quantity);
            int discountPercentage;
            bool canDiscountBeParsed = int.TryParse(discountString, out discountPercentage);

            // Validation for quanity.
            if (!canQuantityBeParsed || !canDiscountBeParsed)
            {
                throw new ArgumentException("Wrong values for quantity/discount");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be positive.");
            }
            if (discountPercentage < 0)
            {
                throw new ArgumentException("Discount must NOT be negative.");
            }
            var product = eazyCartContext.Products.FirstOrDefault(x => x.Code == productCode);
            if (product.Quantity < quantity)
            {
                throw new ArgumentException("Insufficient quantity");
            }
            // When the Unit is 'Unit', the quantity must be a whole number.
            if (Math.Ceiling(quantity) != quantity && product.UnitId == 1)
            {
                throw new ArgumentException("Quantity must be a whole number");
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

            var allProductReceiptsWithGivenId = eazyCartContext.ProductsReceipts.Where(x => x.Id == receiptId);
            if(allProductReceiptsWithGivenId.Count() > 0)
            {
                throw new ArgumentException("Such productReceipt is already added.");
            }
            eazyCartContext.ProductsReceipts.Add(productReceipt);
            eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Update certain product receipt's fields using four parameters.
        /// </summary>
        /// <param name="productReceiptId">Give the id of the receipt to update.</param>
        /// <param name="productCode">Give the code of the product to update.</param>
        /// <param name="quantityString">Give the quantity of the product to update.</param>
        /// <param name="discountString">Give the discount of the product to update
        /// if it has been given.</param>
        public void Update(int productReceiptId, string productCode, string quantityString, string discountString)
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
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be positive.");
            }
            if(discountPercentage < 0)
            {
                throw new ArgumentException("Discount must NOT be negative.");
            }
            var product = eazyCartContext.Products.FirstOrDefault(x => x.Code == productCode);

            if (quantity > product.Quantity)
            {
                throw new ArgumentException("Insufficient quantity");
            }

            if (Math.Ceiling(quantity) != quantity && product.UnitId == 1)
            {
                throw new ArgumentException("Quantity must be a whole number");
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

            var productReceiptToUpdate = eazyCartContext.ProductsReceipts.FirstOrDefault(x => x.Id == productReceiptId);

            // Set the updated supplier's fields.
            eazyCartContext.Entry(productReceiptToUpdate).CurrentValues.SetValues(newProductReceipt);
            eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Delete a certain product receipt.
        /// </summary>
        /// <param name="id">Give the id of the product to delete.</param>
        public void Delete(int id)
        {
            var productReceipt = eazyCartContext.ProductsReceipts.FirstOrDefault(x => x.Id == id);
            if (productReceipt != null)
            {
                // Remove the chosen product receipt and save the changes in the context.
                eazyCartContext.ProductsReceipts.Remove(productReceipt);
                eazyCartContext.SaveChanges();
            }
        }
    }
}
