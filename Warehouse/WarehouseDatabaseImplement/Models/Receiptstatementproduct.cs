using System;
using System.Collections.Generic;

namespace WarehouseDatabaseImplement.Models
{
    public partial class Receiptstatementproduct
    {
        public int ReceiptstatementId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual Receiptstatement Receiptstatement { get; set; }
    }
}
