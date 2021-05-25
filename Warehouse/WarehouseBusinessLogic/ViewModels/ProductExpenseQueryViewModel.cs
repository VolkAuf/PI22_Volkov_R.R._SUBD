using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseBusinessLogic.ViewModels
{
    public class ProductExpenseQueryViewModel
    { 
        [DisplayName("Название продукции")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public int Price { get; set; }


        [DisplayName("Клиент")]
        public string Customer { get; set; }
        [DisplayName("Дата отгрузки")]
        public DateTime DateDeparture { get; set; }
        [DisplayName("Цена отгрузки")]
        public int PriceExpense { get; set; }
        [DisplayName("Количество отгрузки")]
        public int CountExpense { get; set; }
    }
}
