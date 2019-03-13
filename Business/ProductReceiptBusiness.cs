using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductReceiptBusiness
    {
        private EazyCartContext eazyCartContext;

        public List<ProductReceipt> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Productsreceipts.ToList();
            }
        }

        public ProductReceipt Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Productsreceipts.Find(id);
            }
        }

        public void Add(ProductReceipt productReceipt)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Productsreceipts.Add(productReceipt);
                eazyCartContext.SaveChanges();
            }
        }

        public void Update(ProductReceipt productReceipt)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productReceiptToUpdate = eazyCartContext.Productsreceipts.Find(productReceipt.Id);
                if (productReceiptToUpdate != null)
                {
                    eazyCartContext.Entry(productReceiptToUpdate).CurrentValues.SetValues(productReceipt);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var productReceipt = eazyCartContext.Productsreceipts.Find(id);
                if (productReceipt != null)
                {
                    eazyCartContext.Productsreceipts.Remove(productReceipt);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
