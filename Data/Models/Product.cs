using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductsReceipts = new HashSet<ProductReceipt>();
        }

        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public int UnitId { get; set; }
        public int CategoryId { get; set; }
        public decimal Quantity { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal SellingPrice { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<ProductReceipt> ProductsReceipts { get; set; }
    }
}
