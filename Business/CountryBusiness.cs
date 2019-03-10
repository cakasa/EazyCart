using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CountryBusiness
    {
        private EazyCartContext eazyCartContext;

        public List<Country> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Countries.ToList();
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
                var item = eazyCartContext.Products.Find(product.Id);
                if (item != null)
                {
                    eazyCartContext.Entry(item).CurrentValues.SetValues(product);
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
