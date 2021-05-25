using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseDatabaseImplement.Implements
{
    public class DocumentReceiptStorage : IDocumentReceiptStorage
    {
        public DocumentReceiptViewModel GetElement(DocumentReceiptBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentReceiptViewModel> GetFilteredList(DocumentReceiptBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentReceiptViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }
    }
}
