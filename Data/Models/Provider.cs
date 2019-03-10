using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
