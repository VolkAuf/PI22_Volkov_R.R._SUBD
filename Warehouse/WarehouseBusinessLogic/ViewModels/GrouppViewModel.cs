using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseBusinessLogic.ViewModels
{
    public class GrouppViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название группы")]
        public string Name { get; set; }
    }
}
