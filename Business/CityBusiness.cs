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
    }
}
