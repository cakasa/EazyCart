using System;
using System.Collections.Generic;

namespace EazyCart.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Providers = new HashSet<Providers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Providers> Providers { get; set; }
    }
}
