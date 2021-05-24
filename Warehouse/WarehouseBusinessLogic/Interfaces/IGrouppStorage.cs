using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.Interfaces
{
    public interface IGrouppStorage
    {
        List<GrouppViewModel> GetFullList();
        List<GrouppViewModel> GetFilteredList(GrouppBindingModel model);
        GrouppViewModel GetElement(GrouppBindingModel model);
        void Insert(GrouppBindingModel model);
        void Update(GrouppBindingModel model);
        void Delete(GrouppBindingModel model);
    }
}
