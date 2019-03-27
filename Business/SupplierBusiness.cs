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

        public void Add(string supplierName, int supplierId, string supplierCityName, string supplierCountryName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<City> allCitiesWithGivenName = eazyCartContext
                                                        .Cities
                                                        .Where(x => x.Name == supplierCityName)
                                                        .ToList();

                var country = eazyCartContext.Countries.First(x => x.Name == supplierCountryName);
                var city = allCitiesWithGivenName.First(x => x.CountryId == country.Id);

                var supplier = new Supplier
                {
                    Id = supplierId,
                    Name = supplierName,
                    CityId = city.Id
                };

                eazyCartContext.Suppliers.Add(supplier);
                try
                {
                    eazyCartContext.SaveChanges();
                }
                catch
                {
                    throw new ArgumentException($"Supplier with ID {supplierId} already exists.");
                }
            }
        }

        public void Update(string supplierName, int supplierId, string countryName, string cityName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<City> allCitiesWithGivenName = eazyCartContext
                                                        .Cities
                                                        .Where(x => x.Name == cityName)
                                                        .ToList();

                var country = eazyCartContext.Countries.First(x => x.Name == countryName);
                var city = allCitiesWithGivenName.First(x => x.CountryId == country.Id);

                var newSupplier = new Supplier()
                {
                    Id = supplierId,
                    Name = supplierName,
                    CityId = city.Id
                };

                var supplierToUpdate = eazyCartContext.Suppliers.Find(supplierId);
                eazyCartContext.Entry(supplierToUpdate).CurrentValues.SetValues(newSupplier);
                eazyCartContext.SaveChanges();
            }
        }

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

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var supplier = eazyCartContext.Suppliers.Find(id);

                List<Product> productsFromSupplier = eazyCartContext.Products.Where(x => x.SupplierId == supplier.Id).ToList();
                if (productsFromSupplier.Count > 0)
                {
                    throw new ArgumentException("One or more products are related to this supplier.");
                }

                eazyCartContext.Suppliers.Remove(supplier);
                eazyCartContext.SaveChanges();
            }
        }
    }
}
