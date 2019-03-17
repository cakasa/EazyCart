using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UnitBusiness
    {
        private EazyCartContext eazyCartContext;

        public List<Unit> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Units.ToList();
            }
        }

        public Unit Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Units.Find(id);
            }
        }

        public void Add(Unit unit)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Units.Add(unit);
                eazyCartContext.SaveChanges();
            }
        }

        public void Update(Unit unit)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var unitToUpdate = eazyCartContext.Units.Find(unit.Id);
                if (unitToUpdate != null)
                {
                    eazyCartContext.Entry(unitToUpdate).CurrentValues.SetValues(unit);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var unit = eazyCartContext.Units.Find(id);
                if (unit != null)
                {
                    eazyCartContext.Units.Remove(unit);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
