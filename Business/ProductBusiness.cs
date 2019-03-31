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

        /// <summary>
        /// Return all products.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Products.ToList();
            }
        }

        /// <summary>
        /// Return all products' names.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Return a certain product.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Product Get(string code)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Products.First(x => x.Code == code);
            }
        }

        /// <summary>
        /// Return the the count of all products for each category
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Return the profit made by the products.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, decimal> GetNetProfitByProduct()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var netProfitByProduct = new Dictionary<string, decimal>();
                var allProducts = eazyCartContext.Products.ToList();
                foreach (var product in allProducts)
                {
                    decimal netProfit = product.SellingPrice - product.DeliveryPrice;
                    netProfitByProduct.Add(product.Name, netProfit);
                }

                return netProfitByProduct;
            }
        }

        /// <summary>
        /// Return the count of all products for each country.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetCountOfProductsByCountry()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productCountByCountry = new Dictionary<string, int>();
                var allProducts = eazyCartContext.Products.ToList();
                var allCountries = eazyCartContext.Countries.ToList();
                foreach (var country in allCountries)
                {
                    productCountByCountry.Add(country.Name, 0);
                }

                foreach (var product in allProducts)
                {
                    var supplier = eazyCartContext.Suppliers.Find(product.SupplierId);
                    var city = eazyCartContext.Cities.Find(supplier.CityId);
                    var country = eazyCartContext.Countries.Find(city.CountryId);
                    productCountByCountry[country.Name]++;
                }

                return productCountByCountry;
            }
        }

        /// <summary>
        /// Return the count of all products for each supplier.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetCountOfProductsBySuppliers()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productCountBySupplier = new Dictionary<string, int>();
                var allProducts = eazyCartContext.Products.ToList();
                var allSuppliers = eazyCartContext.Suppliers.ToList();
                foreach (var supplier in allSuppliers)
                {
                    int productCount = allProducts.Where(x => x.SupplierId == supplier.Id).Count();
                    productCountBySupplier.Add(supplier.Name, productCount);
                }

                return productCountBySupplier;
            }
        }

        /// <summary>
        /// Return the quantity of all products.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, decimal> GetAllQuantities()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var allProductQuantities = new Dictionary<string, decimal>();
                var allProducts = eazyCartContext.Products.ToList();
                foreach (var product in allProducts.OrderBy(x => x.Name))
                {
                    allProductQuantities.Add(product.Name, product.Quantity);
                }
                return allProductQuantities;
            }
        }

        /// <summary>
        /// Return information about sold products for a whole day.
        /// </summary>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        public decimal[] GetDailyRevenue(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Receipt> receipts = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Date == currentDateTime.Date).ToList();
                decimal[] revenueByHour = new decimal[8];
                foreach (var receipt in receipts)
                {
                    int hourOfPurchase = receipt.TimeOfPurchase.Hour;
                    if (hourOfPurchase == 0 || hourOfPurchase == 1 || hourOfPurchase == 2)
                    {
                        revenueByHour[0] += receipt.GrandTotal;
                    }
                    else if (hourOfPurchase == 3 || hourOfPurchase == 4 || hourOfPurchase == 5)
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

        /// <summary>
        /// Return information about sold products for a whole year.
        /// </summary>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        public decimal[] GetYearlyRevenue(DateTime currentDateTime)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Receipt> receipts = eazyCartContext.Receipts.Where(x => x.TimeOfPurchase.Year == currentDateTime.Year).ToList();
                decimal[] revenueByMonth = new decimal[12];
                foreach (var receipt in receipts)
                {
                    int month = receipt.TimeOfPurchase.Month;
                    revenueByMonth[month - 1] += receipt.GrandTotal;
                }

                return revenueByMonth;
            }
        }

        /// <summary>
        /// Return information about sold products for a whole month.
        /// </summary>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Return all products that match a typed 
        /// search phrase or a given category name.
        /// </summary>
        /// <param name="categoryString"></param>
        /// <param name="searchPhrase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Return all products by a given category name.
        /// </summary>
        /// <param name="categoryString"></param>
        /// <returns></returns>
        public List<Product> GetAllByCategory(string categoryString)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var category = eazyCartContext.Categories.First(x => x.Name == categoryString);
                var products = eazyCartContext.Products.Where(x => x.CategoryId == category.Id).ToList();

                return products;
            }
        }

        /// <summary>
        /// Return all products that match a typed search phrase.
        /// </summary>
        /// <param name="searchPhrase"></param>
        /// <returns></returns>
        public List<Product> GetAllByNameOrId(string searchPhrase)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var products = eazyCartContext.Products.Where(x => x.Name.ToUpper().Contains(searchPhrase.ToUpper()) || x.Code.ToUpper().Contains(searchPhrase.ToUpper())).ToList();

                return products;
            }
        }

        /// <summary>
        /// Add a new product.
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Products.Add(product);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Add a certain product by providing information about
        /// each of product's fields.
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="categoryName"></param>
        /// <param name="productName"></param>
        /// <param name="quantity"></param>
        /// <param name="supplierName"></param>
        /// <param name="deliveryPrice"></param>
        /// <param name="sellingPrice"></param>
        /// <param name="unitName"></param>
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

        /// <summary>
        /// Update certain product's fields.
        /// </summary>
        /// <param name="product"></param>
        public void Update(Product product)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                // Find the needed product.
                var productToUpdate = eazyCartContext.Products.Find(product.Code);
                if (productToUpdate != null)
                {
                    // Set the updated product's fields.
                    eazyCartContext.Entry(productToUpdate).CurrentValues.SetValues(product);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Update a certain product by providing information about
        /// each of product's fields.
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="categoryName"></param>
        /// <param name="productName"></param>
        /// <param name="quantity"></param>
        /// <param name="supplierName"></param>
        /// <param name="deliveryPrice"></param>
        /// <param name="sellingPrice"></param>
        /// <param name="unitName"></param>
        public void Update(string productCode, string categoryName, string productName, decimal quantity,
            string supplierName, decimal deliveryPrice, decimal sellingPrice, string unitName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var category = eazyCartContext.Categories.First(x => x.Name == categoryName);
                var supplier = eazyCartContext.Suppliers.First(x => x.Name == supplierName);
                var unit = eazyCartContext.Units.First(x => x.Name == unitName);

                // Update the supplier's fields.
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

                // Set the updated supplier's fields.
                eazyCartContext.Entry(productToUpdate).CurrentValues.SetValues(newProduct);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Make a delivery for a certain product.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="quantity"></param>
        public void MakeDelivery(string productName, decimal quantity)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var product = eazyCartContext.Products.First(x => x.Name == productName);

                // Validation for quanity.
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

        /// <summary>
        /// Delete a certain product.
        /// </summary>
        /// <param name="productCode"></param>
        public void Delete(string productCode)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var product = eazyCartContext.Products.First(x => x.Code == productCode);
                if (product != null)
                {

                    // Remove the chosen country and save the changes in the context.
                    eazyCartContext.Products.Remove(product);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
