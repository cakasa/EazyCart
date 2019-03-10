using System;
using System.Collections.Generic;

namespace EazyCart.Models
{
    public partial class Providers
    {
        public Providers()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
