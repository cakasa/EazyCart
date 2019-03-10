using System;
using System.Collections.Generic;

namespace EazyCart.Models
{
    public partial class Productsreceipts
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int ReceiptId { get; set; }
        public decimal Quantity { get; set; }
        public int? DiscountPercentage { get; set; }

        public virtual Products ProductCodeNavigation { get; set; }
        public virtual Receipts Receipt { get; set; }
    }
}
