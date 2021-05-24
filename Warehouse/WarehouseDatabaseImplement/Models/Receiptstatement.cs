using System;
using System.Collections.Generic;

namespace WarehouseDatabaseImplement.Models
{
    public partial class Receiptstatement
    {
        public Receiptstatement()
        {
            Receiptstatementproduct = new HashSet<Receiptstatementproduct>();
        }

        public int Id { get; set; }
        public DateTime Datearrival { get; set; }
        public string Provider { get; set; }

        public virtual ICollection<Receiptstatementproduct> Receiptstatementproduct { get; set; }
    }
}
