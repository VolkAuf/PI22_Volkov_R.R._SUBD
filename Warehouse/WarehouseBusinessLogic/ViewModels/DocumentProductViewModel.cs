using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseBusinessLogic.ViewModels
{
    public class DocumentProductViewModel
    {
        public int Id { get; set; }
        [DisplayName("Продукция")]
        public string Name { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Группа")]
        public string GrouppName { get; set; }
    }
}
