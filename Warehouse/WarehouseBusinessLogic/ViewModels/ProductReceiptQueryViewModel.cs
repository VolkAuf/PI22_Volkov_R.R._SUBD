using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseBusinessLogic.ViewModels
{
    public class ProductReceiptQueryViewModel
    {
        [DisplayName("Название продукции")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public int Price { get; set; }


        [DisplayName("Поставщик")]
        public string Provider { get; set; }
        [DisplayName("Дата привоза")]
        public DateTime DateArrival { get; set; }
        [DisplayName("Цена привоза")]
        public int PriceReceipt { get; set; }
        [DisplayName("Количество привоза")]
        public int CountReceipt { get; set; }
    }
}
