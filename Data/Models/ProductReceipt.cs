using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class ProductReceipt
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int ReceiptId { get; set; }
        public decimal Quantity { get; set; }
        public int? DiscountPercentage { get; set; }

        public virtual Product ProductCodeNavigation { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
