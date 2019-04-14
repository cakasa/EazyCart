using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Controllers
{
    public class ProductBusiness
    {
        private EazyCartContext eazyCartContext;

        public ProductBusiness(EazyCartContext eazyCartContext)
        {
            this.eazyCartContext = eazyCartContext;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>List of all products.</returns>
        public List<Product> GetAll()
        {
            return this.eazyCartContext.Products.ToList();
        }

        /// <summary>
        /// Get all products' names.
        /// </summary>
        /// <returns>List of all products' names.</returns>
        public List<string> GetAllNames()
        {
            List<Product> allProducts = this.eazyCartContext.Products.ToList();
            var allProductNames = new List<string>();
            allProductNames.AddRange(allProducts.Select(x => x.Name).ToList());
            return allProductNames;
        }

        /// <summary>
        /// Get a certain product.
        /// </summary>
        /// <param name="code">Give the code of the searched product.</param>
        /// <returns>Return the first product of type Product with the wanted code.</returns>
        public Product Get(string code)
        {
            return this.eazyCartContext.Products.First(x => x.Code == code);
        }

        /// <summary>
        /// Get the the count of all products for each category.
        /// </summary>
        /// <returns>Return a dictionary with key containing the name of the
        /// category and value containing the count of the products
        /// from the relevant category.</returns>
        public Dictionary<string, int> GetCountOfProductsByCategory()
        {
            var productCountByCategory = new Dictionary<string, int>();
            var allProducts = this.eazyCartContext.Products.ToList();
            var allCategories = this.eazyCartContext.Categories.ToList();

            foreach (var category in allCategories)
            {
                int productCount = allProducts.Where(x => x.CategoryId == category.Id).Count();
                productCountByCategory.Add(category.Name, productCount);
            }

            return productCountByCategory;
        }

        /// <summary>
        /// Get the profit made by the products.
        /// </summary> 
        /// <returns>Return a dictionary with key containing the name of the
        /// product and value containing the net profit made by each products.</returns>
        public Dictionary<string, decimal> GetNetProfitByProduct()
        {
            var netProfitByProduct = new Dictionary<string, decimal>();
            var allProducts = this.eazyCartContext.Products.ToList();

            foreach (var product in allProducts)
            {
                decimal netProfit = product.SellingPrice - product.DeliveryPrice;
                netProfitByProduct.Add(product.Name, netProfit);
            }

            return netProfitByProduct;
        }

        /// <summary>
        /// Get the count of all products for each country.
        /// </summary>
        /// <returns>Return a dictionary with key containing the name of the
        /// country and value containing the count of each products based on
        /// the country from which they come from.</returns>
        public Dictionary<string, int> GetCountOfProductsByCountry()
        {
            var productCountByCountry = new Dictionary<string, int>();
            var allProducts = this.eazyCartContext.Products.ToList();
            var allCountries = this.eazyCartContext.Countries.ToList();

            foreach (var country in allCountries)
            {
                productCountByCountry.Add(country.Name, 0);
            }

            foreach (var product in allProducts)
            {
                var supplier = this.eazyCartContext.Suppliers.FirstOrDefault(x => x.Id == product.SupplierId);
                var city = this.eazyCartContext.Cities.FirstOrDefault(x => x.Id == supplier.CityId);
                var country = this.eazyCartContext.Countries.FirstOrDefault(x => x.Id == city.CountryId);
                productCountByCountry[country.Name]++;
            }

            return productCountByCountry;
        }

        /// <summary>
        /// Get the count of all products for each supplier.
        /// </summary>
        /// <returns>Return a dictionary with key containing the name of the
        /// supplier and value containing the count of products it provides.</returns>
        public Dictionary<string, int> GetCountOfProductsBySuppliers()
        {
            var productCountBySupplier = new Dictionary<string, int>();
            var allProducts = this.eazyCartContext.Products.ToList();
            var allSuppliers = this.eazyCartContext.Suppliers.ToList();

            foreach (var supplier in allSuppliers)
            {
                int productCount = allProducts.Where(x => x.SupplierId == supplier.Id).Count();
                productCountBySupplier.Add(supplier.Name, productCount);
            }

            return productCountBySupplier;
        }

        /// <summary>
        /// Get the quantity of all products.
        /// </summary>
        /// <returns>Returns a dictionary with key containing the name of the
        /// product and value containing its count.</returns>
        public Dictionary<string, decimal> GetAllQuantities()
        {
            var allProductQuantities = new Dictionary<string, decimal>();
            var allProducts = this.eazyCartContext.Products.ToList();

            foreach (var product in allProducts.OrderBy(x => x.Name))
            {
                allProductQuantities.Add(product.Name, product.Quantity);
            }

            return allProductQuantities;
        }

        /// <summary>
        /// Get all products that match a typed 
        /// search phrase or a given category name.
        /// </summary>
        /// <param name="categoryString">Give the name of the category.</param>
        /// <param name="searchPhrase">Give the searched string.</param>
        /// <returns>Return a list of the products that suit the given condition.</returns>
        public List<Product> GetAllByCategoryAndNameCodeOrBarcode(string categoryString, string searchPhrase)
        {
            var category = this.eazyCartContext.Categories.First(x => x.Name == categoryString);
            var products = this.eazyCartContext
                                .Products
                                .Where(x => x.CategoryId == category.Id &&
                                    (x.Name.ToUpper().Contains(searchPhrase.ToUpper()) ||
                                     x.Code.ToUpper().Contains(searchPhrase.ToUpper()) ||
                                     x.Barcode.ToUpper().Contains(searchPhrase.ToUpper())))
                                .ToList();

            return products;
        }

        /// <summary>
        /// Get all products whose category corresponds to the given name.
        /// </summary>
        /// <param name="categoryString">Give the name of the category.</param>
        /// <returns>Return a list of the products from a wanted catrgory.</returns>
        public List<Product> GetAllByCategory(string categoryString)
        {
            var category = this.eazyCartContext.Categories.First(x => x.Name == categoryString);
            var products = this.eazyCartContext.Products.Where(x => x.CategoryId == category.Id).ToList();

            return products;
        }

        /// <summary>
        /// Get all products that match a typed search phrase.
        /// </summary>
        /// <param name="searchPhrase">Give the searched string.</param>
        /// <returns>Return a list of the products that suit the given condition.</returns>
        public List<Product> GetAllByNameCodeOrBarcode(string searchPhrase)
        {
            var products = this.eazyCartContext
                                .Products
                                .Where(x => x.Name.ToUpper().Contains(searchPhrase.ToUpper()) ||
                                       x.Code.ToUpper().Contains(searchPhrase.ToUpper()) ||
                                       x.Barcode.ToUpper().Contains(searchPhrase.ToUpper()))
                                .ToList();

            return products;

        }

        /// <summary>
        /// Add a certain product by providing information about
        /// each of product's fields.
        /// </summary>
        /// <param name="productCode">Give the product's code to add.</param>
        /// <param name="productBarcode">Give the product's barcode to add.</param>
        /// <param name="categoryName">Give the product's category to add.</param>
        /// <param name="productName">Give the product's name to add.</param>
        /// <param name="quantity">Give the product's quantity to add.</param>
        /// <param name="supplierName">Give the product's supplier name to add.</param>
        /// <param name="deliveryPrice">Give the product's delivery price to add.</param>
        /// <param name="sellingPrice">Give the product's selling price to add.</param>
        /// <param name="unitName">Give the product's unit name to add.</param>
        public void Add(string productCode, string productBarcode, string categoryName, string productName, decimal quantity,
                string supplierName, decimal deliveryPrice, decimal sellingPrice, string unitName)
        {
            var unit = this.eazyCartContext.Units.First(x => x.Name == unitName);

            // Validation for quanity.
            if (quantity != Math.Floor(quantity) && unit.Id == 1)
            {
                throw new ArgumentException("Quantity must be a whole number.");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be positive.");
            }

            Category category;
            Supplier supplier;
            try
            {
                category = this.eazyCartContext.Categories.First(x => x.Name == categoryName);
                supplier = this.eazyCartContext.Suppliers.First(x => x.Name == supplierName);
            }
            catch
            {
                throw new ArgumentException("Invalid category/supplier information.");
            }

            var product = new Product
            {
                Code = productCode,
                Barcode = productBarcode,
                CategoryId = category.Id,
                Name = productName,
                Quantity = quantity,
                SupplierId = supplier.Id,
                DeliveryPrice = deliveryPrice,
                SellingPrice = sellingPrice,
                UnitId = unit.Id
            };

            var allProductsWithGivenId = this.eazyCartContext.Products.Where(x => x.Code == productCode);
            if (allProductsWithGivenId.Count() > 0)
            {
                throw new ArgumentException($"Product with code {productCode} already exists.");
            }

            this.eazyCartContext.Products.Add(product);
            this.eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Update a certain product by providing information about
        /// each of product's fields.
        /// </summary>
        /// <param name="productCode">Give the product's code to update.</param>
        /// <param name="productBarcode">Give the product's barcode to update.</param>
        /// <param name="categoryName">Give the product's category to update.</param>
        /// <param name="productName">Give the product's name to update.</param>
        /// <param name="quantity">Give the product's quantity to update.</param>
        /// <param name="supplierName">Give the product's supplier name to update.</param>
        /// <param name="deliveryPrice">Give the product's delivery price to update.</param>
        /// <param name="sellingPrice">Give the product's selling price to update.</param>
        /// <param name="unitName">Give the product's unit name to update.</param>
        public void Update(string productCode, string productBarcode, string categoryName, string productName, 
                decimal quantity, string supplierName, decimal deliveryPrice, decimal sellingPrice, string unitName)
        {
            var unit = this.eazyCartContext.Units.FirstOrDefault(x => x.Name == unitName);

            // Validation for quanity.
            if (quantity != Math.Floor(quantity) && unit.Id == 1)
            {
                throw new ArgumentException("Quantity must be a whole number.");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be positive.");
            }

            Category category;
            Supplier supplier;
            try
            {
                category = this.eazyCartContext.Categories.First(x => x.Name == categoryName);
                supplier = this.eazyCartContext.Suppliers.First(x => x.Name == supplierName);
            }
            catch
            {
                throw new ArgumentException("Invalid information about category/supplier.");
            }

            var productToUpdate = this.eazyCartContext.Products.FirstOrDefault(x => x.Code == productCode);
            productToUpdate.Barcode = productBarcode;
            productToUpdate.CategoryId = category.Id;
            productToUpdate.Name = productName;
            productToUpdate.Quantity = quantity;
            productToUpdate.SupplierId = supplier.Id;
            productToUpdate.DeliveryPrice = deliveryPrice;
            productToUpdate.SellingPrice = sellingPrice;
            productToUpdate.UnitId = unit.Id;

            eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Make a delivery for a certain product.
        /// </summary>
        /// <param name="productName">Give the name of the product.</param>
        /// <param name="quantity">Give the quantity from the wanted product.</param>
        public decimal MakeDelivery(string productName, decimal quantity)
        {
            Product productToUpdate;
            productToUpdate = this.eazyCartContext.Products.FirstOrDefault(x => x.Name == productName);

            if (productToUpdate == null)
            {
                throw new ArgumentException("Such product does not exist!");
            }

            // Validation for quanity.
            if (quantity != Math.Floor(quantity) && productToUpdate.UnitId == 1)
            {
                throw new ArgumentException("Quantity must be a whole number.");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be positive.");
            }

            productToUpdate.Quantity += quantity;

            this.eazyCartContext.SaveChanges();
            var totalToPayForDelivery = productToUpdate.DeliveryPrice * quantity;
            return totalToPayForDelivery;
        }

        /// <summary>
        /// Delete a certain product.
        /// </summary>
        /// <param name="productCode">Give the code of the product to delete.</param>
        public void Delete(string productCode)
        {
            var product = this.eazyCartContext.Products.First(x => x.Code == productCode);
            if (product != null)
            {
                var productReceipts = this.eazyCartContext
                                            .ProductsReceipts.Where(x => x.ProductCode == product.Code);

                // Remove the chosen product and its related productReceipts and save the changes in the context.
                this.eazyCartContext.ProductsReceipts.RemoveRange(productReceipts);
                this.eazyCartContext.Products.Remove(product);
                this.eazyCartContext.SaveChanges();
            }
        }
    }
}
