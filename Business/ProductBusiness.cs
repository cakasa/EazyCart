using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBusiness
    {
        private EazyCartContext eazyCartContext;

        public List<Product> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Products.ToList();
            }
        }

        public List<string> GetAllNames()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Product> allProducts = eazyCartContext.Products.ToList();
                var allProductNames = new List<string>();
                allProductNames.AddRange(allProducts.Select(x => x.Name).ToList());
                return allProductNames;
            }
        }

        public Product Get(string code)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Products.First(x => x.Code == code);
            }
        }

        public void Add(Product product)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Products.Add(product);
                eazyCartContext.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productToUpdate = eazyCartContext.Products.Find(product.Code);
                if (productToUpdate != null)
                {
                    eazyCartContext.Entry(productToUpdate).CurrentValues.SetValues(product);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Delete(string productCode)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var product = eazyCartContext.Products.First(x => x.Code == productCode);
                if (product != null)
                {
                    eazyCartContext.Products.Remove(product);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Add(string productCode, string categoryName, string productName, decimal quantity, string supplierName,
            decimal deliveryPrice, decimal sellingPrice, string unitName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var category = eazyCartContext.Categories.First(x => x.Name == categoryName);
                var supplier = eazyCartContext.Suppliers.First(x => x.Name == supplierName);
                var unit = eazyCartContext.Units.First(x => x.Name == unitName);

                var product = new Product
                {
                    Code = productCode,
                    CategoryId = category.Id,
                    Name = productName,
                    Quantity = quantity,
                    SupplierId = supplier.Id,
                    DeliveryPrice = deliveryPrice,
                    SellingPrice = sellingPrice,
                    UnitId = unit.Id
                };

                eazyCartContext.Products.Add(product);
                
                try
                {
                    eazyCartContext.SaveChanges();
                }
                catch
                {
                    throw new ArgumentException($"Product with code {productCode} already exists.");
                }
            }
        }

        public void Update(string productCode, string categoryName, string productName, decimal quantity,
            string supplierName, decimal deliveryPrice, decimal sellingPrice, string unitName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var category = eazyCartContext.Categories.First(x => x.Name == categoryName);
                var supplier = eazyCartContext.Suppliers.First(x => x.Name == supplierName);
                var unit = eazyCartContext.Units.First(x => x.Name == unitName);

                var newProduct = new Product
                {
                    Code = productCode,
                    CategoryId = category.Id,
                    Name = productName,
                    Quantity = quantity,
                    SupplierId = supplier.Id,
                    DeliveryPrice = deliveryPrice,
                    SellingPrice = sellingPrice,
                    UnitId = unit.Id
                };

                var productToUpdate = eazyCartContext.Products.First(x => x.Code == productCode);
                eazyCartContext.Entry(productToUpdate).CurrentValues.SetValues(newProduct);
                eazyCartContext.SaveChanges();
            }
        }

        public void MakeDelivery(string productName, decimal quantity)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var product = eazyCartContext.Products.First(x => x.Name == productName);
                if (quantity != Math.Floor(quantity) && product.UnitId == 1)
                {
                    throw new ArgumentException("Quantity must be a whole number");
                }
                if (quantity <= 0)
                {
                    throw new ArgumentException("Quantity must be positive");
                }

                var newProduct = new Product
                {
                    Code = product.Code,
                    CategoryId = product.CategoryId,
                    Name = product.Name,
                    Quantity = product.Quantity + quantity,
                    SupplierId = product.SupplierId,
                    DeliveryPrice = product.DeliveryPrice,
                    SellingPrice = product.SellingPrice,
                    UnitId = product.UnitId
                };

                eazyCartContext.Entry(product).CurrentValues.SetValues(newProduct);
                eazyCartContext.SaveChanges();
            }
        }

        public Dictionary<string, int> GetCountOfProductsByCategory()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productCountByCategory = new Dictionary<string, int>();
                var allProducts = eazyCartContext.Products.ToList();
                var allCategories = eazyCartContext.Categories.ToList();
                foreach (var category in allCategories)
                {
                    int productCount = allProducts.Where(x => x.CategoryId == category.Id).Count();
                    productCountByCategory.Add(category.Name, productCount);
                }

                return productCountByCategory;
            }
        }

        public Dictionary<string, int> GetCountOfProductsBySuppliers()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productCountBySupplier = new Dictionary<string, int>();
                var allProducts = eazyCartContext.Products.ToList();
                var allSuppliers = eazyCartContext.Suppliers.ToList();
                foreach(var supplier in allSuppliers)
                {
                    int productCount = allProducts.Where(x => x.SupplierId == supplier.Id).Count();
                    productCountBySupplier.Add(supplier.Name, productCount);
                }
     
                return productCountBySupplier;
            }
        }

        public Dictionary<string, decimal> GetAllQuantities()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var allProductQuantities = new Dictionary<string, decimal>();
                var allProducts = eazyCartContext.Products.ToList();
                foreach(var product in allProducts.OrderBy(x=>x.Name))
                {
                    allProductQuantities.Add(product.Name, product.Quantity);
                }
                return allProductQuantities;
            }
        }

        public decimal[] GetDailyRevenue(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Receipt> receipts = eazyCartContext.Receipts.Where(x=>x.TimeOfPurchase.Date == currentDateTime.Date).ToList();
                decimal[] revenueByHour = new decimal[8];
                foreach(var receipt in receipts)
                {
                    int hourOfPurchase = receipt.TimeOfPurchase.Hour;
                    if(hourOfPurchase == 0 || hourOfPurchase == 1 || hourOfPurchase == 2)
                    {
                        revenueByHour[0] += receipt.GrandTotal;
                    }
                    else if(hourOfPurchase == 3 || hourOfPurchase == 4 || hourOfPurchase == 5)
                    {
                        revenueByHour[1] += receipt.GrandTotal;
                    }
                    else if (hourOfPurchase == 6 || hourOfPurchase == 7 || hourOfPurchase == 8)
                    {
                        revenueByHour[2] += receipt.GrandTotal;
                    }
                    else if (hourOfPurchase == 9 || hourOfPurchase == 10 || hourOfPurchase == 11)
                    {
                        revenueByHour[3] += receipt.GrandTotal;
                    }
                    else if (hourOfPurchase == 12 || hourOfPurchase == 13 || hourOfPurchase == 14)
                    {
                        revenueByHour[4] += receipt.GrandTotal;
                    }
                    else if (hourOfPurchase == 15 || hourOfPurchase == 16 || hourOfPurchase == 17)
                    {
                        revenueByHour[5] += receipt.GrandTotal;
                    }
                    else if (hourOfPurchase == 18 || hourOfPurchase == 19 || hourOfPurchase == 20)
                    {
                        revenueByHour[6] += receipt.GrandTotal;
                    }
                    else
                    {
                        revenueByHour[7] += receipt.GrandTotal;
                    }
                }
                return revenueByHour;
            }
        }

        public decimal[] GetYearlyRevenue(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Receipt> receipts = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Year == currentDateTime.Year).ToList();
                decimal[] revenueByMonth = new decimal[12];
                foreach(var receipt in receipts)
                {
                    int month = receipt.TimeOfPurchase.Month;
                    revenueByMonth[month - 1] += receipt.GrandTotal; 
                }

                return revenueByMonth;
            }
        }

        public decimal[] GetMonthlyRevenue(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Receipt> receipts = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Month == currentDateTime.Month).ToList();
                decimal[] revenueByDay = new decimal[DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month)];
                foreach (var receipt in receipts)
                {
                    int day = receipt.TimeOfPurchase.Day;
                    revenueByDay[day - 1] += receipt.GrandTotal;
                }
                return revenueByDay;
            }
        }

        public List<Product> GetAllByCategoryAndNameOrId(string categoryString, string searchPhrase)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var category = eazyCartContext.Categories.First(x => x.Name == categoryString);
                var products = eazyCartContext
                                    .Products
                                    .Where(x => x.CategoryId == category.Id && (x.Name.ToUpper().Contains(searchPhrase.ToUpper()) || x.Code.ToUpper().Contains(searchPhrase.ToUpper())))
                                    .ToList();

                return products;
            }
        }

        public List<Product> GetAllByCategory(string categoryString)
        {
            using(eazyCartContext = new EazyCartContext())
            {
                var category = eazyCartContext.Categories.First(x => x.Name == categoryString);
                var products = eazyCartContext.Products.Where(x => x.CategoryId == category.Id).ToList();

                return products;
            }
        }

        public List<Product> GetAllByNameOrId(string searchPhrase)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var products = eazyCartContext.Products.Where(x => x.Name.ToUpper().Contains(searchPhrase.ToUpper()) || x.Code.ToUpper().Contains(searchPhrase.ToUpper())).ToList();

                return products;
            }
        }
    }
}
