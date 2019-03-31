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

        /// <summary>
        /// Return all countries.
        /// </summary>
        /// <returns></returns>
        public List<Country> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Countries.ToList();
            }
        }

        /// <summary>
        /// Return a certain country.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Countries.Find(id);
            }
        }

        /// <summary>
        /// Return a list containing all countries' names.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllNames()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Country> countries = eazyCartContext.Countries.ToList();
                var allCountriesNames = countries.Select(x => x.Name).ToList();
                return allCountriesNames;
            }
        }

        /// <summary>
        /// Return a country by a given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Country GetByName(string name)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var country = eazyCartContext.Countries.First(x => x.Name == name);
                return country;
            }
        }

        /// <summary>
        /// Return country's name by a given supplierName
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
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
        /// Return the cities from a certain country.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public List<City> GetCities(int countryId)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Countries.Find(countryId).Cities.ToList();
            }
        }

        /// <summary>
        /// Add a new country.
        /// </summary>
        /// <param name="countryName"></param>
        /// <param name="countryId"></param>
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
        /// Add a city to a certain country.
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="city"></param>
        public void AddCityToCountry(int countryId, City city)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Countries.Find(countryId).Cities.Add(city);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Update certain country's fields.
        /// </summary>
        /// <param name="countryName"></param>
        /// <param name="countryId"></param>
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
        /// Delete a certain country.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var country = eazyCartContext.Countries.Find(id);
                List<City> citiesFromCountry = eazyCartContext.Cities.Where(x => x.CountryId == country.Id).ToList();
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
