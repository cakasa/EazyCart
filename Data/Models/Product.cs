using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Product
    {
        public Product()
        {
            Productsreceipts = new HashSet<ProductReceipt>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public int CategoryId { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal SellingPrice { get; set; }

        public virtual Category Category { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<ProductReceipt> Productsreceipts { get; set; }
    }
}
