using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.Interfaces
{
    public interface IDocumentReceiptStorageRedis
    {
        List<DocumentReceiptViewModel> GetFullList();
        List<DocumentReceiptViewModel> GetFilteredList(DocumentReceiptBindingModel model);
        DocumentReceiptViewModel GetElement(DocumentReceiptBindingModel model);
        void InsertOrUpdate(DocumentReceiptBindingModel model);
        void DeleteAll();
    }
}
