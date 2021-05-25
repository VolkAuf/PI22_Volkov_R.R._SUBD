using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseBusinessLogic.ViewModels
{
    public class DocumentExpensesViewModel
    {
        public int Id { get; set; }
        [DisplayName("Покупатель")]
        public string Customer { get; set; }
        [DisplayName("Дата отгрузки")]
        public DateTime DateDeparture { get; set; }
        [DisplayName("Цена отгрузки")]
        public int Price { get; set; }
        [DisplayName("Количество отгрузки")]
        public int Count { get; set; }
        [DisplayName("Продукция")]
        public string ProductName { get; set; }
        [DisplayName("Цена текущая")]
        public int ProductPrice { get; set; }
        [DisplayName("Количество текущее")]
        public int ProductCount { get; set; }
        [DisplayName("Название группы")]
        public string GrouppName { get; set; }
    }
}
