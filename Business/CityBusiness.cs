using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CityBusiness
    {
        private EazyCartContext eazyCartContext;

        /// <summary>
        /// Return all cities.
        /// </summary>
        /// <returns></returns>
        public List<City> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Cities.ToList();
            }
        }

        /// <summary>
        /// Return a certain city.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public City Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Cities.Find(id);
            }
        }

        /// <summary>
        /// Return a list containing all cities' names.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllNames()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<City> cities = eazyCartContext.Cities.ToList();
                var cityNames = new List<string>();
                cityNames.AddRange(cities.Select(x => x.Name).ToList());
                return cityNames;
            }
        }

        /// <summary>
        /// Return a list containing all cities' names from a wanted country.
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public List<string> GetAllCityNamesFromCountry(string countryName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var allCities = eazyCartContext.Cities;
                var country = eazyCartContext.Countries.First(x => x.Name == countryName);
                var countryCities = allCities.Where(x => x.CountryId == country.Id);
                var countryCitiesNames = countryCities.Select(x => x.Name).ToList();

                return countryCitiesNames;
            }
        }

        /// <summary>
        /// Return a city using a supplier's name
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public string GetNameBySupplier(string supplierName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var supplier = eazyCartContext.Suppliers.First(x => x.Name == supplierName);
                var city = eazyCartContext.Cities.First(x => x.Id == supplier.CityId);
                return city.Name;
            }
        }

        /// <summary>
        /// Return a city using two parameters from Country type and string cityName.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public City GetByCountryAndName(Country country, string city)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return this.GetAll().First(x => x.Name == city && x.CountryId == country.Id);
            }
        }

        /// <summary>
        /// Return all suppliers from a certain city.
        /// </summary>
        /// <param name="selectedCity"></param>
        /// <returns></returns>
        public List<Supplier> GetSuppliers(City selectedCity)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return selectedCity.Suppliers.ToList();
            }
        }

        /// <summary>
        /// Add a new city.
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="cityId"></param>
        /// <param name="cityCountry"></param>
        public void Add(string cityName, int cityId, string cityCountry)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var country = eazyCartContext.Countries.First(x => x.Name == cityCountry);
                City city = new City
                {
                    Id = cityId,
                    Name = cityName,
                    CountryId = country.Id
                };

                eazyCartContext.Cities.Add(city);
                try
                {
                    eazyCartContext.SaveChanges();
                }
                catch
                {
                    throw new ArgumentException($"City with ID {cityId} already exists.");
                }
            }
        }

        /// <summary>
        /// Add a new city with an object from City type. 
        /// </summary>
        /// <param name="city"></param>
        public void Add(City city)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Cities.Add(city);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Add a new a supplier from a certain city.
        /// </summary>
        /// <param name="selectedCity"></param>
        /// <param name="supplier"></param>
        public void AddSupplierToCity(City selectedCity, Supplier supplier)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                selectedCity.Suppliers.Add(supplier);
            }
        }

        /// <summary>
        /// Update certain city's fields.
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="cityId"></param>
        /// <param name="countryName"></param>
        public void Update(string cityName, int cityId, string countryName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var country = eazyCartContext.Countries.First(x => x.Name == countryName);

                // Update the city's fields.
                var newCity = new City()
                {
                    Id = cityId,
                    Name = cityName,
                    CountryId = country.Id
                };

                var cityToUpdate = eazyCartContext.Cities.Find(cityId);

                // Set the updated city's fields.
                eazyCartContext.Entry(cityToUpdate).CurrentValues.SetValues(newCity);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a certain city.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var city = eazyCartContext.Cities.Find(id);

                List<Supplier> supplierFromCity = eazyCartContext.Suppliers.Where(x => x.CityId == city.Id).ToList();
                if (supplierFromCity.Count > 0)
                {
                    throw new ArgumentException("One or more suppliers are related to this city.");
                }

                // Remove the chosen city and save the changes in the context.
                eazyCartContext.Cities.Remove(city);
                eazyCartContext.SaveChanges();
            }
        }
    }
}
