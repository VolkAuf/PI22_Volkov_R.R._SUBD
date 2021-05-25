using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseDatabaseImplement.Implements
{
    public class DocumentExpensesStorage : IDocumentExpensesStorage
    {
        public DocumentExpensesViewModel GetElement(DocumentExpensesBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentExpensesViewModel> GetFilteredList(DocumentExpensesBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentExpensesViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }
    }
}
