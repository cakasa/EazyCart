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

        public void Update(string cityName, int cityId, string countryName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var country = eazyCartContext.Countries.First(x => x.Name == countryName);
                var newCity = new City()
                {
                    Id = cityId,
                    Name = cityName,
                    CountryId = country.Id
                };

                var cityToUpdate = eazyCartContext.Cities.Find(cityId);
                eazyCartContext.Entry(cityToUpdate).CurrentValues.SetValues(newCity);
                eazyCartContext.SaveChanges();
            }
        }

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

                eazyCartContext.Cities.Remove(city);
                eazyCartContext.SaveChanges();
            }
        }

        public List<City> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Cities.ToList();
            }
        }

        public City Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Cities.Find(id);
            }
        }

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

        public void Add(City city)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Cities.Add(city);
                eazyCartContext.SaveChanges();
            }
        }




        public City GetByCountryAndName(Country country, string city)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return this.GetAll().First(x => x.Name == city && x.CountryId == country.Id);
            }
        }

        public List<Supplier> GetSuppliers(City selectedCity)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return selectedCity.Suppliers.ToList();
            }
        }

        public void AddSupplierToCity(City selectedCity, Supplier supplier)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                selectedCity.Suppliers.Add(supplier);
            }
        }

        public string GetNameBySupplier(string supplierName)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var supplier = eazyCartContext.Suppliers.First(x => x.Name == supplierName);
                var city = eazyCartContext.Cities.First(x => x.Id == supplier.CityId);
                return city.Name;
            }
        }
    }
}
