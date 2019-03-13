﻿using Data.Models;
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
