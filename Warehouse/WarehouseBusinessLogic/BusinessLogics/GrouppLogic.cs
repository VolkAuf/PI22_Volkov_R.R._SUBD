using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.BusinessLogics
{
    public class GrouppLogic
    {
        private readonly IGrouppStorage _grouppStorage;
        public GrouppLogic(IGrouppStorage grouppStorage)
        {
            _grouppStorage = grouppStorage;
        }
        public List<GrouppViewModel> Read(GrouppBindingModel model)
        {
            if (model == null)
            {
                return _grouppStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GrouppViewModel> { _grouppStorage.GetElement(model) };
            }
            return _grouppStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(GrouppBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _grouppStorage.Update(model);
            }
            else
            {
                _grouppStorage.Insert(model);
            }
        }
        public void Delete(GrouppBindingModel model)
        {
            GrouppViewModel element = _grouppStorage.GetElement(new GrouppBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _grouppStorage.Delete(model);
        }
    }
}
