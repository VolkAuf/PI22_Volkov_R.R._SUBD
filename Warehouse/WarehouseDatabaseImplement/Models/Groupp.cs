using System;
using System.Collections.Generic;

namespace WarehouseDatabaseImplement.Models
{
    public partial class Groupp
    {
        public Groupp()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
