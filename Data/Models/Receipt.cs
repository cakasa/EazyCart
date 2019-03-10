using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Receipt
    {
        public Receipt()
        {
            Productsreceipts = new HashSet<ProductReceipt>();
        }

        public int Id { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        public decimal GrandTotal { get; set; }

        public virtual ICollection<ProductReceipt> Productsreceipts { get; set; }
    }
}
