using System;
using System.Collections.Generic;

namespace EazyCart.Models
{
    public partial class Products
    {
        public Products()
        {
            Productsreceipts = new HashSet<Productsreceipts>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public int CategoryId { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal SellingPrice { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Providers Provider { get; set; }
        public virtual ICollection<Productsreceipts> Productsreceipts { get; set; }
    }
}
