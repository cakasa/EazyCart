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

        public int[] GetYearlyOrders(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                int currentYear = currentDateTime.Year;
                int[] numberOfOrders = new int[12];
                var allOrders = eazyCartContext.Receipts.Where(x=>x.TimeOfPurchase.Year == currentDateTime.Year).ToList();

                foreach (var order in allOrders)
                {
                    int monthOfPurchase = order.TimeOfPurchase.Month;
                    numberOfOrders[monthOfPurchase - 1]++;
                }

                return numberOfOrders;
            }
        }

        public int[] GetMonthlyOrders(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                int numberOfMonthDays = DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month);
                int[] numberOfOrders = new int[numberOfMonthDays];
                var allOrders = eazyCartContext.Receipts.Where(x=>x.TimeOfPurchase.Month == currentDateTime.Month && x.TimeOfPurchase.Year == currentDateTime.Year).ToList();

                foreach (var order in allOrders)
                {
                    int dayOfPurchase = order.TimeOfPurchase.Day;
                    numberOfOrders[dayOfPurchase - 1]++;
                }

                return numberOfOrders;
            }
        }

        public int[] GetDailyOrders(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
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
        }

        public int[] GetYearlyDiscountOrders(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                int currentYear = currentDateTime.Year;
                int[] numberOfOrdersWithDiscount = new int[12];
                var allOrders = eazyCartContext.Receipts.Where(x=>x.TimeOfPurchase.Year == currentDateTime.Year).ToList();

                foreach (var order in allOrders)
                {
                    int monthOfPurchase = order.TimeOfPurchase.Month;
                    foreach (var productReceipt in eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == order.Id))
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
        }

        public int[] GetMonthlyDiscountOrders(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                int numberOfMonthDays = DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month);

                int[] numberOfOrdersWithDiscount = new int[numberOfMonthDays];
                var allOrders = eazyCartContext.Receipts.Where(x=>x.TimeOfPurchase.Year == currentDateTime.Year && x.TimeOfPurchase.Month == currentDateTime.Month).ToList();

                foreach (var order in allOrders)
                {
                    int dayOfPurchase = order.TimeOfPurchase.Day;
                    foreach (var productReceipt in eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == order.Id))
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
        }

        public int[] GetDailyDiscountOrders(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Receipt> allOrders = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Date == currentDateTime.Date).ToList();
                int[] numberOfOrders = new int[8];
                foreach (var order in allOrders)
                {
                    int hourOfPurchase = order.TimeOfPurchase.Hour;
                    foreach (var productReceipt in eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == order.Id))
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
        }

        public decimal[] GetDailyAverageAmountOfDifferentProducts(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
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
                                totalCountOfDifferentProducts += eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == order.Id).Count();
                            }
                        }
                        averageNumberOfDifferentProductsInOrder[i] = totalCountOfDifferentProducts / allOrdersForTheDay.Count();
                    }
                    else averageNumberOfDifferentProductsInOrder[i] = 0;
                }
                return averageNumberOfDifferentProductsInOrder;
            }
        }

        public decimal[] GetMonthlyverageAmountOfDifferentProducts(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
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
                            totalCountOfDifferentProducts += eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == order.Id).Count();
                        }
                        averageNumberOfDifferentProductsInOrder[i] = totalCountOfDifferentProducts / allOrdersForTheDay.Count();
                    }
                    else averageNumberOfDifferentProductsInOrder[i] = 0;
                }

                return averageNumberOfDifferentProductsInOrder;
            }
        }

        public decimal[] GetYearlyAverageAmountOfDifferentProducts(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
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
                            totalCountOfDifferentProducts += eazyCartContext.Productsreceipts.Where(x => x.ReceiptId == order.Id).Count();
                        }
                        averageNumberOfDifferentProductsInOrder[i] = totalCountOfDifferentProducts / allOrdersForTheMonth.Count();
                    }
                    else averageNumberOfDifferentProductsInOrder[i] = 0;
                }

                return averageNumberOfDifferentProductsInOrder;
            }
        }
    }
}
