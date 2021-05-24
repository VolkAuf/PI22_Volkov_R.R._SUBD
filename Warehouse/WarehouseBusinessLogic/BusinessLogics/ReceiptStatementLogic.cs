using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.BusinessLogics
{
    public class ReceiptStatementLogic
    {
        private readonly IReceiptStatementStorage _receiptStatementStorage;
        public ReceiptStatementLogic(IReceiptStatementStorage receiptStatementStorage)
        {
            _receiptStatementStorage = receiptStatementStorage;
        }
        public List<ReceiptStatementViewModel> Read(ReceiptStatementBindingModel model)
        {
            if (model == null)
            {
                return _receiptStatementStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ReceiptStatementViewModel> { _receiptStatementStorage.GetElement(model) };
            }
            return _receiptStatementStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ReceiptStatementBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _receiptStatementStorage.Update(model);
            }
            else
            {
                _receiptStatementStorage.Insert(model);
            }
        }
        public void Delete(ReceiptStatementBindingModel model)
        {
            ReceiptStatementViewModel element = _receiptStatementStorage.GetElement(new ReceiptStatementBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _receiptStatementStorage.Delete(model);
        }
    }
}
