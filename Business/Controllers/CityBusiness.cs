using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Controllers
{
    /// <summary>
    /// This business logic class is responsible for managing the
    /// cities from the database
    /// </summary>
    public class CityBusiness
    {
        private EazyCartContext eazyCartContext;

        public CityBusiness(EazyCartContext eazyCartContext)
        {
            this.eazyCartContext = eazyCartContext;
        }

        /// <summary>
        /// Get All Cities
        /// </summary>
        /// <returns> A List of all cities.</returns>
        public List<City> GetAll()
        {
            return this.eazyCartContext.Cities.ToList();
        }

        /// <summary>
        /// Get a city by its Id 
        /// </summary>
        /// <param name="id">Id of the city to return.</param>
        /// <returns>A city, corresponding to the given Id</returns>
        public City Get(int id)
        {
            return this.eazyCartContext.Cities.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get all cities' names.
        /// </summary>
        /// <returns>A List of string containing all names.</returns>
        public List<string> GetAllNames()
        {
            var cities = this.eazyCartContext.Cities.ToList();
            var cityNames = new List<string>();
            cityNames.AddRange(cities.Select(x => x.Name).ToList());
            return cityNames;
        }

        /// <summary>
        /// Return all cities' names from a given country name.
        /// </summary>
        /// <param name="countryName">The name of the country all cities are in.</param>
        /// <returns>A List of type string containing all city names, corresponding 
        /// to the country name.</returns>
        public List<string> GetAllCityNamesFromCountry(string countryName)
        {
            var allCities = this.eazyCartContext.Cities;
            var country = this.eazyCartContext.Countries.First(x => x.Name == countryName);
            var countryCities = allCities.Where(x => x.CountryId == country.Id);
            var countryCitiesNames = countryCities.Select(x => x.Name).ToList();

            return countryCitiesNames;
        }

        /// <summary>
        /// Get a city using a supplier's name.
        /// </summary>
        /// <param name="supplierName">Name of the supplier.</param>
        /// <returns>A string containing the name of the city the supplier is situated in.</returns>
        public string GetNameBySupplier(string supplierName)
        {
            var supplier = this.eazyCartContext.Suppliers.First(x => x.Name == supplierName);
            var city = this.eazyCartContext.Cities.First(x => x.Id == supplier.CityId);
            return city.Name;
        }

        /// <summary>
        /// Add a new city by given parameters.
        /// </summary>
        /// <param name="cityName">The name of the city to add.</param>
        /// <param name="cityId">The Id of the city to add.</param>
        /// <param name="cityCountryName">The name of the country the city is located in.</param>
        public void Add(string cityName, int cityId, string cityCountryName)
        {
            Country country;
            try
            {
                country = this.eazyCartContext.Countries.First(x => x.Name == cityCountryName);
            }
            catch
            {
                throw new ArgumentException("Such country does not exist.");
            }

            City city = new City
            {
                Id = cityId,
                Name = cityName,
                CountryId = country.Id
            };

            var allCitiesWithGivenId = this.eazyCartContext.Cities.Where(x => x.Id == cityId);
            if (allCitiesWithGivenId.Count() > 0)
            {
                throw new ArgumentException($"City with ID {cityId} already exists.");
            }

            this.eazyCartContext.Cities.Add(city);
            this.eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Update certain city's fields.
        /// </summary>
        /// <param name="cityName">The new name of the city.</param>
        /// <param name="cityId">The Id of the city to update.</param>
        /// <param name="countryName">The new country name of the city.</param>
        public void Update(string cityName, int cityId, string countryName)
        {
            Country country;
            try
            {
                country = this.eazyCartContext.Countries.First(x => x.Name == countryName);
            }
            catch
            {
                throw new ArgumentException("No such country exists.");
            }

            var cityToUpdate = this.eazyCartContext.Cities.FirstOrDefault(x => x.Id == cityId);
            cityToUpdate.Name = cityName;
            cityToUpdate.CountryId = country.Id;

            this.eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Delete a certain city by a given Id.
        /// </summary>
        /// <param name="id">Id of the city to delete.</param>
        public void Delete(int id)
        {
            var city = this.eazyCartContext.Cities.FirstOrDefault(x => x.Id == id);
            List<Supplier> supplierFromCity = this.eazyCartContext.Suppliers.Where(x => x.CityId == city.Id).ToList();

            if (supplierFromCity.Count > 0)
            {
                throw new ArgumentException("One or more suppliers are related to this city.");
            }

            // Remove the chosen city and save the changes in the context.
            this.eazyCartContext.Cities.Remove(city);
            this.eazyCartContext.SaveChanges();
        }
    }
}
