using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class City
    {
        public City()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
