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
            return eazyCartContext.Products.ToList();
        }

        /// <summary>
        /// Get all products' names.
        /// </summary>
        /// <returns>List of all products' names.</returns>
        public List<string> GetAllNames()
        {
            List<Product> allProducts = eazyCartContext.Products.ToList();
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
            return eazyCartContext.Products.First(x => x.Code == code);
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
            var allProducts = eazyCartContext.Products.ToList();
            var allCategories = eazyCartContext.Categories.ToList();
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
            var allProducts = eazyCartContext.Products.ToList();
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
            var allProducts = eazyCartContext.Products.ToList();
            var allCountries = eazyCartContext.Countries.ToList();
            foreach (var country in allCountries)
            {
                productCountByCountry.Add(country.Name, 0);
            }

            foreach (var product in allProducts)
            {
                var supplier = eazyCartContext.Suppliers.FirstOrDefault(x => x.Id == product.SupplierId);
                var city = eazyCartContext.Cities.FirstOrDefault(x => x.Id == supplier.CityId);
                var country = eazyCartContext.Countries.FirstOrDefault(x => x.Id == city.CountryId);
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
            var allProducts = eazyCartContext.Products.ToList();
            var allSuppliers = eazyCartContext.Suppliers.ToList();
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
            var allProducts = eazyCartContext.Products.ToList();
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
        public List<Product> GetAllByCategoryAndNameOrId(string categoryString, string searchPhrase)
        {
            var category = eazyCartContext.Categories.First(x => x.Name == categoryString);
            var products = eazyCartContext
                                .Products
                                .Where(x => x.CategoryId == category.Id && (x.Name.ToUpper().Contains(searchPhrase.ToUpper()) || x.Code.ToUpper().Contains(searchPhrase.ToUpper())))
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
            var category = eazyCartContext.Categories.First(x => x.Name == categoryString);
            var products = eazyCartContext.Products.Where(x => x.CategoryId == category.Id).ToList();

            return products;
        }

        /// <summary>
        /// Get all products that match a typed search phrase.
        /// </summary>
        /// <param name="searchPhrase">Give the searched string.</param>
        /// <returns>Return a list of the products that suit the given condition.</returns>
        public List<Product> GetAllByNameOrId(string searchPhrase)
        {
            var products = eazyCartContext.Products.Where(x => x.Name.ToUpper().Contains(searchPhrase.ToUpper()) || x.Code.ToUpper().Contains(searchPhrase.ToUpper())).ToList();

            return products;

        }

        /// <summary>
        /// Add a certain product by providing information about
        /// each of product's fields.
        /// </summary>
        /// <param name="productCode">Give the product's code to add.</param>
        /// <param name="categoryName">Give the product's category to add.</param>
        /// <param name="productName">Give the product's name to add.</param>
        /// <param name="quantity">Give the product's quantity to add.</param>
        /// <param name="supplierName">Give the product's supplier name to add.</param>
        /// <param name="deliveryPrice">Give the product's delivery price to add.</param>
        /// <param name="sellingPrice">Give the product's selling price to add.</param>
        /// <param name="unitName">Give the product's unit name to add.</param>
        public void Add(string productCode, string categoryName, string productName, decimal quantity, string supplierName,
            decimal deliveryPrice, decimal sellingPrice, string unitName)
        {
            Category category;
            Supplier supplier;
            try
            {
                category = eazyCartContext.Categories.First(x => x.Name == categoryName);
                supplier = eazyCartContext.Suppliers.First(x => x.Name == supplierName);
            }
            catch
            {
                throw new ArgumentException("Invalid category/supplier information.");
            }

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

        /// <summary>
        /// Update a certain product by providing information about
        /// each of product's fields.
        /// </summary>
        /// <param name="productCode">Give the product's code to upgrade.</param>
        /// <param name="categoryName">Give the product's category to upgrade.</param>
        /// <param name="productName">Give the product's name to upgrade.</param>
        /// <param name="quantity">Give the product's quantity to upgrade.</param>
        /// <param name="supplierName">Give the product's supplier name to upgrade.</param>
        /// <param name="deliveryPrice">Give the product's delivery price to upgrade.</param>
        /// <param name="sellingPrice">Give the product's selling price to upgrade.</param>
        /// <param name="unitName">Give the product's unit name to upgrade.</param>
        public void Update(string productCode, string categoryName, string productName, decimal quantity,
            string supplierName, decimal deliveryPrice, decimal sellingPrice, string unitName)
        {
            Category category;
            Supplier supplier;
            try
            {
                category = eazyCartContext.Categories.First(x => x.Name == categoryName);
                supplier = eazyCartContext.Suppliers.First(x => x.Name == supplierName);
            }
            catch
            {
                throw new ArgumentException("Invalid information about category/supplier.");
            }
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

        /// <summary>
        /// Make a delivery for a certain product.
        /// </summary>
        /// <param name="productName">Give the name of the product.</param>
        /// <param name="quantity">Give the quantity from the wanted product.</param>
        public void MakeDelivery(string productName, decimal quantity)
        {
            var product = eazyCartContext.Products.First(x => x.Name == productName);

            // Validation for quanity.
            if (quantity != Math.Floor(quantity) && product.UnitId == 1)
            {
                throw new ArgumentException("Quantity must be a whole number.");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be positive.");
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

        /// <summary>
        /// Delete a certain product.
        /// </summary>
        /// <param name="productCode">Give the code of the product to delete.</param>
        public void Delete(string productCode)
        {
            var product = eazyCartContext.Products.First(x => x.Code == productCode);
            if (product != null)
            {

                // Remove the chosen product and save the changes in the context.
                eazyCartContext.Products.Remove(product);
                eazyCartContext.SaveChanges();
            }
        }
    }
}
