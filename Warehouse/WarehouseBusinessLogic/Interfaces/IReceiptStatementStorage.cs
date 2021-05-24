using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.Interfaces
{
    public interface IReceiptStatementStorage
    {
        List<ReceiptStatementViewModel> GetFullList();
        List<ReceiptStatementViewModel> GetFilteredList(ReceiptStatementBindingModel model);
        ReceiptStatementViewModel GetElement(ReceiptStatementBindingModel model);
        void Insert(ReceiptStatementBindingModel model);
        void Update(ReceiptStatementBindingModel model);
        void Delete(ReceiptStatementBindingModel model);
    }
}
