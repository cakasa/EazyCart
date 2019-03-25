﻿using Data.Models;
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
                allProductNames.Add("Product Name");
                allProductNames.AddRange(allProducts.Select(x => x.Name).ToList());
                return allProductNames;
            }
        }

        public Product Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Products.Find(id);
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

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var product = eazyCartContext.Products.Find(id);
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
    }
}
