using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Controllers
{
    /// <summary>
    /// This business logic class is responsible for managing the
    /// suppliers from the database
    /// </summary>
    public class SupplierBusiness
    {
        private EazyCartContext eazyCartContext;

        public SupplierBusiness(EazyCartContext eazyCartContext)
        {
            this.eazyCartContext = eazyCartContext;
        }

        /// <summary>
        /// Get all suppliers.
        /// </summary>
        /// <returns>A List of all suppliers.</returns>
        public List<Supplier> GetAll()
        {
            return this.eazyCartContext.Suppliers.ToList();
        }

        /// <summary>
        /// Return a supplier by given Id.
        /// </summary>
        /// <param name="id">Id of the supplier</param>
        /// <returns>Supplier, corresponding to the given Id.</returns>
        public Supplier Get(int id)
        {
            return this.eazyCartContext.Suppliers.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get suppliers' names.
        /// </summary>
        /// <returns>A List of strings, containing supplier names.</returns>
        public List<string> GetAllNames()
        {
            List<Supplier> suppliers = this.eazyCartContext.Suppliers.ToList();
            var supplierNames = new List<string>();

            foreach (var supplier in suppliers)
            {
                supplierNames.Add(supplier.Name);
            }

            return supplierNames;
        }

        /// <summary>
        /// Add a new supplier by given parameters.
        /// </summary>
        /// <param name="supplierName">The name of the supplier.</param>
        /// <param name="supplierId">The Id of the supplier.</param>
        /// <param name="supplierCityName">The city name of the supplier.</param>
        /// <param name="supplierCountryName">The country name of the supplier.</param>
        public void Add(string supplierName, int supplierId, string supplierCityName, string supplierCountryName)
        {
            List<City> allCitiesWithGivenName = this.eazyCartContext
                                                       .Cities
                                                       .Where(x => x.Name == supplierCityName)
                                                       .ToList();

            // Find the city and the country of the new supplier.
            Country country;
            City city;
            try
            {
                country = this.eazyCartContext.Countries.First(x => x.Name == supplierCountryName);
                city = allCitiesWithGivenName.First(x => x.CountryId == country.Id);
            }
            catch
            {
                throw new ArgumentException("No such country/city exists");
            }

            // Initialize the new supplier's fields.
            var supplier = new Supplier
            {
                Id = supplierId,
                Name = supplierName,
                CityId = city.Id
            };

            // Check whether a supplier with the given ID already exists.
            var allSuppliersWithGivenId = this.eazyCartContext.Suppliers.Where(x => x.Id == supplierId);
            if (allSuppliersWithGivenId.Count() > 0)
            {
                throw new ArgumentException($"Supplier with ID {supplierId} already exists.");
            }

            this.eazyCartContext.Suppliers.Add(supplier);
            this.eazyCartContext.SaveChanges();

        }

        /// <summary>
        /// Update certain supplier's fields.
        /// </summary>
        /// <param name="supplierName">The new name of the supplier.</param>
        /// <param name="supplierId">Id of supplier to update.</param>
        /// <param name="countryName">The new country name of the supplier.</param>
        /// <param name="cityName">The new city name of the supplier.</param>
        public void Update(string supplierName, int supplierId, string countryName, string cityName)
        {
            List<City> allCitiesWithGivenName = this.eazyCartContext
                                                       .Cities
                                                       .Where(x => x.Name == cityName)
                                                       .ToList();

            // Find the city and the country of the selected supplier.
            Country country;
            City city;
            try
            {
                country = this.eazyCartContext.Countries.First(x => x.Name == countryName);
                city = allCitiesWithGivenName.First(x => x.CountryId == country.Id);
            }
            catch
            {
                throw new ArgumentException("No such country/city exists.");
            }

            var supplierToUpdate = this.eazyCartContext
                                          .Suppliers.FirstOrDefault(x => x.Id == supplierId);
            supplierToUpdate.Name = supplierName;
            supplierToUpdate.CityId = city.Id;

            eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Delete a certain supplier by given id.
        /// </summary>
        /// <param name="id">The ID of the supplier.</param>
        public void Delete(int id)
        {
            var supplier = this.eazyCartContext.Suppliers.FirstOrDefault(x => x.Id == id);

            var productsFromSupplier = this.eazyCartContext
                                              .Products
                                              .Where(x => x.SupplierId == supplier.Id)
                                              .ToList();
            if (productsFromSupplier.Count > 0)
            {
                throw new ArgumentException("One or more products are related to this supplier.");
            }

            // Remove the chosen supplier and save the changes in the context.
            this.eazyCartContext.Suppliers.Remove(supplier);
            this.eazyCartContext.SaveChanges();
        }
    }
}
