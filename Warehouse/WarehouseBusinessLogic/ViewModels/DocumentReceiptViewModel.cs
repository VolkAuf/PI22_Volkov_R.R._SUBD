using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseBusinessLogic.ViewModels
{
    public class DocumentReceiptViewModel
    {
        public int Id { get; set; }
        [DisplayName("Поставщик")]
        public string Provider { get; set; }
        [DisplayName("Дата привоза")]
        public DateTime DateArrival { get; set; }
        [DisplayName("Цена привоза")]
        public int Price { get; set; }
        [DisplayName("Количество привоза")]
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
