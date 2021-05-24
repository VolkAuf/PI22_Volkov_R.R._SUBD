using System;
using System.Collections.Generic;

namespace WarehouseDatabaseImplement.Models
{
    public partial class Expensestatementproduct
    {
        public int ExpensestatementId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        public virtual Expensestatement Expensestatement { get; set; }
        public virtual Product Product { get; set; }
    }
}
