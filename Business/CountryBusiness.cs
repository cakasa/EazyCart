using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// This business logic class is responsible for managing the
    /// countries from the database.
    /// </summary>
    public class CountryBusiness
    {
        private EazyCartContext eazyCartContext;

        /// <summary>
        /// Get all countries.
        /// </summary>
        /// <returns>A List of all countries.</returns>
        public List<Country> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Countries.ToList();
            }
        }

        /// <summary>
        /// Return a certain country by a given Id.
        /// </summary>
        /// <param name="id">The Id of the country.</param>
        /// <returns>JA country, corresponding to the given Id.</returns>
        public Country Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Countries.Find(id);
            }
        }

        /// <summary>
        /// Get a list containing all countries' names.
        /// </summary>
        /// <returns>A List of type string containing all country names.</returns>
        public List<string> GetAllNames()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var countries = eazyCartContext.Countries.ToList();
                var allCountriesNames = countries.Select(x => x.Name).ToList();
                return allCountriesNames;
            }
        }

        /// <summary>
        /// Get the country name a supplier is situated in.
        /// </summary>
        /// <param name="supplierName">Name of the supplier.</param>
        /// <returns>Name of the country, the supplier is located in.</returns>
        public string GetNameBySupplier(string supplierName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var supplier = eazyCartContext.Suppliers.First(x => x.Name == supplierName);
                var city = eazyCartContext.Cities.First(x => x.Id == supplier.CityId);
                var country = eazyCartContext.Countries.First(x => x.Id == city.CountryId);
                return country.Name;
            }
        }     

        /// <summary>
        /// Add a new country by given paramters.
        /// </summary>
        /// <param name="countryName">Name of the country to add.</param>
        /// <param name="countryId">Id of the country to add.</param>
        public void Add(string countryName, int countryId)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var country = new Country
                {
                    Id = countryId,
                    Name = countryName
                };

                eazyCartContext.Countries.Add(country);

                try
                {
                    eazyCartContext.SaveChanges();
                }
                catch
                {
                    throw new ArgumentException($"Country with ID {countryId} already exists.");
                }
            }
        }

        /// <summary>
        /// Update a certain country's fields.
        /// </summary>
        /// <param name="countryName">The new name of the country</param>
        /// <param name="countryId">The Id of the country to update.</param>
        public void Update(string countryName, int countryId)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                //  Update the country's fields.
                var newCountry = new Country()
                {
                    Id = countryId,
                    Name = countryName
                };

                var countryToUpdate = eazyCartContext.Countries.Find(countryId);

                // Set the updated county's fields.
                eazyCartContext.Entry(countryToUpdate).CurrentValues.SetValues(newCountry);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a certain country by a given Id.
        /// </summary>
        /// <param name="id">Id of the country to delete.</param>
        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var country = eazyCartContext.Countries.Find(id);
                var citiesFromCountry = 
                    eazyCartContext.Cities.Where(x => x.CountryId == country.Id).ToList();

                if (citiesFromCountry.Count > 0)
                {
                    throw new ArgumentException("One or more cities are related to this country.");
                }

                // Remove the chosen country and save the changes in the context.
                eazyCartContext.Countries.Remove(country);
                eazyCartContext.SaveChanges();
            }
        }
    }
}
