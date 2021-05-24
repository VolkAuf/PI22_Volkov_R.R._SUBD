using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseBusinessLogic.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название продукции")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public int Price { get; set; }
        public int GrouppId { get; set; }

        [DisplayName("Название группы")]
        public string GrouppName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
