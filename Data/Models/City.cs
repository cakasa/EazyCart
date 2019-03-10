using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class City
    {
        public City()
        {
            Providers = new HashSet<Provider>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
    }
}
