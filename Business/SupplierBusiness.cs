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

        /// <summary>
        /// Return all suppliers.
        /// </summary>
        /// <returns></returns>
        public List<Supplier> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Suppliers.ToList();
            }
        }

        /// <summary>
        /// Return a certain supplier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Supplier Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Suppliers.Find(id);
            }
        }

        /// <summary>
        /// Return a list containing all suppliers' names.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Add a new supplier.
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="supplierId"></param>
        /// <param name="supplierCityName"></param>
        /// <param name="supplierCountryName"></param>
        public void Add(string supplierName, int supplierId, string supplierCityName, string supplierCountryName)
        {
            using (eazyCartContext = new EazyCartContext())
            {              
                List<City> allCitiesWithGivenName = eazyCartContext
                                                        .Cities
                                                        .Where(x => x.Name == supplierCityName)
                                                        .ToList();

                // Find the city and the country of the new supplier.
                var country = eazyCartContext.Countries.First(x => x.Name == supplierCountryName);
                var city = allCitiesWithGivenName.First(x => x.CountryId == country.Id);

                // Initialize the new supplier's fields.
                var supplier = new Supplier
                {
                    Id = supplierId,
                    Name = supplierName,
                    CityId = city.Id
                };

                eazyCartContext.Suppliers.Add(supplier);

                // Chech whether a supplier with the given ID already exists.
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

        /// <summary>
        /// Update certain supplier's fields.
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="supplierId"></param>
        /// <param name="countryName"></param>
        /// <param name="cityName"></param>
        public void Update(string supplierName, int supplierId, string countryName, string cityName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<City> allCitiesWithGivenName = eazyCartContext
                                                        .Cities
                                                        .Where(x => x.Name == cityName)
                                                        .ToList();

                // Find the city and the country of the selected supplier.
                var country = eazyCartContext.Countries.First(x => x.Name == countryName);
                var city = allCitiesWithGivenName.First(x => x.CountryId == country.Id);

                // Update the supplier's fields.
                var newSupplier = new Supplier()
                {
                    Id = supplierId,
                    Name = supplierName,
                    CityId = city.Id
                };

                var supplierToUpdate = eazyCartContext.Suppliers.Find(supplierId);

                // Set the updated supplier's fields.
                eazyCartContext.Entry(supplierToUpdate).CurrentValues.SetValues(newSupplier);
                eazyCartContext.SaveChanges();
            }
        }    

        /// <summary>
        /// Delete a certain supplier.
        /// </summary>
        /// <param name="id"></param>
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

                // Remove the chosen supplier and save the changes in the context.
                eazyCartContext.Suppliers.Remove(supplier);
                eazyCartContext.SaveChanges();
            }
        }
    }
}
