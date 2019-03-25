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

        public void Update(string countryName, int countryId)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var newCountry = new Country()
                {
                    Id = countryId,
                    Name = countryName
                };

                var countryToUpdate = eazyCartContext.Countries.Find(countryId);
                eazyCartContext.Entry(countryToUpdate).CurrentValues.SetValues(newCountry);
                eazyCartContext.SaveChanges();
            }
        }

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

                eazyCartContext.Countries.Remove(country);
                eazyCartContext.SaveChanges();
            }
        }


        public List<Country> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Countries.ToList();
            }
        }

        public List<string> GetAllNames()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                List<Country> countries = eazyCartContext.Countries.ToList();
                var allCountriesNames = countries.Select(x => x.Name).ToList();
                return allCountriesNames;
            }
        }

        public List<City> GetCities(int countryId)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Countries.Find(countryId).Cities.ToList();
            }


        }

        public void AddCityToCountry(int countryId, City city)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Countries.Find(countryId).Cities.Add(city);
                eazyCartContext.SaveChanges();
            }
        }

        public Country GetByName(string name)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var country = eazyCartContext.Countries.First(x=>x.Name == name);
                return country;
            }
        }

        public Country Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Countries.Find(id);
            }
        }

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
    }
}
