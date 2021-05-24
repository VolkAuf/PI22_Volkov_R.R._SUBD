using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseBusinessLogic.ViewModels
{
    public class ExpenseStatementViewModel
    {
        public int Id { get; set; }

        [DisplayName("Дата отгрузки")]
        public DateTime DateDeparture { get; set; }

        [DisplayName("Клиент")]
        public string Customer { get; set; }

        public Dictionary<int, (string, int, int)> ExpenseStatementProducts { get; set; }
    }
}
