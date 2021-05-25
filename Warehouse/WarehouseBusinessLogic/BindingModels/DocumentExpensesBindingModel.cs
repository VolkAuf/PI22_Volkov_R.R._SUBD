using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBusinessLogic.BindingModels
{
    public class DocumentExpensesBindingModel
    {
        public int? Id { get; set; }
        public string Customer { get; set; }
        public DateTime DateDeparture { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public string GrouppName { get; set; }
    }
}
