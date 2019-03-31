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

        /// <summary>
        /// Return all unit types.
        /// </summary>
        /// <returns></returns>
        public List<Unit> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Units.ToList();
            }
        }

        /// <summary>
        /// Return a certain unit type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Unit Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Units.Find(id);
            }
        }

        /// <summary>
        /// Add a new unit type.
        /// </summary>
        /// <param name="unit"></param>
        public void Add(Unit unit)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Units.Add(unit);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Update certain unit's fields.
        /// </summary>
        /// <param name="unit"></param>
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

        /// <summary>
        /// Delete a certain unit type.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var unit = eazyCartContext.Units.Find(id);
                if (unit != null)
                {
                    // Remove the chosen unit and save the changes in the context.
                    eazyCartContext.Units.Remove(unit);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
