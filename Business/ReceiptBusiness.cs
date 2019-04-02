﻿using Data.Models;
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

        public ReceiptBusiness(EazyCartContext eazyCartContext)
        {
            this.eazyCartContext = eazyCartContext;
        }

        /// <summary>
        /// Get all receipts.
        /// </summary>
        /// <returns>Return a list of all receipts.</returns>
        public List<Receipt> GetAll()
        {
            return eazyCartContext.Receipts.ToList();
        }

        /// <summary>
        /// Get a certain receipt.
        /// </summary>
        /// <param name="id">Give the id if the receipt.</param>
        /// <returns>Return the searched object of type receipt.</returns>
        public Receipt Get(int id)
        {
            return eazyCartContext.Receipts.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get the following receipt number.
        /// </summary>
        /// <returns>Return the incremented count of receipts.</returns>
        public int GetNextReceiptNumber()
        {
            return eazyCartContext.Receipts.Count() + 1;
        }

        /// <summary>
        /// Get information about orders for a whole year.
        /// </summary>
        /// <param name="currentDateTime">Give the current datetime we want to
        /// have the orders' information.</param>
        /// <returns>Return an array containing the order for each month.</returns>
        public int[] GetYearlyOrders(DateTime currentDateTime)
        {
            int currentYear = currentDateTime.Year;
            int[] numberOfOrders = new int[12];
            var allOrders = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Year == currentDateTime.Year).ToList();

            foreach (var order in allOrders)
            {
                int monthOfPurchase = order.TimeOfPurchase.Month;
                numberOfOrders[monthOfPurchase - 1]++;
            }

            return numberOfOrders;
        }

        /// <summary>
        /// Get information about sold products for a whole month.
        /// </summary>
        /// <param name="currentDateTime">Give the current datetime we want to
        /// have the orders' information.</param>
        /// <returns>Return an array containing the order for each day.</returns>
        public int[] GetMonthlyOrders(DateTime currentDateTime)
        {
            int numberOfMonthDays = DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month);
            int[] numberOfOrders = new int[numberOfMonthDays];
            var allOrders = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Month == currentDateTime.Month && x.TimeOfPurchase.Year == currentDateTime.Year).ToList();

            foreach (var order in allOrders)
            {
                int dayOfPurchase = order.TimeOfPurchase.Day;
                numberOfOrders[dayOfPurchase - 1]++;
            }

            return numberOfOrders;
        }

        /// <summary>
        /// Get information about orders for a whole day.
        /// </summary>
        /// <param name="currentDateTime">Give the current datetime we want to
        /// have the orders' information.</param>
        /// <returns>Return an array containing the order for each hour.</returns>
        public int[] GetDailyOrders(DateTime currentDateTime)
        {
            List<Receipt> allOrders = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Date == currentDateTime.Date).ToList();
            int[] numberOfOrders = new int[8];
            foreach (var order in allOrders)
            {
                int hourOfPurchase = order.TimeOfPurchase.Hour;
                if (hourOfPurchase == 0 || hourOfPurchase == 1 || hourOfPurchase == 2)
                {
                    numberOfOrders[0]++;
                }
                else if (hourOfPurchase == 3 || hourOfPurchase == 4 || hourOfPurchase == 5)
                {
                    numberOfOrders[1]++;
                }
                else if (hourOfPurchase == 6 || hourOfPurchase == 7 || hourOfPurchase == 8)
                {
                    numberOfOrders[2]++;
                }
                else if (hourOfPurchase == 9 || hourOfPurchase == 10 || hourOfPurchase == 11)
                {
                    numberOfOrders[3]++;
                }
                else if (hourOfPurchase == 12 || hourOfPurchase == 13 || hourOfPurchase == 14)
                {
                    numberOfOrders[4]++;
                }
                else if (hourOfPurchase == 15 || hourOfPurchase == 16 || hourOfPurchase == 17)
                {
                    numberOfOrders[5]++;
                }
                else if (hourOfPurchase == 18 || hourOfPurchase == 19 || hourOfPurchase == 20)
                {
                    numberOfOrders[6]++;
                }
                else
                {
                    numberOfOrders[7]++;
                }
            }
            return numberOfOrders;
        }

        /// <summary>
        /// Get information about orders made on discount for a whole year.
        /// </summary>
        /// <param name="currentDateTime">Give the current datetime we want to
        /// have the orders' information.</param>
        /// <returns>Return an array containing the order for each month.</returns>
        public int[] GetYearlyDiscountOrders(DateTime currentDateTime)
        {
            int currentYear = currentDateTime.Year;
            int[] numberOfOrdersWithDiscount = new int[12];
            var allOrders = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Year == currentDateTime.Year).ToList();

            foreach (var order in allOrders)
            {
                int monthOfPurchase = order.TimeOfPurchase.Month;
                foreach (var productReceipt in eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == order.Id))
                {
                    if (productReceipt.DiscountPercentage > 0)
                    {
                        numberOfOrdersWithDiscount[monthOfPurchase - 1]++;
                        break;
                    }
                }
            }

            return numberOfOrdersWithDiscount;
        }

        /// <summary>
        /// Get information about orders made on discount for a whole month.
        /// </summary>
        /// <param name="currentDateTime">Give the current datetime we want to
        /// have the orders' information.</param>
        /// <returns>Return an array containing the order for each day.</returns>
        public int[] GetMonthlyDiscountOrders(DateTime currentDateTime)
        {
            int numberOfMonthDays = DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month);

            int[] numberOfOrdersWithDiscount = new int[numberOfMonthDays];
            var allOrders = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Year == currentDateTime.Year && x.TimeOfPurchase.Month == currentDateTime.Month).ToList();

            foreach (var order in allOrders)
            {
                int dayOfPurchase = order.TimeOfPurchase.Day;
                foreach (var productReceipt in eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == order.Id))
                {
                    if (productReceipt.DiscountPercentage > 0)
                    {
                        numberOfOrdersWithDiscount[dayOfPurchase - 1]++;
                        break;
                    }
                }
            }

            return numberOfOrdersWithDiscount;
        }


        /// <summary>
        /// Get information about orders made on discount for a whole day.
        /// </summary>
        /// <param name="currentDateTime">Give the current datetime we want to
        /// have the orders' information.</param>
        /// <returns>Return an array containing the order for each hour.</returns>
        public int[] GetDailyDiscountOrders(DateTime currentDateTime)
        {
            List<Receipt> allOrders = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Date == currentDateTime.Date).ToList();
            int[] numberOfOrders = new int[8];
            foreach (var order in allOrders)
            {
                int hourOfPurchase = order.TimeOfPurchase.Hour;
                foreach (var productReceipt in eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == order.Id))
                {
                    if (productReceipt.DiscountPercentage > 0)
                    {
                        if (hourOfPurchase == 0 || hourOfPurchase == 1 || hourOfPurchase == 2)
                        {
                            numberOfOrders[0]++;
                        }
                        else if (hourOfPurchase == 3 || hourOfPurchase == 4 || hourOfPurchase == 5)
                        {
                            numberOfOrders[1]++;
                        }
                        else if (hourOfPurchase == 6 || hourOfPurchase == 7 || hourOfPurchase == 8)
                        {
                            numberOfOrders[2]++;
                        }
                        else if (hourOfPurchase == 9 || hourOfPurchase == 10 || hourOfPurchase == 11)
                        {
                            numberOfOrders[3]++;
                        }
                        else if (hourOfPurchase == 12 || hourOfPurchase == 13 || hourOfPurchase == 14)
                        {
                            numberOfOrders[4]++;
                        }
                        else if (hourOfPurchase == 15 || hourOfPurchase == 16 || hourOfPurchase == 17)
                        {
                            numberOfOrders[5]++;
                        }
                        else if (hourOfPurchase == 18 || hourOfPurchase == 19 || hourOfPurchase == 20)
                        {
                            numberOfOrders[6]++;
                        }
                        else
                        {
                            numberOfOrders[7]++;
                        }
                        break;
                    }
                }
            }
            return numberOfOrders;
        }

        /// <summary>
        /// Get information about the ordered products 
        /// from different types for a whole day.
        /// </summary>
        /// <param name="currentDateTime">Give the current datetime we want to
        /// have the orders' information.</param>
        /// <returns>Return an array containing the average 
        /// number of different products for a day.</returns>
        public decimal[] GetDailyAverageAmountOfDifferentProducts(DateTime currentDateTime)
        {
            decimal[] averageNumberOfDifferentProductsInOrder = new decimal[8];
            var allOrders = eazyCartContext.Receipts.ToList();
            List<Receipt> allOrdersForTheDay = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Date == currentDateTime.Date).ToList();

            for (int i = 0; i < 8; i++)
            {
                if (allOrdersForTheDay.Count() > 0)
                {
                    decimal totalCountOfDifferentProducts = 0;
                    foreach (var order in allOrdersForTheDay)
                    {
                        int hourOfPurchase = order.TimeOfPurchase.Hour;
                        if (hourOfPurchase == i * 3 || hourOfPurchase == i * 3 + 1 || hourOfPurchase == i * 3 + 2)
                        {
                            totalCountOfDifferentProducts += eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == order.Id).Count();
                        }
                    }
                    averageNumberOfDifferentProductsInOrder[i] = totalCountOfDifferentProducts / allOrdersForTheDay.Count();
                }
                else averageNumberOfDifferentProductsInOrder[i] = 0;
            }
            return averageNumberOfDifferentProductsInOrder;
        }

        /// <summary>
        /// Get information about the ordered products 
        /// from different types for a whole month.
        /// </summary>
        /// <param name="currentDateTime">Give the current datetime we want to
        /// have the orders' information.</param>
        /// <returns>Return an array containing the average 
        /// number of different products for a month.</returns>
        public decimal[] GetMonthlyAverageAmountOfDifferentProducts(DateTime currentDateTime)
        {
            int numberOfDays = DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month);
            decimal[] averageNumberOfDifferentProductsInOrder = new decimal[numberOfDays];
            var allOrders = eazyCartContext.Receipts.ToList();

            for (int i = 0; i < averageNumberOfDifferentProductsInOrder.Count(); i++)
            {
                List<Receipt> allOrdersForTheDay = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Year == currentDateTime.Year && x.TimeOfPurchase.Month == currentDateTime.Month && x.TimeOfPurchase.Day == i).ToList();
                if (allOrdersForTheDay.Count() > 0)
                {
                    decimal totalCountOfDifferentProducts = 0;
                    foreach (var order in allOrdersForTheDay)
                    {
                        totalCountOfDifferentProducts += eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == order.Id).Count();
                    }
                    averageNumberOfDifferentProductsInOrder[i] = totalCountOfDifferentProducts / allOrdersForTheDay.Count();
                }
                else averageNumberOfDifferentProductsInOrder[i] = 0;
            }

            return averageNumberOfDifferentProductsInOrder;
        }

        /// <summary>
        /// Get information about the ordered products 
        /// from different types for a whole year.
        /// </summary>
        /// <param name="currentDateTime">Give the current datetime we want to
        /// have the orders' information.</param>
        /// <returns>Return an array containing the average 
        /// number of different products for a year.</returns>
        public decimal[] GetYearlyAverageAmountOfDifferentProducts(DateTime currentDateTime)
        {
            int currentYear = currentDateTime.Year;
            decimal[] averageNumberOfDifferentProductsInOrder = new decimal[12];
            var allOrders = eazyCartContext.Receipts.ToList();

            for (int i = 0; i < 12; i++)
            {
                List<Receipt> allOrdersForTheMonth = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Year == currentDateTime.Year && x.TimeOfPurchase.Month == i).ToList();
                if (allOrdersForTheMonth.Count() > 0)
                {
                    decimal totalCountOfDifferentProducts = 0;
                    foreach (var order in allOrdersForTheMonth)
                    {
                        totalCountOfDifferentProducts += eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == order.Id).Count();
                    }
                    averageNumberOfDifferentProductsInOrder[i] = totalCountOfDifferentProducts / allOrdersForTheMonth.Count();
                }
                else averageNumberOfDifferentProductsInOrder[i] = 0;
            }

            return averageNumberOfDifferentProductsInOrder;
        }

        /// <summary>
        /// Add a new receipt using an id.
        /// </summary>
        /// <param name="id">Give the if of the new receipt to add.</param>
        public void Add(int id)
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

        /// <summary>
        /// Update certain receipt's fields by a given receipt id.
        /// </summary>
        /// <param name="receiptId">Give the id of the receipt to update.</param>
        public void Update(int receiptId)
        {
            // Find the needed receipt.
            var receiptToUpdate = eazyCartContext.Receipts.FirstOrDefault(x => x.Id == receiptId);
            var allProductReceipts = eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == receiptId);

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

            // Update the receipt's fields.
            var newReceipt = new Receipt()
            {
                Id = receiptId,
                TimeOfPurchase = DateTime.Now,
                GrandTotal = grandTotal
            };

            // Set the updated receipt's fields.
            eazyCartContext.Entry(receiptToUpdate).CurrentValues.SetValues(newReceipt);
            eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Delete a certain receipt.
        /// </summary>
        /// <param name="id">Give the id of the receipt to delete.</param>
        public void Delete(int id)
        {
            var receipt = eazyCartContext.Receipts.Find(id);
            var productReceipts = eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == id);
            eazyCartContext.ProductsReceipts.RemoveRange(productReceipts);

            eazyCartContext.Receipts.Remove(receipt);
            eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Delete the last receipt if it is empty.
        /// </summary>
        public void DeleteLastReceiptIfEmpty()
        {
            if (eazyCartContext.Receipts.Count() > 0)
            {
                var lastReceipt = eazyCartContext.Receipts.Last();
                var productReceipts = eazyCartContext.ProductsReceipts.Where(x => x.ReceiptId == lastReceipt.Id);
                if (productReceipts.Count() == 0)
                {
                    // Calls the delete method
                    Delete(lastReceipt.Id);
                }
            }
        }
    }
}
