using Data.Models;
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

        public void Update(Receipt receipt)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var receiptToUpdate = eazyCartContext.Receipts.Find(receipt.Id);
                if (receiptToUpdate != null)
                {
                    eazyCartContext.Entry(receiptToUpdate).CurrentValues.SetValues(receipt);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var receipt = eazyCartContext.Receipts.Find(id);
                if (receipt != null)
                {
                    eazyCartContext.Receipts.Remove(receipt);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
