using System;
using System.Collections.Generic;

namespace WarehouseDatabaseImplement.Models
{
    public partial class Product
    {
        public Product()
        {
            Expensestatementproduct = new HashSet<Expensestatementproduct>();
            Receiptstatementproduct = new HashSet<Receiptstatementproduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? GrouppId { get; set; }
        public int Count { get; set; }

        public virtual Groupp Groupp { get; set; }
        public virtual ICollection<Expensestatementproduct> Expensestatementproduct { get; set; }
        public virtual ICollection<Receiptstatementproduct> Receiptstatementproduct { get; set; }
    }
}
