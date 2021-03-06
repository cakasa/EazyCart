﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Controllers
{
    /// <summary>
    /// This business logic class is responsible for managing the
    /// countries from the database.
    /// </summary>
    public class CountryBusiness
    {
        private EazyCartContext eazyCartContext;

        public CountryBusiness(EazyCartContext eazyCartContext)
        {
            this.eazyCartContext = eazyCartContext;
        }

        /// <summary>
        /// Get all countries.
        /// </summary>
        /// <returns>A List of all countries.</returns>
        public List<Country> GetAll()
        {
            return this.eazyCartContext.Countries.ToList();
        }

        /// <summary>
        /// Return a certain country by a given Id.
        /// </summary>
        /// <param name="id">The Id of the country.</param>
        /// <returns>A country, corresponding to the given Id.</returns>
        public Country Get(int id)
        {
            return this.eazyCartContext.Countries.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get all countries' names.
        /// </summary>
        /// <returns>A List of type string containing all country names.</returns>
        public List<string> GetAllNames()
        {
            var countries = this.eazyCartContext.Countries.ToList();
            var allCountriesNames = countries.Select(x => x.Name).ToList();
            return allCountriesNames;
        }

        /// <summary>
        /// Get the country name a supplier is situated in.
        /// </summary>
        /// <param name="supplierName">Name of the supplier.</param>
        /// <returns>Name of the country, the supplier is located in.</returns>
        public string GetNameBySupplier(string supplierName)
        {
            var supplier = this.eazyCartContext.Suppliers.First(x => x.Name == supplierName);
            var city = this.eazyCartContext.Cities.First(x => x.Id == supplier.CityId);
            var country = this.eazyCartContext.Countries.First(x => x.Id == city.CountryId);
            return country.Name;
        }

        /// <summary>
        /// Add a new country by given paramters.
        /// </summary>
        /// <param name="countryName">Name of the country to add.</param>
        /// <param name="countryId">Id of the country to add.</param>
        public void Add(string countryName, int countryId)
        {
            var country = new Country
            {
                Id = countryId,
                Name = countryName
            };

            var countriesWithGivenId = this.eazyCartContext.Countries.Where(x => x.Id == countryId);
            if (countriesWithGivenId.Count() > 0)
            {
                throw new ArgumentException($"Country with ID {countryId} already exists.");
            }

            this.eazyCartContext.Countries.Add(country);
            this.eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Update a certain country's fields.
        /// </summary>
        /// <param name="countryName">The new name of the country</param>
        /// <param name="countryId">The Id of the country to update.</param>
        public void Update(string countryName, int countryId)
        {
            var countryToUpdate =
                this.eazyCartContext.Countries.FirstOrDefault(x => x.Id == countryId);
            countryToUpdate.Name = countryName;

            this.eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Delete a certain country by a given Id.
        /// </summary>
        /// <param name="id">Id of the country to delete.</param>
        public void Delete(int id)
        {
            var country = this.eazyCartContext.Countries.FirstOrDefault(x => x.Id == id);
            var citiesFromCountry =
                this.eazyCartContext.Cities.Where(x => x.CountryId == country.Id).ToList();

            if (citiesFromCountry.Count > 0)
            {
                throw new ArgumentException("One or more cities are related to this country.");
            }

            // Remove the chosen country and save the changes in the context.
            this.eazyCartContext.Countries.Remove(country);
            this.eazyCartContext.SaveChanges();
        }
    }
}
