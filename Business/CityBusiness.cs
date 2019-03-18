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
                cityNames.Add("City");
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

        public void Update(City city)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var cityToUpdate = eazyCartContext.Cities.Find(city.Id);
                if (cityToUpdate != null)
                {
                    eazyCartContext.Entry(cityToUpdate).CurrentValues.SetValues(city);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var city = eazyCartContext.Cities.Find(id);
                if (city != null)
                {
                    eazyCartContext.Cities.Remove(city);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public City GetByCountryAndName(Country selectedCountry, string selectedCityString)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return selectedCountry.Cities.First(x => x.Name == selectedCityString);
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
    }
}
