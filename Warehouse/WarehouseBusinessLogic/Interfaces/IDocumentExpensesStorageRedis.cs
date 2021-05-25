using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.Interfaces
{
    public interface IDocumentExpensesStorageRedis
    {
        List<DocumentExpensesViewModel> GetFullList();
        List<DocumentExpensesViewModel> GetFilteredList(DocumentExpensesBindingModel model);
        DocumentExpensesViewModel GetElement(DocumentExpensesBindingModel model);
        void InsertOrUpdate(DocumentExpensesBindingModel model);
        void DeleteAll();
    }
}
