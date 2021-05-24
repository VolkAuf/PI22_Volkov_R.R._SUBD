using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBusinessLogic.BindingModels
{
    public class ExpenseStatementBindingModel
    {
        public int? Id { get; set; }
        public DateTime DateDeparture { get; set; }
        public string Customer { get; set; }

        public Dictionary<int, (string, int, int)> ExpenseStatementProducts { get; set; }
    }
}
