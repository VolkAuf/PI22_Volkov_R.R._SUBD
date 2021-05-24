using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseBusinessLogic.ViewModels
{
    public class ReceiptStatementViewModel
    {
        public int Id { get; set; }

        [DisplayName("Дата привоза")]
        public DateTime DateArrival { get; set; }

        [DisplayName("Поставщик")]
        public string Provider { get; set; }
    }
}
