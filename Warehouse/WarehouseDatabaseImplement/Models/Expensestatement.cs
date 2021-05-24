using System;
using System.Collections.Generic;

namespace WarehouseDatabaseImplement.Models
{
    public partial class Expensestatement
    {
        public Expensestatement()
        {
            Expensestatementproduct = new HashSet<Expensestatementproduct>();
        }

        public int Id { get; set; }
        public DateTime Datedeparture { get; set; }
        public string Customer { get; set; }

        public virtual ICollection<Expensestatementproduct> Expensestatementproduct { get; set; }
    }
}
