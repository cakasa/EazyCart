using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Controllers
{
    /// <summary>
    /// This business logic class is responsible for managing the
    /// unit types from the database.
    /// </summary>
    public class UnitBusiness
    {
        private EazyCartContext eazyCartContext;

        public UnitBusiness(EazyCartContext eazyCartContext)
        {
            this.eazyCartContext = eazyCartContext;
        }

        /// <summary>
        /// Return a certain unit by a given ID.
        /// </summary>
        /// <param name="id">The Id of the unit.</param>
        /// <returns>Unit, corresponding to the ID.</returns>
        public Unit Get(int id)
        {
            return eazyCartContext.Units.FirstOrDefault(x=> x.Id == id);
        }

        /// <summary>
        /// Get the count of units, stored in the database.
        /// </summary>
        /// <returns>Number of units in the databases.</returns>
        public int GetNumberOfUnits()
        {
            return eazyCartContext.Units.Count();
        }

        /// <summary>
        /// Add a new unit type.
        /// </summary>
        /// <param name="unitId">The Id of the unit to add.</param>
        /// <param name="code">The name of the unit.</param>
        /// <param name="name">The code/abbreviation of the unit.</param>
        public void Add(int unitId, string name, string code)
        {
            var unit = new Unit
            {
                Id = unitId,
                Name = name,
                Code = code
            };

            eazyCartContext.Units.Add(unit);
            eazyCartContext.SaveChanges();
        }
    }
}
