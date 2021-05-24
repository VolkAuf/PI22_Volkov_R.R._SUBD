using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBusinessLogic.BindingModels
{
    public class ReceiptStatementBindingModel
    {
        public int? Id { get; set; }
        public DateTime DateArrival { get; set; }
        public string Provider { get; set; }

        public Dictionary<int, (string, int, int)> ReceiptStatementProducts { get; set; }
    }
}
