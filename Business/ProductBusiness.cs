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
    }
}
