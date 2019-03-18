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
                var allCountriesNames = new List<string>();
                allCountriesNames.Add("Country");
                allCountriesNames.AddRange(countries.Select(x => x.Name).ToList());
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

        public void Add(Country country)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Countries.Add(country);
                eazyCartContext.SaveChanges();
            }
        }

        public void Update(Country country)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var countryToUpdate = eazyCartContext.Countries.Find(country.Id);
                if (countryToUpdate != null)
                {
                    eazyCartContext.Entry(countryToUpdate).CurrentValues.SetValues(country);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var country = eazyCartContext.Countries.Find(id);
                if (country != null)
                {
                    eazyCartContext.Countries.Remove(country);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
