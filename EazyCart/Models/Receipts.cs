using System;
using System.Collections.Generic;

namespace EazyCart.Models
{
    public partial class Receipts
    {
        public Receipts()
        {
            Productsreceipts = new HashSet<Productsreceipts>();
        }

        public int Id { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        public decimal GrandTotal { get; set; }

        public virtual ICollection<Productsreceipts> Productsreceipts { get; set; }
    }
}
