using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SupplierBusiness
    {
        private EazyCartContext eazyCartContext;

        public List<Supplier> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Suppliers.ToList();
            }
        }

        public List<string> GetAllNames()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Supplier> suppliers = eazyCartContext.Suppliers.ToList();
                var supplierNames = new List<string>();
                supplierNames.Add("Supplier Name");

                foreach (var supplier in suppliers)
                {
                    supplierNames.Add(supplier.Name);
                }

                return supplierNames;
            }
        }

        public Supplier Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Suppliers.Find(id);
            }
        }

        public void Add(Supplier supplier)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Suppliers.Add(supplier);
                eazyCartContext.SaveChanges();
            }
        }

        public void Update(Supplier supplier)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var supplierToUpdate = eazyCartContext.Suppliers.Find(supplier.Id);
                if (supplierToUpdate != null)
                {
                    eazyCartContext.Entry(supplierToUpdate).CurrentValues.SetValues(supplier);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var supplier = eazyCartContext.Suppliers.Find(id);
                if (supplier != null)
                {
                    eazyCartContext.Suppliers.Remove(supplier);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
