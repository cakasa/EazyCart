using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProviderBusiness
    {
        private EazyCartContext eazyCartContext;

        public List<Provider> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Providers.ToList();
            }
        }

        public Provider Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Providers.Find(id);
            }
        }

        public void Add(Provider provider)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Providers.Add(provider);
                eazyCartContext.SaveChanges();
            }
        }

        public void Update(Provider provider)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var providerToUpdate = eazyCartContext.Providers.Find(provider.Id);
                if (providerToUpdate != null)
                {
                    eazyCartContext.Entry(providerToUpdate).CurrentValues.SetValues(provider);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var provider = eazyCartContext.Providers.Find(id);
                if (provider != null)
                {
                    eazyCartContext.Providers.Remove(provider);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
