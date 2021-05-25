using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBusinessLogic.BindingModels
{
    public class DocumentProductBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string GrouppName { get; set; }
    }
}
